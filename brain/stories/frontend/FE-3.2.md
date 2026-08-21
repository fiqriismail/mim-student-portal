---
id: FE-3.2
title: "Search and filter"
layer: frontend
epic: "E3 — Course Catalog"
prd_ref: US-3.2
priority: S
status: not-started
depends_on: ["BE-3.2", "FE-3.1"]
---

# FE-3.2 — Search and filter

> As a prospective student, I want to narrow the list, so that I can find relevant courses quickly.

**Epic:** E3 — Course Catalog · **PRD reference:** US-3.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** S · **Layer:** frontend

## Scope

Build the search box and filter controls on the catalog page.

## Key acceptance criteria

- Active filters reflected in the URL query string so a filtered view can be shared/bookmarked (AC-3.2.4).
- "Clear all" resets to the unfiltered catalog; no-results state names the active filters and offers to clear them (AC-3.2.5, AC-3.2.6).

Full acceptance criteria: US-3.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-3.2](../backend/BE-3.2.md)
- [FE-3.1](../frontend/FE-3.1.md)

## Related

- [BE-3.2](../backend/BE-3.2.md) — the backend counterpart of this story.
