---
id: BE-1.5
title: "Password reset"
layer: backend
epic: "E1 — Account & Identity"
prd_ref: US-1.5
priority: M
status: not-started
depends_on: ["BE-1.1", "BE-1.6"]
---

# BE-1.5 — Password reset

> As a student who has forgotten my password, I want to reset it by email, so that I can regain access.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.5 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Issue and consume password-reset tokens, and invalidate sessions on completion.

## Key acceptance criteria

- "Forgot password" always returns the same confirmation, whether or not the account exists (AC-1.5.1).
- If the account exists, issue a 60-minute PASSWORD_RESET token and email it (AC-1.5.2); requesting again invalidates the prior unconsumed token (AC-1.5.3).
- Completing a reset consumes the token, updates the password hash, invalidates all existing sessions, and writes an audit entry (AC-1.5.5).
- A confirmation email follows a successful reset (AC-1.5.6).
- Rate limits: 3 requests/email/hour, 10/IP/hour (AC-1.5.7).

Full acceptance criteria: US-1.5 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.1](../backend/BE-1.1.md)
- [BE-1.6](../backend/BE-1.6.md)

## Related

- [FE-1.5](../frontend/FE-1.5.md) — the frontend counterpart of this story.
