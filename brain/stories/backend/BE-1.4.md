---
id: BE-1.4
title: "Logout"
layer: backend
epic: "E1 — Account & Identity"
prd_ref: US-1.4
priority: M
status: not-started
depends_on: ["BE-1.6"]
---

# BE-1.4 — Logout

> As a signed-in student, I want to sign out, so that my account is not accessible to someone else on this device.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.4 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Invalidate the session server-side on logout.

## Key acceptance criteria

- Logout invalidates the session server-side, not only by clearing the cookie (AC-1.4.2).

Full acceptance criteria: US-1.4 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.6](../backend/BE-1.6.md)

## Related

- [FE-1.4](../frontend/FE-1.4.md) — the frontend counterpart of this story.
