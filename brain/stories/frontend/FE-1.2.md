---
id: FE-1.2
title: "Email verification"
layer: frontend
epic: "E1 — Account & Identity"
prd_ref: US-1.2
priority: M
status: not-started
depends_on: ["BE-1.2"]
---

# FE-1.2 — Email verification

> As a registered user, I want to verify my email address, so that my account becomes active.

**Epic:** E1 — Account & Identity · **PRD reference:** US-1.2 (see [`brain/docs/PRD.md`](../../docs/PRD.md)) · **Priority:** M · **Layer:** frontend

## Scope

Build the "check your email" and verification-outcome screens, and the in-context prompt shown when a PENDING_VERIFICATION user tries to enrol.

## Key acceptance criteria

- "Check your email" page: shows the address used, resend control (AC-1.1.7).
- Following the link either signs the user in and continues, or shows one generic explanatory failure page with a "request a new link" control (AC-1.2.3, AC-1.2.4).
- Attempting to enrol while unverified shows an inline verify prompt with a resend control, not a dead end (AC-1.2.7).

Full acceptance criteria: US-1.2 in [`brain/docs/PRD.md`](../../docs/PRD.md).

## Dependencies

- [BE-1.2](../backend/BE-1.2.md)

## Related

- [BE-1.2](../backend/BE-1.2.md) — the backend counterpart of this story.
