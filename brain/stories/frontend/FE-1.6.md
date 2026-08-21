---
id: FE-1.6
title: "Session management"
layer: frontend
epic: "E1 — Account & Identity"
prd_ref: US-1.6
priority: M
status: not-started
depends_on: ["BE-1.6"]
---

# FE-1.6 — Session management

> As a student, I want my session handled securely, so that my account is protected.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.6 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Implement the BFF session cookie: Next.js Route Handlers seal/unseal the browser session and attach the API token server-side — see the architecture doc §6 for the full design.

## Key acceptance criteria

- Session cookie is `HttpOnly`, `Secure`, `SameSite=Lax` (AC-1.6.1).
- Same-origin CSRF protection (double-submit or synchroniser token) on every mutating Route Handler (AC-1.6.3).
- Idle-session expiry redirects to login with an explanatory message, preserving the originally requested destination (AC-1.6.4).

Full acceptance criteria: US-1.6 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.6](../backend/BE-1.6.md)

## Related

- [BE-1.6](../backend/BE-1.6.md) — the backend counterpart of this story.
