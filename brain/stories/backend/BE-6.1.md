---
id: BE-6.1
title: "Seed course data"
layer: backend
epic: "E6 — Catalog Seeding & Ops"
prd_ref: US-6.1
priority: M
status: not-started
depends_on: []
---

# BE-6.1 — Seed course data

> As a developer, I want to load and update the course catalog from version-controlled seed data, so that staff-provided course information can be published without an admin UI.

**Epic:** E6 — Catalog Seeding & Ops · **PRD reference:** US-6.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Build the catalog-seeding command that stands in for a Phase-1 admin UI.

## Key acceptance criteria

- Course/batch data defined in a structured, human-readable, version-controlled file format (AC-6.1.1).
- The command is idempotent — re-running with unchanged data is a no-op (AC-6.1.3).
- Validates input and fails cleanly with actionable messages, no partial writes (AC-6.1.4).
- Reducing a batch's capacity below its current active-enrolment count is rejected (AC-6.1.5).
- Documented runbook makes it safe to run against production (AC-6.1.6).

Full acceptance criteria: US-6.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

_None — foundational story._

## Related

_No paired story on the other layer._
