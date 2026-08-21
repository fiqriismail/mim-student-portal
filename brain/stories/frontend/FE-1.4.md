---
id: FE-1.4
title: "Logout"
layer: frontend
epic: "E1 — Account & Identity"
prd_ref: US-1.4
priority: M
status: not-started
depends_on: ["BE-1.4"]
---

# FE-1.4 — Logout

> As a signed-in student, I want to sign out, so that my account is not accessible to someone else on this device.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.4 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Surface logout from primary navigation and handle the post-logout redirect.

## Key acceptance criteria

- Logout reachable from primary navigation on every authenticated page (AC-1.4.1).
- After logout, return to the public catalog with a confirmation message (AC-1.4.3).
- Browser back button after logout never renders authenticated content (AC-1.4.4).

Full acceptance criteria: US-1.4 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.4](../backend/BE-1.4.md)

## Related

- [BE-1.4](../backend/BE-1.4.md) — the backend counterpart of this story.
