---
id: BE-2.2
title: "Edit profile"
layer: backend
epic: "E2 — Student Profile"
prd_ref: US-2.2
priority: M
status: not-started
depends_on: ["BE-2.1"]
---

# BE-2.2 — Edit profile

> As a student, I want to update my details, so that my records stay accurate.

**Epic:** E2 — Student Profile · **PRD reference:** US-2.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Persist profile edits with server-side validation and a field-level audit trail.

## Key acceptance criteria

- Editable: full name, phone, DOB, NIC/passport, address, highest qualification. Email is not editable in Phase 1 (AC-2.2.1, AC-2.2.2).
- DOB must be a valid past date implying age ≥ 16 at entry (AC-2.2.3).
- Successful save writes an audit entry recording which fields changed — not their values (AC-2.2.4).

Full acceptance criteria: US-2.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-2.1](../backend/BE-2.1.md)

## Related

- [FE-2.2](../frontend/FE-2.2.md) — the frontend counterpart of this story.
