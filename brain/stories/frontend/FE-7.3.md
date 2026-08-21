---
id: FE-7.3
title: "Error handling"
layer: frontend
epic: "E7 — Platform Foundations"
prd_ref: US-7.3
priority: M
status: not-started
depends_on: []
---

# FE-7.3 — Error handling

> Platform foundation — no user-facing story text in the PRD; the frontend-side half of error handling.

**Epic:** E7 — Platform Foundations · **PRD reference:** US-7.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the branded error/404/403 pages.

## Key acceptance criteria

- Unhandled errors render a branded error page, never a raw stack trace (AC-7.3.1).
- 404 and 403 pages offer a route back to the catalog (AC-7.3.3); the correlation ID from the API response is surfaced to the user.

Full acceptance criteria: US-7.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

_None — foundational story._

## Related

- [BE-7.3](../backend/BE-7.3.md) — the backend counterpart of this story.
