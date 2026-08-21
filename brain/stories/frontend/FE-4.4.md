---
id: FE-4.4
title: "Student dashboard"
layer: frontend
epic: "E4 — Enrolment"
prd_ref: US-4.4
priority: M
status: not-started
depends_on: ["BE-4.4", "FE-1.3"]
---

# FE-4.4 — Student dashboard

> As a signed-in student, I want a landing page that orients me, so that I can pick up where I left off.

**Epic:** E4 — Enrolment · **PRD reference:** US-4.4 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the dashboard screen.

## Key acceptance criteria

- Verification banner (with resend) when PENDING_VERIFICATION; profile-completion prompt when DOB/NIC/address missing (AC-4.4.3, AC-4.4.4).
- A clear route to the catalog; no "coming soon" tiles for features not yet built (AC-4.4.5, AC-4.4.6).

Full acceptance criteria: US-4.4 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-4.4](../backend/BE-4.4.md)
- [FE-1.3](../frontend/FE-1.3.md)

## Related

- [BE-4.4](../backend/BE-4.4.md) — the backend counterpart of this story.
