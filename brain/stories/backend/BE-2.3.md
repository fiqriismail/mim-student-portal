---
id: BE-2.3
title: "Change password"
layer: backend
epic: "E2 — Student Profile"
prd_ref: US-2.3
priority: M
status: not-started
depends_on: ["BE-1.3"]
---

# BE-2.3 — Change password

> As a signed-in student, I want to change my password, so that I can keep my account secure.

**Epic:** E2 — Student Profile · **PRD reference:** US-2.3 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** backend

## Scope

Verify the current password and rotate sessions on change.

## Key acceptance criteria

- Incorrect current password returns an error and changes nothing (AC-2.3.2).
- New password satisfies AC-1.1.3 and must differ from the current one (AC-2.3.3).
- Successful change invalidates all other sessions (keeps the current one), sends a confirmation email, writes an audit entry (AC-2.3.4).

Full acceptance criteria: US-2.3 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.3](../backend/BE-1.3.md)

## Related

- [FE-2.3](../frontend/FE-2.3.md) — the frontend counterpart of this story.
