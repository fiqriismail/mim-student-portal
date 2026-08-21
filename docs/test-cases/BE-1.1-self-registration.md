# Test Cases — BE-1.1: Self-Registration

| Field | Value |
|---|---|
| **Story** | [BE-1.1 — Self-registration](../../brain/stories/backend/BE-1.1.md) |
| **PRD reference** | US-1.1 ([`brain/docs/PRD.md`](../../brain/docs/PRD.md)) |
| **Epic** | E1 — Account & Identity |
| **Layer** | Backend |
| **Endpoint under test** | `POST /identity/register` |
| **Design spec** | [`docs/superpowers/specs/2026-08-21-be-1.1-self-registration-design.md`](../superpowers/specs/2026-08-21-be-1.1-self-registration-design.md) |
| **Status** | Done — merged to `main` (PR [#3](https://github.com/fiqriismail/mim-student-portal/pull/3), [#5](https://github.com/fiqriismail/mim-student-portal/pull/5)) |

## Preconditions (all test cases)

- Local PostgreSQL running (`localhost:5432`), `student_portal_db` created and migrated (`dotnet ef database update`, from `apps/api/`).
- Backend running: `cd apps/api/MIM.Portal.Api && dotnet run` — confirm with `GET /health` → `200 {"status":"healthy"}`.
- Default local port: `http://localhost:5176`.
- Each test case's "before" state assumes no prior registration exists for the email under test unless the case says otherwise — use a fresh, unique email per run (e.g. `jane.<timestamp>@example.com`) to avoid cross-run interference from earlier test data.

## Request shape (reference)

```json
POST /identity/register
Content-Type: application/json

{
  "fullName": "Jane Doe",
  "email": "jane@example.com",
  "phone": "0770000000",
  "password": "verysecurepassword",
  "passwordConfirmation": "verysecurepassword"
}
```

---

## Test Cases

| Test Case ID | Title | Related AC | Type | Priority | Preconditions | Test Steps | Test Data | Expected Result |
|---|---|---|---|---|---|---|---|---|
| TC-BE-1.1-01 | Successful registration with valid data | AC-1.1.6 | Positive | High | Email not previously registered | 1. POST `/identity/register` with valid body. 2. Inspect response. 3. Query `asp_net_users`, `student_profiles`, `tokens` for the new email. | `fullName="Jane Doe"`, unique `email`, `phone="0770000000"`, `password="verysecurepassword"`, matching `passwordConfirmation` | `200 OK`, body `{"email": "<the email>"}`. DB: `asp_net_users` row with `role=0` (Student), `status=0` (PendingVerification), `email_confirmed=false`. `student_profiles` row linked by `user_id`, `student_reference` matches `MIM-{year}-{5-digit}` (e.g. `MIM-2026-00001`). `tokens` row with `type=0` (EmailVerification), `token_hash` populated, `expires_at` ≈ now + 24h (allow a few minutes' drift), `consumed_at` is `NULL`. |
| TC-BE-1.1-02 | Duplicate email is rejected without disclosing account existence | AC-1.1.2 | Negative | High | An account already exists for the email (register it first with TC-BE-1.1-01's steps) | 1. POST `/identity/register` again with the same email (same case) and any valid password/name/phone. 2. Inspect response body and status. | Same `email` as an existing account; other fields valid | `400 Bad Request`. Response body's `detail` (or equivalent `message`) is **exactly**: "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password." No field-level error naming "email" as the problem. No second row created in `asp_net_users` for that email. |
| TC-BE-1.1-03 | Duplicate email check is case-insensitive | AC-1.1.2 | Negative | High | An account exists for `jane@example.com` | 1. POST `/identity/register` with `email="JANE@EXAMPLE.COM"` (different casing) and valid other fields. | `email="JANE@EXAMPLE.COM"` | `400 Bad Request` with the same generic non-disclosing message as TC-BE-1.1-02 — casing must not bypass the uniqueness check (enforced via a DB-level unique index on `normalized_email`, not only application logic). |
| TC-BE-1.1-04 | Password shorter than the minimum length is rejected | AC-1.1.3 | Negative | High | None | 1. POST `/identity/register` with `password`/`passwordConfirmation` = a 9-character string, all else valid. | `password="short123"` (9 chars) | `400 Bad Request`, validation error referencing the password field (e.g. `errors.password`). No user row created. |
| TC-BE-1.1-05 | Password at exactly the minimum length (boundary) succeeds | AC-1.1.3 | Positive (boundary) | Medium | Email not previously registered | 1. POST `/identity/register` with a 10-character password, all else valid. | `password="abcdefghij"` (exactly 10 chars) | `200 OK`, registration succeeds as in TC-BE-1.1-01. |
| TC-BE-1.1-06 | Password with no complexity beyond length succeeds | AC-1.1.3 | Positive | Medium | Email not previously registered | 1. POST `/identity/register` with an all-lowercase, no-digit, no-symbol password ≥10 chars. | `password="verysecurepassword"` | `200 OK` — confirms no hidden complexity rule (digit/uppercase/symbol) is enforced beyond the 10-character minimum. |
| TC-BE-1.1-07 | Password and confirmation mismatch is rejected | — (validation) | Negative | High | None | 1. POST `/identity/register` with `password` and `passwordConfirmation` set to different values. | `password="verysecurepassword"`, `passwordConfirmation="differentpassword"` | `400 Bad Request`, validation error referencing `passwordConfirmation`. No user row created. |
| TC-BE-1.1-08 | Missing required field is rejected | — (validation) | Negative | Medium | None | 1. POST `/identity/register` omitting `fullName` (repeat for `email`, `phone`, `password`, `passwordConfirmation` as separate sub-cases). | One required field omitted per run | `400 Bad Request`, validation error referencing the missing field. |
| TC-BE-1.1-09 | Syntactically invalid email is rejected | — (validation) | Negative | Medium | None | 1. POST `/identity/register` with a malformed email address. | `email="not-an-email"` | `400 Bad Request`, validation error referencing `email`. |
| TC-BE-1.1-10 | Password is hashed with a memory-hard algorithm and never stored or logged in plaintext | AC-1.1.8 | Positive / Security | High | Registration completed (TC-BE-1.1-01) | 1. Query `asp_net_users.password_hash` for the new row. 2. Inspect backend application logs for the same time window. | — | `password_hash` is not equal to, and does not contain, the plaintext password; it is formatted as `{salt}.{hash}` (Argon2id). The plaintext password string does not appear anywhere in the backend's console/log output for this request. |
| TC-BE-1.1-11 | `student_reference` is sequential and correctly formatted | AC-1.1.6 | Positive | Medium | At least two successful registrations in sequence | 1. Register two distinct accounts back-to-back. 2. Compare their `student_reference` values. | Two unique emails | Both references match `MIM-{current year}-{5-digit zero-padded}`; the second registration's numeric suffix is exactly one greater than the first's (e.g. `MIM-2026-00001`, `MIM-2026-00002`), confirming the underlying Postgres sequence advances correctly under sequential use. |
| TC-BE-1.1-12 | Only the verification token's hash is persisted, never the raw token | AC-1.1.6 | Security | High | Registration completed (TC-BE-1.1-01) | 1. Query the `tokens` table for the new row. 2. Inspect the logged verification email content for the raw token/link. | — | `tokens.token_hash` is a hash value (not human-readable/guessable), and no column anywhere stores the raw token. (The raw token does appear in the backend's log output as part of the verification link — this is the current, deliberate dev-only stand-in for a real email provider; it is not expected to appear in any database table.) |
| TC-BE-1.1-13 | A downstream failure during registration does not leave an orphaned, permanently-blocked user | Data integrity (post-review fix) | Negative / Integrity | High | Ability to force a downstream failure after user creation (e.g. via a temporarily invalid `student_reference_seq` state, or a mocked `IRegistrationWriter` failure in an integration/test environment) | 1. Trigger a registration where user creation (Identity) succeeds but `StudentProfile`/`Token` persistence fails. 2. Attempt to register the same email again. | Same email, forced downstream failure on first attempt | First attempt: `400`/`500` (failure result), and the `asp_net_users` row for that email does **not** persist (transaction rolled back). Second attempt with the same email: succeeds normally (`200 OK`) — the email is not permanently blocked. |
| TC-BE-1.1-14 | Registration is rate-limited to 5 requests per IP per hour | AC-1.1.9 | Negative | High | None (fresh rate-limit window for the test client's IP) | 1. POST `/identity/register` 5 times in quick succession from the same client, each with a distinct valid email. 2. POST a 6th time with another distinct valid email, same client/IP, within the same hour. | 6 distinct valid registration payloads | Requests 1–5: normal responses (`200` or `400` per their own validity — the limiter counts all attempts, not just successes). Request 6: `429 Too Many Requests` with a human-readable JSON body (`{"message": "Too many requests. Please try again later."}`). |
| TC-BE-1.1-15 | Rate limiting is IP-partitioned, not global | AC-1.1.9 | Positive | Medium | Two distinct client IPs available (e.g. via `X-Forwarded-For` in a test harness, with the app's forwarded-headers trust configured for the test network) | 1. Exhaust the 5/hour limit from IP A (per TC-BE-1.1-14). 2. Immediately POST from IP B with a valid payload. | Distinct email per request | IP A's 6th request: `429`. IP B's request: succeeds normally (`200`), confirming the rate limiter partitions per-client rather than applying a single global counter. |
| TC-BE-1.1-16 | Health check endpoint is reachable | — (smoke) | Positive | Low | Backend running | 1. GET `/health`. | — | `200 OK`, body `{"status": "healthy"}`. |

---

## Automated coverage

The behaviors above are also covered by the automated suite (`dotnet test` from `apps/api/`, 22 tests across `MIM.Portal.Domain.Tests`, `MIM.Portal.Application.Tests`, `MIM.Portal.Infrastructure.Tests`, and `MIM.Portal.Api.Tests`):

| Automated test | Covers |
|---|---|
| `RegisterHandlerTests.Successful_registration_creates_profile_token_and_enqueues_email` | TC-BE-1.1-01 |
| `RegisterHandlerTests.Failed_user_creation_returns_generic_message_without_touching_profile_or_email` | TC-BE-1.1-02, TC-BE-1.1-13 (unit-level) |
| `RegisterValidatorTests.*` | TC-BE-1.1-04–09 |
| `ArgonPasswordHasherTests.*` | TC-BE-1.1-10 |
| `RegisterEndpointTests.Register_creates_user_profile_and_token` | TC-BE-1.1-01, TC-BE-1.1-11, TC-BE-1.1-12 |
| `RegisterEndpointTests.Duplicate_email_returns_generic_message` | TC-BE-1.1-02 |
| `RegisterEndpointRateLimitTests.Sixth_registration_attempt_in_an_hour_is_rate_limited` | TC-BE-1.1-14 |

TC-BE-1.1-03, TC-BE-1.1-15, and TC-BE-1.1-16 do not currently have a dedicated automated test and should be run manually per the steps above, or added as new automated cases in a follow-up story.
