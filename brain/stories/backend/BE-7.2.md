---
id: BE-7.2
title: "Audit logging"
layer: backend
epic: "E7 — Platform Foundations"
prd_ref: US-7.2
priority: M
status: not-started
depends_on: []
---

# BE-7.2 — Audit logging

> Platform foundation — no user-facing story text in the PRD; the append-only audit trail every other story writes to.

**Epic:** E7 — Platform Foundations · **PRD reference:** US-7.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Build the shared `IAuditWriter` and its append-only storage — see architecture §9.

## Key acceptance criteria

- Audits: registration, verification, login success/failure, logout, reset request/completion, password change, profile update, enrolment, withdrawal, export (AC-7.2.1).
- Each entry records actor, action, entity type+id, timestamp, IP address (AC-7.2.2).
- Append-only — no update/delete path is exposed anywhere in the application (AC-7.2.3).
- Passwords, tokens and full identity-document numbers are never written to the audit log (AC-7.2.4).

Full acceptance criteria: US-7.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

_None — foundational story._

## Related

_No paired story on the other layer._
