---
id: FE-1.1
title: "Self-registration"
layer: frontend
epic: "E1 — Account & Identity"
prd_ref: US-1.1
priority: M
status: done
depends_on: ["BE-1.1"]
---

# FE-1.1 — Self-registration

> As a prospective student, I want to create an account with my email and a password, so that I can enrol in a course.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the registration screen: the form, its client-side validation, the CAPTCHA/challenge, and the post-submit redirect.

## Key acceptance criteria

- Form collects full name, email, phone, password, confirm password (AC-1.1.1); mismatch shows a field error without clearing either field (AC-1.1.4).
- Terms of Use / Privacy Notice checkbox blocks submission until ticked, both links open in a new tab (AC-1.1.5).
- Bot-abuse challenge (CAPTCHA or equivalent) that is screen-reader and keyboard accessible (AC-1.1.10).
- On success, redirect to a "check your email" page showing the address used and a resend control (AC-1.1.7).

Full acceptance criteria: US-1.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.1](../backend/BE-1.1.md)

## Related

- [BE-1.1](../backend/BE-1.1.md) — the backend counterpart of this story.
