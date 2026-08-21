---
id: BE-5.1
title: "Account emails"
layer: backend
epic: "E5 — Notifications"
prd_ref: US-5.1
priority: M
status: not-started
depends_on: ["BE-1.1", "BE-1.2", "BE-1.5", "BE-2.3"]
---

# BE-5.1 — Account emails

> As a student, I want email confirmation of account actions, so that I can complete them and detect anything unexpected.

**Epic:** E5 — Notifications · **PRD reference:** US-5.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Send the account-lifecycle transactional emails.

## Key acceptance criteria

- Emails: verification, reset request, reset confirmation, password-change confirmation (AC-5.1.1).
- Every email states it's from MIM, what triggered it, and what to do if unexpected (AC-5.1.2); renders legibly as plain text and HTML (AC-5.1.3).
- Links are absolute HTTPS on the canonical domain (AC-5.1.4); delivery failures are logged with enough context to diagnose, and never leave the account inconsistent (AC-5.1.5).

Full acceptance criteria: US-5.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.1](../backend/BE-1.1.md)
- [BE-1.2](../backend/BE-1.2.md)
- [BE-1.5](../backend/BE-1.5.md)
- [BE-2.3](../backend/BE-2.3.md)

## Related

_No paired story on the other layer._
