---
id: BE-1.6
title: "Session management"
layer: backend
epic: "E1 — Account & Identity"
prd_ref: US-1.6
priority: M
status: not-started
depends_on: ["BE-1.1"]
---

# BE-1.6 — Session management

> As a student, I want my session handled securely, so that my account is protected.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.6 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Own the server-side session/token model that both login and the frontend BFF rely on — see the auth strategy in the architecture doc (§6).

## Key acceptance criteria

- Session identifier/token is regenerated on login and on password change (AC-1.6.2).
- A `session_version` (or token-family) mechanism backs full invalidation of all sessions for a user in one write (used by AC-1.5.5, AC-2.3.4).
- All state-changing endpoints require the internal bearer token issued to the BFF — never reachable by a forged cross-site request (AC-1.6.3).

Full acceptance criteria: US-1.6 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.1](../backend/BE-1.1.md)

## Related

- [FE-1.6](../frontend/FE-1.6.md) — the frontend counterpart of this story.
