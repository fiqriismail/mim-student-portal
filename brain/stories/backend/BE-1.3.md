---
id: BE-1.3
title: "Login"
layer: backend
epic: "E1 — Account & Identity"
prd_ref: US-1.3
priority: M
status: not-started
depends_on: ["BE-1.1", "BE-1.6"]
---

# BE-1.3 — Login

> As a student, I want to sign in, so that I can access my enrolments and profile.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Authenticate credentials, issue the session-backing token, and enforce brute-force protection.

## Key acceptance criteria

- A failed login always returns the same generic message, regardless of whether the email exists (AC-1.3.2).
- After 5 consecutive failures, further attempts are throttled with exponential backoff for 15 minutes — never a permanent lock (AC-1.3.3).
- Successful login records `last_login_at` and writes an audit entry with IP address (AC-1.3.4).
- "Remember me" extends session lifetime to 30 days; otherwise sessions expire after 24h of inactivity (AC-1.3.5).
- A SUSPENDED user cannot sign in and is told to contact MIM (AC-1.3.6).

Full acceptance criteria: US-1.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.1](../backend/BE-1.1.md)
- [BE-1.6](../backend/BE-1.6.md)

## Related

- [FE-1.3](../frontend/FE-1.3.md) — the frontend counterpart of this story.
