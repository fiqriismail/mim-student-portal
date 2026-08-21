---
id: BE-1.2
title: "Email verification"
layer: backend
epic: "E1 — Account & Identity"
prd_ref: US-1.2
priority: M
status: not-started
depends_on: ["BE-1.1"]
---

# BE-1.2 — Email verification

> As a registered user, I want to verify my email address, so that my account becomes active.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Issue and consume single-use verification tokens, and gate enrolment on verification status.

## Key acceptance criteria

- Verification link carries a high-entropy token; only its hash is stored (AC-1.2.1).
- Valid unconsumed link: sets `email_verified_at`, `status=ACTIVE`, marks the token consumed, signs the user in (AC-1.2.2).
- Expired/consumed and invalid/unrecognised tokens both show the same generic failure — no distinction exposed (AC-1.2.3, AC-1.2.4).
- Resend invalidates any previous unconsumed token; rate-limited to 3 requests/account/hour (AC-1.2.5, AC-1.2.6).
- A PENDING_VERIFICATION user may sign in and browse but not enrol (AC-1.2.7).

Full acceptance criteria: US-1.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.1](../backend/BE-1.1.md)

## Related

- [FE-1.2](../frontend/FE-1.2.md) — the frontend counterpart of this story.
