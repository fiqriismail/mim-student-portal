---
id: BE-7.1
title: "Role model"
layer: backend
epic: "E7 — Platform Foundations"
prd_ref: US-7.1
priority: M
status: not-started
depends_on: []
---

# BE-7.1 — Role model

> Platform foundation — no user-facing story text in the PRD; establishes the role model every later phase builds on.

**Epic:** E7 — Platform Foundations · **PRD reference:** US-7.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Introduce the full role enum from day one and enforce authorization server-side everywhere.

## Key acceptance criteria

- `role` enum includes every role listed in PRD §4.4, from Phase 1 (AC-7.1.1).
- Authorization is enforced server-side on every protected route; a hidden UI control is never the only control (AC-7.1.2).
- All Phase 1 self-registrations receive role=STUDENT; no UI/API path grants any other role (AC-7.1.3).

Full acceptance criteria: US-7.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

_None — foundational story._

## Related

_No paired story on the other layer._
