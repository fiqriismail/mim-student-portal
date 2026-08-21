---
id: BE-7.3
title: "Error handling"
layer: backend
epic: "E7 — Platform Foundations"
prd_ref: US-7.3
priority: M
status: not-started
depends_on: []
---

# BE-7.3 — Error handling

> Platform foundation — no user-facing story text in the PRD; the API-side half of error handling.

**Epic:** E7 — Platform Foundations · **PRD reference:** US-7.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Map unhandled errors to a safe, correlated response.

## Key acceptance criteria

- Unhandled errors never return a stack trace or framework debug output (AC-7.3.1).
- Errors are logged server-side with a correlation identifier that is also returned to the caller, so support can trace a reported problem (AC-7.3.2).

Full acceptance criteria: US-7.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

_None — foundational story._

## Related

- [FE-7.3](../frontend/FE-7.3.md) — the frontend counterpart of this story.
