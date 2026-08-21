---
id: BE-5.2
title: "Enrolment emails"
layer: backend
epic: "E5 — Notifications"
prd_ref: US-5.2
priority: M
status: not-started
depends_on: ["BE-4.1", "BE-4.3"]
---

# BE-5.2 — Enrolment emails

> As a student, I want written confirmation of my enrolment, so that I have a record of it.

**Epic:** E5 — Notifications · **PRD reference:** US-5.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Send enrolment and withdrawal confirmation emails asynchronously.

## Key acceptance criteria

- Enrolment confirmation includes course title/code, batch name, dates, mode, student reference, MIM contact details (AC-5.2.1); withdrawal confirmation on withdrawal (AC-5.2.2).
- Queued and sent asynchronously — latency/failure never blocks or rolls back the enrolment transaction (AC-5.2.3).
- Failed sends retried with backoff at least 3 times before being recorded as failed (AC-5.2.4).

Full acceptance criteria: US-5.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.1](../backend/BE-4.1.md)
- [BE-4.3](../backend/BE-4.3.md)

## Related

_No paired story on the other layer._
