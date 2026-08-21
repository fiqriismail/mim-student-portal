---
id: BE-2.1
title: "View profile"
layer: backend
epic: "E2 — Student Profile"
prd_ref: US-2.1
priority: M
status: not-started
depends_on: ["BE-1.3"]
---

# BE-2.1 — View profile

> As a student, I want to see my profile, so that I can confirm MIM holds the right details.

**Epic:** E2 — Student Profile · **PRD reference:** US-2.1 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Expose the authenticated student's own profile.

## Key acceptance criteria

- Returns full name, student reference, email, phone, DOB, NIC/passport, address, highest qualification, account status, creation date (AC-2.1.1).

Full acceptance criteria: US-2.1 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.3](../backend/BE-1.3.md)

## Related

- [FE-2.1](../frontend/FE-2.1.md) — the frontend counterpart of this story.
