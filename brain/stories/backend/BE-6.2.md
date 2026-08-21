---
id: BE-6.2
title: "Export enrolments"
layer: backend
epic: "E6 — Catalog Seeding & Ops"
prd_ref: US-6.2
priority: M
status: not-started
depends_on: ["BE-4.1"]
---

# BE-6.2 — Export enrolments

> As MIM staff, I want a list of who has enrolled in what, so that I can act on it operationally.

**Epic:** E6 — Catalog Seeding & Ops · **PRD reference:** US-6.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Build the CSV export command staff use until Phase 2's admin UI exists.

## Key acceptance criteria

- Exports student reference, name, email, phone, course code/title, batch name, status, enrolled/withdrawn dates (AC-6.2.2).
- Filterable by course, batch, and date range (AC-6.2.3).
- Running an export writes an audit entry — it's bulk access to personal data (AC-6.2.4).
- Runbook states where exports may be stored and how long they may be retained (AC-6.2.5).

Full acceptance criteria: US-6.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.1](../backend/BE-4.1.md)

## Related

_No paired story on the other layer._
