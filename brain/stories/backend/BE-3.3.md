---
id: BE-3.3
title: "View course detail"
layer: backend
epic: "E3 — Course Catalog"
prd_ref: US-3.3
priority: M
status: not-started
depends_on: ["BE-3.1"]
---

# BE-3.3 — View course detail

> As a prospective student, I want full information about a course, so that I can decide whether to enrol.

**Epic:** E3 — Course Catalog · **PRD reference:** US-3.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Serve a single course's detail, including its OPEN batches and computed remaining places.

## Key acceptance criteria

- Publicly accessible at a stable slug URL (AC-3.3.1).
- Returns full description, duration, mode, entry requirements, fees, all OPEN batches with name/start/end/capacity/remaining places (AC-3.3.2, AC-3.3.3).
- DRAFT, ARCHIVED or non-existent courses return 404 (AC-3.3.6).

Full acceptance criteria: US-3.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-3.1](../backend/BE-3.1.md)

## Related

- [FE-3.3](../frontend/FE-3.3.md) — the frontend counterpart of this story.
