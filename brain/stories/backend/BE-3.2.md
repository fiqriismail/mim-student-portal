---
id: BE-3.2
title: "Search and filter"
layer: backend
epic: "E3 — Course Catalog"
prd_ref: US-3.2
priority: S
status: not-started
depends_on: ["BE-3.1"]
---

# BE-3.2 — Search and filter

> As a prospective student, I want to narrow the list, so that I can find relevant courses quickly.

**Epic:** E3 — Course Catalog · **PRD reference:** US-3.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** S · **Layer:** backend

## Scope

Support search and filter query parameters on the catalog endpoint.

## Key acceptance criteria

- Free-text search matches title, code, short description — case-insensitive, partial-word (AC-3.2.1).
- Filters: delivery mode, availability, intake start month — combined with AND logic (AC-3.2.2, AC-3.2.3).

Full acceptance criteria: US-3.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-3.1](../backend/BE-3.1.md)

## Related

- [FE-3.2](../frontend/FE-3.2.md) — the frontend counterpart of this story.
