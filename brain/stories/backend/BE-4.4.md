---
id: BE-4.4
title: "Student dashboard"
layer: backend
epic: "E4 — Enrolment"
prd_ref: US-4.4
priority: M
status: not-started
depends_on: ["BE-4.1", "BE-2.1"]
---

# BE-4.4 — Student dashboard

> As a signed-in student, I want a landing page that orients me, so that I can pick up where I left off.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.4 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Aggregate the data the dashboard needs in one call.

## Key acceptance criteria

- Returns the student's name, reference, active enrolments with their next relevant date, verification status, and profile-completeness flags (AC-4.4.1–AC-4.4.4).

Full acceptance criteria: US-4.4 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.1](../backend/BE-4.1.md)
- [BE-2.1](../backend/BE-2.1.md)

## Related

- [FE-4.4](../frontend/FE-4.4.md) — the frontend counterpart of this story.
