---
id: BE-4.3
title: "Withdraw from a batch"
layer: backend
epic: "E4 — Enrolment"
prd_ref: US-4.3
priority: S
status: not-started
depends_on: ["BE-4.1"]
---

# BE-4.3 — Withdraw from a batch

> As a student, I want to withdraw from a course I enrolled in by mistake or no longer want, so that I am not held to it.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** S · **Layer:** backend

## Scope

Release a seat on withdrawal without deleting the enrolment record.

## Key acceptance criteria

- Only ACTIVE enrolments can be withdrawn; sets status=WITHDRAWN + withdrawn_at, record is kept (AC-4.3.1, AC-4.3.3).
- Released seat becomes immediately available; a FULL batch returns to OPEN (AC-4.3.4).
- Blocked after the batch start date (AC-4.3.6); a withdrawn student may re-enrol into the same batch if OPEN with capacity (AC-4.3.7).
- Sends a withdrawal notification email and writes an audit entry (AC-4.3.5).

Full acceptance criteria: US-4.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.1](../backend/BE-4.1.md)

## Related

- [FE-4.3](../frontend/FE-4.3.md) — the frontend counterpart of this story.
