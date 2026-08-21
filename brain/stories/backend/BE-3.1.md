---
id: BE-3.1
title: "Browse the catalog"
layer: backend
epic: "E3 — Course Catalog"
prd_ref: US-3.1
priority: M
status: not-started
depends_on: ["BE-6.1"]
---

# BE-3.1 — Browse the catalog

> As a prospective student, I want to browse available courses without signing in, so that I can decide whether MIM is right for me.

**Epic:** E3 — Course Catalog · **PRD reference:** US-3.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Serve the public course listing.

## Key acceptance criteria

- No authentication required; only PUBLISHED courses with ≥1 OPEN batch are returned (AC-3.1.1, AC-3.1.2, §6.2).
- Default sort: next intake start date ascending, no-open-intake courses sort last (AC-3.1.6).
- Paginated at 12/page (AC-3.1.5).

Full acceptance criteria: US-3.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-6.1](../backend/BE-6.1.md)

## Related

- [FE-3.1](../frontend/FE-3.1.md) — the frontend counterpart of this story.
