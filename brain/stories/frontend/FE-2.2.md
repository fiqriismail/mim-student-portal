---
id: FE-2.2
title: "Edit profile"
layer: frontend
epic: "E2 — Student Profile"
prd_ref: US-2.2
priority: M
status: not-started
depends_on: ["BE-2.2", "FE-2.1"]
---

# FE-2.2 — Edit profile

> As a student, I want to update my details, so that my records stay accurate.

**Epic:** E2 — Student Profile · **PRD reference:** US-2.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the profile edit form.

## Key acceptance criteria

- Email field shown as locked, with copy explaining changes require contacting MIM (AC-2.2.2).
- Validation errors preserve all entered values (AC-2.2.5).

Full acceptance criteria: US-2.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-2.2](../backend/BE-2.2.md)
- [FE-2.1](../frontend/FE-2.1.md)

## Related

- [BE-2.2](../backend/BE-2.2.md) — the backend counterpart of this story.
