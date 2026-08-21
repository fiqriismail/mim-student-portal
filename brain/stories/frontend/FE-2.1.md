---
id: FE-2.1
title: "View profile"
layer: frontend
epic: "E2 — Student Profile"
prd_ref: US-2.1
priority: M
status: not-started
depends_on: ["BE-2.1", "FE-1.3"]
---

# FE-2.1 — View profile

> As a student, I want to see my profile, so that I can confirm MIM holds the right details.

**Epic:** E2 — Student Profile · **PRD reference:** US-2.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the profile view screen.

## Key acceptance criteria

- `student_reference` shown prominently, not editable (AC-2.1.2).
- Never-captured fields show "Not provided" with an inline prompt to add them, not blank space (AC-2.1.3).

Full acceptance criteria: US-2.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-2.1](../backend/BE-2.1.md)
- [FE-1.3](../frontend/FE-1.3.md)

## Related

- [BE-2.1](../backend/BE-2.1.md) — the backend counterpart of this story.
