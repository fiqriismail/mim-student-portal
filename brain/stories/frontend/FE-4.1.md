---
id: FE-4.1
title: "Enrol in a batch"
layer: frontend
epic: "E4 — Enrolment"
prd_ref: US-4.1
priority: M
status: not-started
depends_on: ["BE-4.1", "FE-3.3", "FE-1.3"]
---

# FE-4.1 — Enrol in a batch

> As a verified student, I want to enrol in a course intake, so that my place is confirmed immediately.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the enrol confirmation flow and its outcome states.

## Key acceptance criteria

- Enrol control shown only to ACTIVE (verified) students; already-enrolled students see "You are already enrolled" instead of a control (AC-4.1.1, AC-4.1.5).
- Confirmation step shows course, batch, dates, fee before the student commits (AC-4.1.2).
- Success page shows course, batch, dates, student reference, links to "My Enrolments" and back to the catalog (AC-4.1.8).
- Generates a client-side idempotency key per attempt to pair with the backend's duplicate-submission guard (AC-4.1.12).

Full acceptance criteria: US-4.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.1](../backend/BE-4.1.md)
- [FE-3.3](../frontend/FE-3.3.md)
- [FE-1.3](../frontend/FE-1.3.md)

## Related

- [BE-4.1](../backend/BE-4.1.md) — the backend counterpart of this story.
