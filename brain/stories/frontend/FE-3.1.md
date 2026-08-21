---
id: FE-3.1
title: "Browse the catalog"
layer: frontend
epic: "E3 — Course Catalog"
prd_ref: US-3.1
priority: M
status: not-started
depends_on: ["BE-3.1"]
---

# FE-3.1 — Browse the catalog

> As a prospective student, I want to browse available courses without signing in, so that I can decide whether MIM is right for me.

**Epic:** E3 — Course Catalog · **PRD reference:** US-3.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the public catalog page as a Server Component for SEO and fast first paint (architecture §5.1).

## Key acceptance criteria

- Each card shows title, code, short description, delivery mode, duration, next open-intake start date, seat-availability indicator (AC-3.1.3).
- Seat indicator: "Places available" / "Only N places left" (≤5) / "Full" — never colour-only (AC-3.1.4, §8.5).
- Accessible pagination controls; explanatory empty state; renders correctly from 320px width (AC-3.1.5, AC-3.1.7, AC-3.1.8).

Full acceptance criteria: US-3.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-3.1](../backend/BE-3.1.md)

## Related

- [BE-3.1](../backend/BE-3.1.md) — the backend counterpart of this story.
