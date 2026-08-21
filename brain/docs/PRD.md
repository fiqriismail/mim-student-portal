# MIM Student Portal — Product Requirements Document

**Phase 1: Course Discovery & Enrolment (Web)**

| Field | Value |
|---|---|
| Product | MIM Student Portal |
| Phase | 1 of N — Web |
| Version | 1.0 |
| Date | 21 August 2026 |
| Owner | Fiqri Ismail |
| Status | **Approved** — baselined 21 August 2026 by Fiqri Ismail |
| Supersedes | *MIM LMS Mobile Application* proposal (scope reframed: web-first, phased) |

### Change log

| Version | Date | Change |
|---|---|---|
| 0.1 | 21 Aug 2026 | Initial draft |
| 1.0 | 21 Aug 2026 | Approved and baselined. Scope in §5.1 and §2.2 is now change-controlled: additions require an amendment and a version bump. The open questions in §11 remain open and are tracked separately — they do not block approval, but OQ-2, OQ-3, OQ-5 and OQ-6 must be resolved before the affected requirements are built. |

---

## 1. Background

Maharaja Institute of Management (MIM) operates an existing Learning Management System covering learning delivery, assessments, attendance, payments, results and communication across seven role types. A proposal was drafted to rebuild this as a mobile application.

This PRD reframes that effort. The Student Portal is a **ground-up rebuild that will eventually replace the existing LMS**, delivered in phases, **web-first**. Mobile is a later phase, not the starting point.

Phase 1 is deliberately narrow. Rather than porting the full LMS surface area, Phase 1 delivers the **front door**: a public course catalog and student self-registration with instant enrolment. This produces a shippable, independently valuable product — an admissions and enrolment funnel — while establishing the identity, data and platform foundations that every later phase depends on.

### 1.1 Why this scope first

- **It is the only part of the LMS with no upstream dependency.** Enrolment creates the student and course records that assignments, attendance, results and payments all hang off. Building it first means no synchronisation with the legacy LMS is required.
- **It is externally visible.** A public catalog serves prospective students, not just enrolled ones, so it delivers value from day one.
- **It de-risks the foundations.** Auth, roles, session management, notifications and the core domain model get built and proven against a small feature set before high-risk features (timed assessments, result approval chains) arrive.

### 1.2 Relationship to the existing LMS

The new portal is a **clean-slate build with no data sync and no integration** with the legacy LMS. Both systems run in parallel: the legacy LMS continues to serve existing students and staff for everything it does today, while the new portal handles new course discovery and enrolment. Migration of legacy data is out of scope for Phase 1 and will be addressed as a dedicated workstream when the portal's feature coverage justifies cutover.

> **Consequence to accept explicitly:** during Phase 1 a student enrolled through the portal does not exist in the legacy LMS. Getting them into the legacy LMS for actual course delivery is a **manual operational step** until Phase 2. Section 11 tracks this as a required operational runbook, not a system feature.

---

## 2. Goals and Non-Goals

### 2.1 Goals

| # | Goal | Rationale |
|---|---|---|
| G1 | Let prospective and current students browse MIM's course offering without contacting staff | Removes a manual, staff-mediated first touch |
| G2 | Let a student create their own account and enrol in a course in a single sitting | Compresses the enrolment funnel |
| G3 | Enforce seat capacity automatically and correctly under concurrency | Prevents over-enrolment, the main correctness risk in this phase |
| G4 | Establish the identity, role and domain foundations for all later phases | Avoids rework when lecturer/admin modules land |
| G5 | Give staff visibility into who has enrolled in what | Operational necessity even without an admin UI |

### 2.2 Non-Goals (Phase 1)

Explicitly **not** built in Phase 1, despite appearing in the original proposal:

- Learning materials, assignments, assessments (MCQ or upload-based)
- Attendance (viewing or marking)
- Results, grades, result approval workflow
- Payments of any kind — including viewing balances, uploading evidence, or online payment
- Student↔lecturer chat or messaging
- Lecturer module, admin module, finance module, moderator/director roles
- Class schedules and examination calendars
- Gamification, achievements, badges, leaderboards
- Native mobile applications
- Any migration from, or synchronisation with, the legacy LMS

Anything on this list that appears in a Phase 1 build is scope creep and should be rejected at review.

---

## 3. Success Metrics

| Metric | Definition | Target |
|---|---|---|
| Enrolment completion rate | Students who reach the catalog and complete an enrolment ÷ students who start registration | ≥ 60% |
| Time to enrol | Median elapsed time from account creation to first confirmed enrolment | ≤ 5 minutes |
| Self-service rate | Enrolments completed with no staff intervention ÷ total enrolments | ≥ 90% |
| Over-enrolment incidents | Courses whose confirmed enrolments exceed capacity | 0 |
| Email verification rate | Verified accounts ÷ created accounts | ≥ 80% |
| Catalog reach | Unique visitors to the public catalog per month | Baseline in month 1, growth thereafter |

Instrumentation for these metrics is a Phase 1 requirement (see §9).

---

## 4. Users and Personas

Phase 1 serves **students only**. Staff roles are represented in the data model but have no UI.

### 4.1 Prospective Student (primary)

Has no MIM account. Arrives from a link, search or social post. Wants to know what courses exist, what they cost, when they start, and whether places remain. Will abandon quickly if made to fill in forms before seeing anything of value.

**Needs:** browse without an account; clear course information; a short path from interest to enrolment.

### 4.2 Enrolled Student (primary)

Has completed at least one enrolment. Returns to check enrolment status, review course details, or enrol in an additional course.

**Needs:** see current enrolments at a glance; re-access course information; manage their own profile and credentials.

### 4.3 MIM Staff (indirect, no UI in Phase 1)

Registrar and programme coordinators who need to know who has enrolled. In Phase 1 they are served by **database-backed exports and reports**, not screens.

**Needs:** an accurate, exportable list of enrolments; confidence that capacity was respected.

### 4.4 Future roles (data model only)

`LECTURER`, `ADMIN`, `COORDINATOR`, `FINANCE`, `ACCOUNTANT`, `MODERATOR`, `DIRECTOR`, `GROUP_DIRECTOR` exist as role values from Phase 1 so that authorisation does not need re-architecting later. No Phase 1 UI grants or uses them.

---

## 5. Scope

### 5.1 In scope — Phase 1

| Epic | Summary |
|---|---|
| E1 — Account & Identity | Public self-registration, email verification, login, logout, password reset, session management |
| E2 — Student Profile | View and edit own profile, change password |
| E3 — Course Catalog | Public browsing, search, filter, course detail pages |
| E4 — Enrolment | Instant enrolment with seat-capacity enforcement, enrolment list, self-withdrawal |
| E5 — Notifications | Transactional email only (verification, reset, enrolment confirmation) |
| E6 — Catalog Seeding & Ops | Seed scripts for course data, enrolment export for staff |
| E7 — Platform Foundations | Role model, audit logging, error handling, analytics instrumentation |

### 5.2 Phased roadmap

Later phases are indicative, not committed. They exist here so Phase 1 decisions account for what follows.

| Phase | Focus | Notes |
|---|---|---|
| **1** | Course catalog + student self-registration + instant enrolment (web) | This document |
| **2** | Admin & coordinator module: course/module/batch CRUD, student management, enrolment administration | Removes the seed-script dependency; enables staff self-sufficiency |
| **3** | Learning delivery: modules, learning materials, lecturer module, schedules | First real "LMS" capability |
| **4** | Assessment: assignments, MCQ and upload-based assessments, marking, feedback | Highest technical risk; needs its own PRD |
| **5** | Attendance, results and the result approval chain (moderator → director → publication) | Governance-heavy |
| **6** | Payments: balances, evidence upload, finance verification, online gateway | Requires PSP and reconciliation decisions |
| **7** | Communication, notifications-at-scale, gamification and achievements | Engagement layer |
| **8** | Native mobile applications | The original proposal's subject, now built on a proven API |
| **9** | Legacy LMS data migration and decommissioning | Cutover workstream |

### 5.3 Out of scope — all phases

- Third-party LMS integration (Moodle, Canvas, etc.)
- Public-facing marketing website beyond the course catalog
- Alumni or HR systems

---

## 6. Domain Model

Phase 1 introduces the following entities. Attributes listed are the minimum required; implementations may add more.

### 6.1 Entities

**User**
`id`, `email` (unique, lowercased), `password_hash`, `full_name`, `phone`, `role` (enum, default `STUDENT`), `status` (`PENDING_VERIFICATION` | `ACTIVE` | `SUSPENDED`), `email_verified_at`, `created_at`, `updated_at`, `last_login_at`

**StudentProfile**
`id`, `user_id` (1:1), `student_reference` (system-generated, human-readable, e.g. `MIM-2026-00042`), `date_of_birth`, `nic_or_passport`, `address`, `highest_qualification`, `created_at`, `updated_at`

**Course**
`id`, `code` (unique), `title`, `slug` (unique), `short_description`, `full_description`, `duration_text`, `delivery_mode` (`ON_CAMPUS` | `ONLINE` | `BLENDED`), `fee_display_text`, `entry_requirements_text`, `status` (`DRAFT` | `PUBLISHED` | `ARCHIVED`), `created_at`, `updated_at`

**Batch**
`id`, `course_id`, `name` (e.g. "January 2027 Intake"), `start_date`, `end_date`, `capacity` (integer), `status` (`DRAFT` | `OPEN` | `CLOSED` | `FULL`), `created_at`, `updated_at`

**Enrolment**
`id`, `student_profile_id`, `batch_id`, `status` (`ACTIVE` | `WITHDRAWN`), `enrolled_at`, `withdrawn_at`, `created_at`, `updated_at`
Unique constraint on (`student_profile_id`, `batch_id`) where `status = ACTIVE`.

**AuditLog**
`id`, `actor_user_id` (nullable for system actions), `action`, `entity_type`, `entity_id`, `metadata` (JSON), `ip_address`, `created_at`

**Token** (verification and password reset)
`id`, `user_id`, `type` (`EMAIL_VERIFICATION` | `PASSWORD_RESET`), `token_hash`, `expires_at`, `consumed_at`, `created_at`

### 6.2 Key relationships and rules

- A `Course` has many `Batch`es. **Enrolment is always against a Batch, never a Course directly** — capacity, dates and open/closed state are batch-level properties.
- A student may hold multiple `ACTIVE` enrolments across different batches. There is no one-course-at-a-time restriction in Phase 1.
- A student may not hold two `ACTIVE` enrolments in the same batch.
- Seat availability = `batch.capacity − count(enrolments where batch_id = batch.id and status = ACTIVE)`.
- Only `PUBLISHED` courses with at least one `OPEN` batch appear in the public catalog.

### 6.3 Enrolment state machine

```
              enrol (seats available)
   [none] ─────────────────────────────► [ACTIVE]
                                             │
                                             │ student withdraws
                                             ▼
                                        [WITHDRAWN]
                                             │
                                             │ re-enrol (seats available)
                                             ▼
                                         [ACTIVE]
```

Withdrawal releases the seat immediately and returns it to the available pool.

---

## 7. Functional Requirements

Requirements are given as user stories with testable acceptance criteria. **MoSCoW** priority: `M` = Must, `S` = Should, `C` = Could.

---

### E1 — Account & Identity

#### US-1.1 — Self-registration `M`

> As a prospective student, I want to create an account with my email and a password, so that I can enrol in a course.

**Acceptance criteria**

- **AC-1.1.1** The registration form collects: full name, email, phone, password, password confirmation.
- **AC-1.1.2** Email must be a syntactically valid address and unique (case-insensitive) across all users. A duplicate submission returns a field-level error that does **not** disclose whether an account exists — the generic message "We couldn't complete registration with these details. If you already have an account, try signing in or resetting your password."
- **AC-1.1.3** Password must be at least 10 characters. Strength is indicated to the user; complexity-character rules are not enforced beyond length.
- **AC-1.1.4** Password and confirmation must match; mismatch shows a field-level error without clearing either field.
- **AC-1.1.5** The user must tick a checkbox accepting the Terms of Use and Privacy Notice. Both link to their respective pages, which open in a new tab. Submission is blocked while unticked.
- **AC-1.1.6** On successful submission the system creates a `User` with `role = STUDENT` and `status = PENDING_VERIFICATION`, creates the associated `StudentProfile` with a generated `student_reference`, issues an `EMAIL_VERIFICATION` token valid for 24 hours, and sends the verification email.
- **AC-1.1.7** The user is redirected to a "check your email" page showing the address used and a "resend email" control.
- **AC-1.1.8** Passwords are stored only as a salted hash using a memory-hard algorithm. Plaintext passwords never appear in logs, audit records or error reports.
- **AC-1.1.9** Registration is rate-limited to 5 attempts per IP address per hour. Exceeding it returns HTTP 429 with a human-readable message.
- **AC-1.1.10** The form is protected against automated abuse (CAPTCHA or equivalent challenge). The challenge must be accessible to screen-reader and keyboard-only users.

#### US-1.2 — Email verification `M`

> As a registered user, I want to verify my email address, so that my account becomes active.

**Acceptance criteria**

- **AC-1.2.1** The verification email contains a single-use link with a high-entropy token. Only the token's hash is stored.
- **AC-1.2.2** Following a valid, unconsumed, unexpired link sets `email_verified_at`, sets `status = ACTIVE`, marks the token consumed, and signs the user in.
- **AC-1.2.3** An expired or already-consumed token shows an explanatory page with a control to request a new verification email.
- **AC-1.2.4** An invalid or unrecognised token shows the same generic failure page — no distinction is exposed between "wrong" and "expired".
- **AC-1.2.5** Resending a verification email invalidates any previously issued unconsumed verification token for that user.
- **AC-1.2.6** Resend is rate-limited to 3 requests per account per hour.
- **AC-1.2.7** A user with `status = PENDING_VERIFICATION` may sign in and browse, but **may not enrol**. Attempting to enrol shows a prompt to verify, with a resend control inline.

#### US-1.3 — Login `M`

> As a student, I want to sign in, so that I can access my enrolments and profile.

**Acceptance criteria**

- **AC-1.3.1** Login accepts email and password.
- **AC-1.3.2** Failed login returns a single generic message — "Email or password is incorrect" — regardless of whether the email exists.
- **AC-1.3.3** After 5 consecutive failed attempts for an account, further attempts are throttled with exponential backoff for 15 minutes. The account is not permanently locked.
- **AC-1.3.4** Successful login creates a session, records `last_login_at`, and writes an audit entry with IP address.
- **AC-1.3.5** A "Remember me" option extends session lifetime to 30 days; without it, the session expires after 24 hours of inactivity.
- **AC-1.3.6** A user with `status = SUSPENDED` cannot sign in and sees a message directing them to contact MIM.
- **AC-1.3.7** After login the user lands on their dashboard, or on the page they originally requested if they were redirected to login from a protected page.

#### US-1.4 — Logout `M`

> As a signed-in student, I want to sign out, so that my account is not accessible to someone else on this device.

**Acceptance criteria**

- **AC-1.4.1** Logout is reachable from the primary navigation on every authenticated page.
- **AC-1.4.2** Logout invalidates the session server-side, not only by clearing the cookie.
- **AC-1.4.3** After logout the user is returned to the public catalog with a confirmation message.
- **AC-1.4.4** Using the browser back button after logout does not render authenticated content.

#### US-1.5 — Password reset `M`

> As a student who has forgotten my password, I want to reset it by email, so that I can regain access.

**Acceptance criteria**

- **AC-1.5.1** The "forgot password" form accepts an email address and always returns the same confirmation message, whether or not an account exists.
- **AC-1.5.2** If the account exists, a `PASSWORD_RESET` token valid for 60 minutes is issued and emailed.
- **AC-1.5.3** Requesting a reset invalidates any previously issued unconsumed reset token for that user.
- **AC-1.5.4** The reset form enforces the same password rules as registration (AC-1.1.3, AC-1.1.4).
- **AC-1.5.5** Completing a reset consumes the token, updates the password hash, **invalidates all existing sessions for that user**, and writes an audit entry.
- **AC-1.5.6** After a successful reset the user is sent a confirmation email noting the change and how to contact MIM if it was not them.
- **AC-1.5.7** Reset requests are rate-limited to 3 per email address per hour and 10 per IP per hour.

#### US-1.6 — Session management `M`

> As a student, I want my session handled securely, so that my account is protected.

**Acceptance criteria**

- **AC-1.6.1** Session cookies are `HttpOnly`, `Secure` and `SameSite=Lax`.
- **AC-1.6.2** The session identifier is regenerated on login and on password change.
- **AC-1.6.3** All state-changing requests are protected against cross-site request forgery.
- **AC-1.6.4** Idle sessions expire per AC-1.3.5; expiry redirects to login with an explanatory message and preserves the requested destination.

---

### E2 — Student Profile

#### US-2.1 — View profile `M`

> As a student, I want to see my profile, so that I can confirm MIM holds the right details.

**Acceptance criteria**

- **AC-2.1.1** The profile page shows: full name, student reference, email, phone, date of birth, NIC/passport, address, highest qualification, account status, and account creation date.
- **AC-2.1.2** `student_reference` is displayed prominently and is not editable.
- **AC-2.1.3** Fields never captured are shown as "Not provided" with an inline prompt to add them, not as blank space.

#### US-2.2 — Edit profile `M`

> As a student, I want to update my details, so that my records stay accurate.

**Acceptance criteria**

- **AC-2.2.1** Editable fields: full name, phone, date of birth, NIC/passport, address, highest qualification.
- **AC-2.2.2** Email is **not** editable in Phase 1. The UI states that email changes require contacting MIM.
- **AC-2.2.3** Date of birth must be a valid past date and imply an age of at least 16 at the time of entry.
- **AC-2.2.4** Successful save shows a confirmation and writes an audit entry recording which fields changed (values of sensitive fields are not written to the audit log).
- **AC-2.2.5** Validation errors preserve all entered values.

#### US-2.3 — Change password `M`

> As a signed-in student, I want to change my password, so that I can keep my account secure.

**Acceptance criteria**

- **AC-2.3.1** The form requires the current password plus a new password and confirmation.
- **AC-2.3.2** An incorrect current password returns an error and does not change the stored password.
- **AC-2.3.3** The new password must satisfy AC-1.1.3 and must differ from the current password.
- **AC-2.3.4** A successful change invalidates all other sessions, keeps the current one signed in, sends a confirmation email, and writes an audit entry.

---

### E3 — Course Catalog

#### US-3.1 — Browse the catalog `M`

> As a prospective student, I want to browse available courses without signing in, so that I can decide whether MIM is right for me.

**Acceptance criteria**

- **AC-3.1.1** The catalog is publicly accessible with no authentication.
- **AC-3.1.2** Only courses with `status = PUBLISHED` appear.
- **AC-3.1.3** Each catalog card shows: title, course code, short description, delivery mode, duration, next open intake start date, and a seat-availability indicator.
- **AC-3.1.4** The seat indicator shows one of: "Places available", "Only N places left" (when remaining ≤ 5), or "Full".
- **AC-3.1.5** Results are paginated at 12 per page with accessible pagination controls.
- **AC-3.1.6** Default sort is by next intake start date ascending; courses with no open intake sort last.
- **AC-3.1.7** An empty catalog shows an explanatory empty state, not a blank page.
- **AC-3.1.8** The catalog renders correctly at 320px width and above.

#### US-3.2 — Search and filter `S`

> As a prospective student, I want to narrow the list, so that I can find relevant courses quickly.

**Acceptance criteria**

- **AC-3.2.1** A free-text search matches against course title, code and short description, case-insensitively, on partial words.
- **AC-3.2.2** Filters available: delivery mode, availability (has open intake), and intake start month.
- **AC-3.2.3** Filters and search combine with AND logic.
- **AC-3.2.4** Active filters are reflected in the URL query string so a filtered view can be shared and bookmarked.
- **AC-3.2.5** A "clear all" control resets to the unfiltered catalog.
- **AC-3.2.6** A no-results state names the active filters and offers to clear them.

#### US-3.3 — View course detail `M`

> As a prospective student, I want full information about a course, so that I can decide whether to enrol.

**Acceptance criteria**

- **AC-3.3.1** The detail page is publicly accessible at a stable, human-readable URL derived from the course slug.
- **AC-3.3.2** It displays: title, code, full description, duration, delivery mode, entry requirements, fee information, and a list of all `OPEN` batches.
- **AC-3.3.3** Each listed batch shows its name, start date, end date, capacity, and remaining places.
- **AC-3.3.4** A batch at capacity is shown as "Full" and its enrol control is disabled with an accessible explanation.
- **AC-3.3.5** An unauthenticated visitor sees an "Enrol" control that routes to registration/login and returns them to this page afterwards.
- **AC-3.3.6** Requesting a `DRAFT`, `ARCHIVED` or non-existent course returns a 404 page offering a link back to the catalog.
- **AC-3.3.7** The page carries appropriate metadata (title, description, canonical URL, Open Graph tags) for search engines and link previews.

---

### E4 — Enrolment

#### US-4.1 — Enrol in a batch `M`

> As a verified student, I want to enrol in a course intake, so that my place is confirmed immediately.

**Acceptance criteria**

- **AC-4.1.1** The enrol control is available only to users with `status = ACTIVE`.
- **AC-4.1.2** Selecting "Enrol" presents a confirmation step showing course, batch, dates and fee information, requiring explicit confirmation before the enrolment is created.
- **AC-4.1.3** On confirmation the system creates an `Enrolment` with `status = ACTIVE` and `enrolled_at` set to the current timestamp.
- **AC-4.1.4** **Capacity is enforced atomically.** The check for available seats and the creation of the enrolment occur within a single transaction using row-level locking or an equivalent guarantee. Concurrent requests for the last remaining seat must result in exactly one success; every other request receives a "batch is now full" error.
- **AC-4.1.5** A student already holding an `ACTIVE` enrolment in the same batch cannot enrol again; the UI shows "You are already enrolled" instead of an enrol control.
- **AC-4.1.6** A student may enrol in multiple different batches, including different batches of the same course.
- **AC-4.1.7** Enrolment in a batch whose `status` is not `OPEN` is rejected regardless of remaining capacity.
- **AC-4.1.8** Success shows a confirmation page with the course, batch, dates, and the student's reference number, plus links to "My Enrolments" and back to the catalog.
- **AC-4.1.9** A confirmation email is sent (US-5.2).
- **AC-4.1.10** Every enrolment writes an audit entry recording actor, batch, and remaining capacity after the operation.
- **AC-4.1.11** When a batch reaches capacity its `status` transitions to `FULL` and it is presented as full across catalog and detail pages within one page load.
- **AC-4.1.12** Duplicate form submission (double-click, browser resubmit) must not create two enrolments — enforced by idempotency key or the uniqueness constraint in §6.1, not by client-side button disabling alone.

#### US-4.2 — View my enrolments `M`

> As a student, I want to see the courses I'm enrolled in, so that I know where I stand.

**Acceptance criteria**

- **AC-4.2.1** "My Enrolments" lists all enrolments for the signed-in student, `ACTIVE` first, then `WITHDRAWN`.
- **AC-4.2.2** Each entry shows course title and code, batch name, start and end dates, enrolment status, and the date enrolled.
- **AC-4.2.3** Each entry links to the course detail page.
- **AC-4.2.4** A student with no enrolments sees an empty state with a prompt to browse the catalog.
- **AC-4.2.5** A student can only ever see their own enrolments; requesting another student's enrolment by identifier returns 404, not 403 (no existence disclosure).

#### US-4.3 — Withdraw from a batch `S`

> As a student, I want to withdraw from a course I enrolled in by mistake or no longer want, so that I am not held to it.

**Acceptance criteria**

- **AC-4.3.1** Withdrawal is available only for `ACTIVE` enrolments.
- **AC-4.3.2** Withdrawal requires a confirmation step warning that the place is released and re-enrolment depends on availability.
- **AC-4.3.3** Withdrawal sets `status = WITHDRAWN` and `withdrawn_at`, and does not delete the record.
- **AC-4.3.4** The released seat becomes immediately available; a `FULL` batch returns to `OPEN`.
- **AC-4.3.5** A withdrawal notification email is sent to the student, and the event is written to the audit log.
- **AC-4.3.6** Withdrawal is blocked after the batch start date; the UI directs the student to contact MIM instead.
- **AC-4.3.7** A withdrawn student may re-enrol in the same batch if it is `OPEN` and has capacity.

#### US-4.4 — Student dashboard `M`

> As a signed-in student, I want a landing page that orients me, so that I can pick up where I left off.

**Acceptance criteria**

- **AC-4.4.1** The dashboard shows a greeting with the student's name and their student reference.
- **AC-4.4.2** It shows active enrolments with their next relevant date.
- **AC-4.4.3** It shows a verification banner if `status = PENDING_VERIFICATION`, with a resend control.
- **AC-4.4.4** It shows a profile-completion prompt if any of date of birth, NIC/passport or address is missing.
- **AC-4.4.5** It offers a clear route to the catalog.
- **AC-4.4.6** Dashboard sections are placeholders-free — features not yet built (results, payments, materials) do **not** appear as disabled or "coming soon" tiles.

---

### E5 — Notifications

Phase 1 sends **transactional email only**. No in-app notification centre, no SMS, no push.

#### US-5.1 — Account emails `M`

> As a student, I want email confirmation of account actions, so that I can complete them and detect anything unexpected.

**Acceptance criteria**

- **AC-5.1.1** Emails sent: email verification, password reset request, password reset confirmation, password change confirmation.
- **AC-5.1.2** Every email states clearly that it comes from MIM, what triggered it, and what to do if the recipient did not initiate it.
- **AC-5.1.3** Emails render legibly as plain text as well as HTML.
- **AC-5.1.4** Links are absolute, use HTTPS, and point at the configured canonical domain.
- **AC-5.1.5** Delivery failures are logged with enough context to diagnose; a failure to send never leaves the account in an inconsistent state.

#### US-5.2 — Enrolment emails `M`

> As a student, I want written confirmation of my enrolment, so that I have a record of it.

**Acceptance criteria**

- **AC-5.2.1** An enrolment confirmation email is sent on successful enrolment containing course title and code, batch name, start and end dates, delivery mode, the student's reference, and MIM contact details.
- **AC-5.2.2** A withdrawal confirmation email is sent on withdrawal.
- **AC-5.2.3** Emails are queued and sent asynchronously; email latency or failure must never block or roll back the enrolment transaction.
- **AC-5.2.4** Failed sends are retried with backoff at least 3 times before being recorded as failed.

---

### E6 — Catalog Seeding & Operations

Phase 1 has no admin UI. These requirements make the system operable regardless.

#### US-6.1 — Seed course data `M`

> As a developer, I want to load and update the course catalog from version-controlled seed data, so that staff-provided course information can be published without an admin UI.

**Acceptance criteria**

- **AC-6.1.1** Course and batch data are defined in a structured, human-readable file format held in version control.
- **AC-6.1.2** A documented command loads or updates the catalog from that file.
- **AC-6.1.3** The command is idempotent — re-running it with unchanged data produces no changes.
- **AC-6.1.4** The command validates its input and fails cleanly with actionable messages, making no partial writes.
- **AC-6.1.5** Reducing a batch's capacity below its current active enrolment count is rejected.
- **AC-6.1.6** The command can be run against production safely by someone following the documented runbook.

#### US-6.2 — Export enrolments `M`

> As MIM staff, I want a list of who has enrolled in what, so that I can act on it operationally.

**Acceptance criteria**

- **AC-6.2.1** A documented command exports enrolments to CSV.
- **AC-6.2.2** The export includes: student reference, full name, email, phone, course code, course title, batch name, enrolment status, enrolled date, withdrawn date.
- **AC-6.2.3** The export can be filtered by course, batch and date range.
- **AC-6.2.4** Running an export writes an audit entry, since it constitutes bulk access to personal data.
- **AC-6.2.5** The runbook states where exports may be stored and how long they may be retained.

---

### E7 — Platform Foundations

#### US-7.1 — Role model `M`

**Acceptance criteria**

- **AC-7.1.1** The `role` enum includes all roles listed in §4.4 from Phase 1.
- **AC-7.1.2** Authorisation is enforced server-side on every protected route; hiding a UI control is never the only control.
- **AC-7.1.3** All Phase 1 self-registrations receive `role = STUDENT`. No path exists for a user to obtain any other role through the UI or API.

#### US-7.2 — Audit logging `M`

**Acceptance criteria**

- **AC-7.2.1** These actions are audited: registration, email verification, login success, login failure, logout, password reset request, password reset completion, password change, profile update, enrolment, withdrawal, data export.
- **AC-7.2.2** Each entry records actor, action, entity type and id, timestamp, IP address.
- **AC-7.2.3** Audit entries are append-only; the application exposes no path to modify or delete them.
- **AC-7.2.4** Passwords, tokens and full identity-document numbers are never written to the audit log.

#### US-7.3 — Error handling `M`

**Acceptance criteria**

- **AC-7.3.1** Unhandled errors return a branded error page, never a stack trace or framework debug output.
- **AC-7.3.2** Errors are logged server-side with a correlation identifier that is also shown to the user, so support can trace a reported problem.
- **AC-7.3.3** 404 and 403 pages offer a route back to the catalog.

#### US-7.4 — Analytics instrumentation `S`

**Acceptance criteria**

- **AC-7.4.1** These events are captured: catalog viewed, course detail viewed, registration started, registration completed, email verified, enrolment started, enrolment completed, enrolment failed (with reason), withdrawal completed.
- **AC-7.4.2** Events carry enough dimension to compute every metric in §3.
- **AC-7.4.3** Analytics respects the privacy notice and any cookie-consent requirement in force.

---

## 8. Non-Functional Requirements

### 8.1 Performance

| Requirement | Target |
|---|---|
| Catalog page load (p95, broadband) | ≤ 2.0s to interactive |
| Course detail page load (p95) | ≤ 1.5s to interactive |
| Enrolment transaction (p95, server-side) | ≤ 500ms |
| Search response (p95) | ≤ 800ms |

Baseline assumption: fewer than 1,000 registered students; peak concurrency under 100 simultaneous users; enrolment bursts concentrated at intake opening.

### 8.2 Availability

- Target 99.5% monthly uptime, excluding announced maintenance.
- Maintenance windows scheduled outside 08:00–20:00 Asia/Colombo.
- Daily automated database backups retained 30 days, with a **restore procedure that has been tested**, not merely documented.

### 8.3 Security

- All traffic over HTTPS; HTTP redirects to HTTPS; HSTS enabled.
- Passwords hashed with a memory-hard algorithm (Argon2id or bcrypt with an appropriate cost factor).
- Protection against the OWASP Top 10, specifically: parameterised queries, output encoding, CSRF tokens, secure session handling, and access-control checks on every protected route.
- Security headers set: `Content-Security-Policy`, `X-Content-Type-Options`, `Referrer-Policy`, `X-Frame-Options`.
- Secrets held in environment configuration, never in version control.
- Dependency vulnerability scanning in CI.
- Rate limiting on all authentication and enrolment endpoints.

### 8.4 Privacy and data protection

- The system collects personal data including identity-document numbers and dates of birth. A published privacy notice must state what is collected, why, how long it is retained, and who it is shared with.
- Identity-document numbers are masked in all UI display except on the owner's own profile.
- A documented process exists for a student to request access to, correction of, or deletion of their data.
- Personal data is not sent to third-party analytics.
- Applicable Sri Lankan data protection obligations are to be confirmed with MIM before launch (see §11, OQ-4).

### 8.5 Accessibility

- WCAG 2.1 Level AA for all Phase 1 screens.
- Full keyboard operability with a visible focus indicator.
- Semantic headings, labelled form controls, and error messages programmatically associated with their fields.
- Colour is never the sole carrier of meaning — seat availability in particular must be distinguishable without colour.
- Verified with an automated checker plus a manual keyboard and screen-reader pass before release.

### 8.6 Browser and device support

- Latest two major versions of Chrome, Safari, Firefox and Edge.
- Responsive from 320px to 1920px width.
- Mobile web is a first-class target — a substantial share of Sri Lankan students will use the portal primarily on a phone, and Phase 1's mobile-web quality directly informs the Phase 8 native decision.

### 8.7 Maintainability

- Automated tests covering, at minimum: the enrolment concurrency guarantee (AC-4.1.4), the full authentication flow, and every validation rule in §7.
- Continuous integration runs the test suite and vulnerability scan on every change.
- API design must anticipate the Phase 8 mobile client — business logic lives server-side, not in the web front-end.

### 8.8 Localisation

- Phase 1 ships in English only.
- All user-facing strings are externalised from code so that Sinhala and Tamil can be added without refactoring.
- Dates display in the Asia/Colombo timezone with an unambiguous format (e.g. `15 Jan 2027`, never `01/15/27`).

---

## 9. Assumptions

| # | Assumption | Risk if wrong |
|---|---|---|
| A1 | MIM can supply complete, accurate course and intake data before launch | Catalog launches thin or inaccurate |
| A2 | Instant enrolment without staff approval is acceptable to MIM's registry | Rework to an approval workflow |
| A3 | Enrolment carries no payment obligation at the point of enrolment | Enrolment records become financially meaningful and need Phase 6 sooner |
| A4 | Staff will act on enrolment exports manually until Phase 2 | Operational bottleneck; students enrol but nothing happens |
| A5 | A transactional email provider is available and MIM's domain can be configured for it (SPF/DKIM/DMARC) | Verification emails land in spam; funnel collapses |
| A6 | The legacy LMS continues to operate unchanged through Phase 1 | Two systems of record diverge |
| A7 | No formal admissions or entry-qualification check is required before enrolment | Ineligible students enrol; manual unwind needed |

---

## 10. Risks

| # | Risk | Impact | Likelihood | Mitigation |
|---|---|---|---|---|
| R1 | Over-enrolment through a race condition on the last seat | High | Medium | AC-4.1.4 atomic capacity check; explicit concurrency test in CI |
| R2 | Verification emails treated as spam, blocking the funnel | High | Medium | Reputable provider; SPF/DKIM/DMARC configured and verified pre-launch; monitor delivery rate |
| R3 | Bot registrations polluting the student table | Medium | High | CAPTCHA, rate limiting, verification requirement before enrolment |
| R4 | Enrolments made in the portal never reach the legacy LMS | High | High | Documented daily operational runbook (§11); make Phase 2 admin module the immediate next priority |
| R5 | Seeded catalog goes stale because staff cannot edit it | Medium | High | Lightweight change-request process; time-box Phase 1 so Phase 2 follows quickly |
| R6 | Scope pressure to add "just one more" LMS feature | Medium | High | §2.2 non-goals treated as a review gate |
| R7 | Personal data (NIC, DOB) collected without a compliant privacy basis | High | Medium | Legal review before launch; OQ-4 |
| R8 | Students expect a full LMS after enrolling and find an empty portal | Medium | High | Explicit post-enrolment messaging about what happens next and where course delivery occurs |

---

## 11. Open Questions

| # | Question | Owner | Needed by |
|---|---|---|---|
| OQ-1 | What is the operational runbook for getting a portal enrolment into the legacy LMS, and who owns it daily? | MIM registry | Before launch |
| OQ-2 | Is `student_reference` allowed to be portal-generated, or must it match the legacy LMS numbering scheme? | MIM registry | Before build |
| OQ-3 | Should enrolment be blocked for applicants who do not meet stated entry requirements, or is it self-declared? | MIM academic | Before build |
| OQ-4 | What Sri Lankan data-protection obligations apply, and who signs off the privacy notice? | MIM management / legal | Before launch |
| OQ-5 | Is fee information displayed as text only, or must it be structured for Phase 6 payments? | MIM finance | Before build |
| OQ-6 | Should a waitlist exist for full batches, or is "Full" terminal for Phase 1? | Product | Before build |
| OQ-7 | What is the withdrawal cut-off policy, and does withdrawal carry any financial consequence? | MIM registry | Before build |
| OQ-8 | Does the catalog need to be indexed by search engines, or should it be `noindex` until content is approved? | MIM marketing | Before launch |
| OQ-9 | What is the target Phase 1 launch date, and does it need to align with a specific intake? | Product | Immediately |

---

## 12. Appendix A — Proposal Coverage Map

Every functional area from the original *MIM LMS Mobile Application* proposal, mapped to its phase. This exists so nothing is silently dropped.

| Proposal section | Area | Phase |
|---|---|---|
| 4.1 | User authentication, roles, sessions | **1** |
| 5.1 | Student dashboard | **1** (enrolment-scoped) / 3 (full) |
| 5.2 | My courses | **1** (enrolments) / 3 (delivery) |
| 5.3 | Learning materials | 3 |
| 6 | Assignment management | 4 |
| 7 | Assessment management (MCQ + upload) | 4 |
| 8 | Schedule management | 3 |
| 9 | Examination management | 5 |
| 10 | Attendance management | 5 |
| 11 | Results management | 5 |
| 12 | Payment management | 6 |
| 13 | Communication module | 7 |
| 14 | Notification management | **1** (transactional email) / 7 (full) |
| 15 | Lecturer module | 3 |
| 16 | Admin / coordinator module | 2 |
| 17 | Student management | 2 |
| 18 | Lecturer management | 2 |
| 19 | Course & batch management | **1** (seeded) / 2 (admin UI) |
| 20 | Finance administration | 6 |
| 21 | Result approval chain | 5 |
| 22 | Profile & account management | **1** |
| — | Gamification & achievements | 7 |
| — | Native mobile applications | 8 |

## 13. Appendix B — Glossary

| Term | Meaning |
|---|---|
| **Course** | A programme of study offered by MIM, e.g. "Diploma in Business Management" |
| **Batch** | A dated instance of a course with its own capacity, e.g. "January 2027 Intake". Enrolment is always against a batch |
| **Intake** | Used interchangeably with batch in student-facing copy |
| **Enrolment** | The record linking a student to a batch |
| **Student reference** | The human-readable identifier issued to a student on registration |
| **Legacy LMS** | The existing MIM Learning Management System, running in parallel through Phase 1 |
