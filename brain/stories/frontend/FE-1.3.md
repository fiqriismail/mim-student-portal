---
id: FE-1.3
title: "Login"
layer: frontend
epic: "E1 — Account & Identity"
prd_ref: US-1.3
priority: M
status: not-started
depends_on: ["BE-1.3"]
---

# FE-1.3 — Login

> As a student, I want to sign in, so that I can access my enrolments and profile.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the login screen and the redirect-after-login behaviour.

## Key acceptance criteria

- Email + password form, single generic error message on failure (AC-1.3.2).
- "Remember me" control (AC-1.3.5).
- After login, land on the dashboard, or on the originally requested protected page if redirected here first (AC-1.3.7).

Full acceptance criteria: US-1.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.3](../backend/BE-1.3.md)

## Related

- [BE-1.3](../backend/BE-1.3.md) — the backend counterpart of this story.
