---
id: BE-1.1
title: "Self-registration"
layer: backend
epic: "E1 — Account & Identity"
prd_ref: US-1.1
priority: M
status: not-started
depends_on: []
---

# BE-1.1 — Self-registration

> As a prospective student, I want to create an account with my email and a password, so that I can enrol in a course.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Handle the registration request end-to-end: validate input, enforce uniqueness without disclosing account existence, create the User/StudentProfile records, and kick off email verification.

## Key acceptance criteria

- Case-insensitive unique email; a duplicate returns a generic, non-disclosing field error (AC-1.1.2).
- Password ≥ 10 characters, no other complexity rule enforced (AC-1.1.3).
- On success: create `User` (role=STUDENT, status=PENDING_VERIFICATION), `StudentProfile` with a generated `student_reference`, issue a 24h EMAIL_VERIFICATION token, send the verification email (AC-1.1.6).
- Passwords stored only as a salted, memory-hard hash (Argon2id/bcrypt); never logged in plaintext (AC-1.1.8).
- Registration rate-limited to 5 attempts/IP/hour, returns HTTP 429 (AC-1.1.9).

Full acceptance criteria: US-1.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

_None — foundational story._

## Related

- [FE-1.1](../frontend/FE-1.1.md) — the frontend counterpart of this story.
