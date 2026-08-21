---
id: FE-3.3
title: "View course detail"
layer: frontend
epic: "E3 — Course Catalog"
prd_ref: US-3.3
priority: M
status: not-started
depends_on: ["BE-3.3", "FE-3.1"]
---

# FE-3.3 — View course detail

> As a prospective student, I want full information about a course, so that I can decide whether to enrol.

**Epic:** E3 — Course Catalog · **PRD reference:** US-3.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the course detail page as a Server Component, including its SEO metadata (architecture §5.1).

## Key acceptance criteria

- A batch at capacity shows "Full" with a disabled, accessibly-explained enrol control (AC-3.3.4).
- Unauthenticated visitor's "Enrol" control routes to register/login and returns here afterwards (AC-3.3.5).
- 404 page links back to the catalog (AC-3.3.6); page carries title/description/canonical URL/Open Graph metadata (AC-3.3.7).

Full acceptance criteria: US-3.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-3.3](../backend/BE-3.3.md)
- [FE-3.1](../frontend/FE-3.1.md)

## Related

- [BE-3.3](../backend/BE-3.3.md) — the backend counterpart of this story.
