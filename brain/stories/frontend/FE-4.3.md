---
id: FE-4.3
title: "Withdraw from a batch"
layer: frontend
epic: "E4 — Enrolment"
prd_ref: US-4.3
priority: S
status: not-started
depends_on: ["BE-4.3", "FE-4.2"]
---

# FE-4.3 — Withdraw from a batch

> As a student, I want to withdraw from a course I enrolled in by mistake or no longer want, so that I am not held to it.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** S · **Layer:** frontend

## Scope

Build the withdrawal confirmation flow.

## Key acceptance criteria

- Confirmation step warns the place is released and re-enrolment depends on availability (AC-4.3.2).
- Past-start-date attempts are directed to contact MIM instead of being withdrawn in-app (AC-4.3.6).

Full acceptance criteria: US-4.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.3](../backend/BE-4.3.md)
- [FE-4.2](../frontend/FE-4.2.md)

## Related

- [BE-4.3](../backend/BE-4.3.md) — the backend counterpart of this story.
