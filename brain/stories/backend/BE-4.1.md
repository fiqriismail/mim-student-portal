---
id: BE-4.1
title: "Enrol in a batch"
layer: backend
epic: "E4 — Enrolment"
prd_ref: US-4.1
priority: M
status: not-started
depends_on: ["BE-3.3", "BE-1.3", "BE-7.1", "BE-7.2"]
---

# BE-4.1 — Enrol in a batch

> As a verified student, I want to enrol in a course intake, so that my place is confirmed immediately.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

The highest-risk story in Phase 1 (PRD R1): atomically enforce seat capacity under concurrency. See architecture §7.3 for the transaction/locking design.

## Key acceptance criteria

- Capacity check + enrolment insert happen inside a single transaction with row-level locking; concurrent requests for the last seat yield exactly one success (AC-4.1.4).
- Rejects enrolment if the batch isn't OPEN, or the student already holds an ACTIVE enrolment in that batch (AC-4.1.5, AC-4.1.7).
- Writes an audit entry recording actor, batch, and remaining capacity after the operation (AC-4.1.10).
- When a batch reaches capacity its status flips to FULL, visible everywhere within one page load (AC-4.1.11).
- Duplicate submission (double-click/resubmit) never creates two enrolments — enforced by idempotency key or the DB uniqueness constraint, not client-side disabling alone (AC-4.1.12).

Full acceptance criteria: US-4.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-3.3](../backend/BE-3.3.md)
- [BE-1.3](../backend/BE-1.3.md)
- [BE-7.1](../backend/BE-7.1.md)
- [BE-7.2](../backend/BE-7.2.md)

## Related

- [FE-4.1](../frontend/FE-4.1.md) — the frontend counterpart of this story.
