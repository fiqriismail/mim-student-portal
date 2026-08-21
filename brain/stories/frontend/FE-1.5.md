---
id: FE-1.5
title: "Password reset"
layer: frontend
epic: "E1 — Account & Identity"
prd_ref: US-1.5
priority: M
status: not-started
depends_on: ["BE-1.5"]
---

# FE-1.5 — Password reset

> As a student who has forgotten my password, I want to reset it by email, so that I can regain access.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.5 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the forgot-password and reset-password screens.

## Key acceptance criteria

- Forgot-password form: single email field, always shows the same confirmation (AC-1.5.1).
- Reset form enforces the same password rules as registration (AC-1.5.4, mirrors AC-1.1.3/AC-1.1.4).

Full acceptance criteria: US-1.5 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.5](../backend/BE-1.5.md)

## Related

- [BE-1.5](../backend/BE-1.5.md) — the backend counterpart of this story.
