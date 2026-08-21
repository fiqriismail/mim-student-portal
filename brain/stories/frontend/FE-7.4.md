---
id: FE-7.4
title: "Analytics instrumentation"
layer: frontend
epic: "E7 — Platform Foundations"
prd_ref: US-7.4
priority: S
status: not-started
depends_on: ["FE-3.1", "FE-4.1"]
---

# FE-7.4 — Analytics instrumentation

> Platform foundation — no user-facing story text in the PRD; the client-side event dispatch that feeds PRD §3's success metrics.

**Epic:** E7 — Platform Foundations · **PRD reference:** US-7.4 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** S · **Layer:** frontend

## Scope

Dispatch the events PRD §3's metrics are computed from. (Note: this story covers client-side dispatch only — a server-side ingestion/sink story is out of this scope and can be added if one becomes necessary.)

## Key acceptance criteria

- Events: catalog viewed, course detail viewed, registration started/completed, email verified, enrolment started/completed/failed (with reason), withdrawal completed (AC-7.4.1).
- Events carry enough dimension to compute every metric in PRD §3 (AC-7.4.2).
- Respects the privacy notice and any cookie-consent requirement in force; no personal data forwarded to third-party analytics (AC-7.4.3, PRD §8.4).

Full acceptance criteria: US-7.4 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [FE-3.1](../frontend/FE-3.1.md)
- [FE-4.1](../frontend/FE-4.1.md)

## Related

_No paired story on the other layer._
