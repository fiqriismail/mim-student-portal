---
id: FE-4.2
title: "View my enrolments"
layer: frontend
epic: "E4 — Enrolment"
prd_ref: US-4.2
priority: M
status: not-started
depends_on: ["BE-4.2", "FE-1.3"]
---

# FE-4.2 — View my enrolments

> As a student, I want to see the courses I'm enrolled in, so that I know where I stand.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the "My Enrolments" list screen.

## Key acceptance criteria

- ACTIVE entries first, then WITHDRAWN; each shows course title/code, batch name, start/end dates, status, enrolled date, and links to the course detail page (AC-4.2.1, AC-4.2.2, AC-4.2.3).
- Empty state prompts the student to browse the catalog (AC-4.2.4).

Full acceptance criteria: US-4.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.2](../backend/BE-4.2.md)
- [FE-1.3](../frontend/FE-1.3.md)

## Related

- [BE-4.2](../backend/BE-4.2.md) — the backend counterpart of this story.
