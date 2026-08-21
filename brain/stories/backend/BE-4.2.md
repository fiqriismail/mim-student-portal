---
id: BE-4.2
title: "View my enrolments"
layer: backend
epic: "E4 — Enrolment"
prd_ref: US-4.2
priority: M
status: not-started
depends_on: ["BE-4.1"]
---

# BE-4.2 — View my enrolments

> As a student, I want to see the courses I'm enrolled in, so that I know where I stand.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Serve the caller's own enrolments only.

## Key acceptance criteria

- Only ever returns the signed-in student's own enrolments (AC-4.2.1).
- Requesting another student's enrolment by id returns 404, not 403 — no existence disclosure (AC-4.2.5).

Full acceptance criteria: US-4.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.1](../backend/BE-4.1.md)

## Related

- [FE-4.2](../frontend/FE-4.2.md) — the frontend counterpart of this story.
