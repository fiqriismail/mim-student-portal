---
title: Frontend Storyboard
layer: frontend
story_count: 19
---

# Frontend Storyboard

All frontend (Next.js) stories for Phase 1, grouped by PRD epic. Prefixed `FE-`. Each story links back to its PRD reference, its backend counterpart (where one exists), and the stories it depends on.

### E0 — Project Setup

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [FE-0.1](./FE-0.1.md) | Scaffold frontend app & workspace tooling | M | — | Done |

### E1 — Account & Identity

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [FE-1.1](./FE-1.1.md) | Self-registration | M | [BE-1.1](./BE-1.1.md) | Not started |
| [FE-1.2](./FE-1.2.md) | Email verification | M | [BE-1.2](./BE-1.2.md) | Not started |
| [FE-1.3](./FE-1.3.md) | Login | M | [BE-1.3](./BE-1.3.md) | Not started |
| [FE-1.4](./FE-1.4.md) | Logout | M | [BE-1.4](./BE-1.4.md) | Not started |
| [FE-1.5](./FE-1.5.md) | Password reset | M | [BE-1.5](./BE-1.5.md) | Not started |
| [FE-1.6](./FE-1.6.md) | Session management | M | [BE-1.6](./BE-1.6.md) | Not started |

### E2 — Student Profile

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [FE-2.1](./FE-2.1.md) | View profile | M | [BE-2.1](./BE-2.1.md), [FE-1.3](./FE-1.3.md) | Not started |
| [FE-2.2](./FE-2.2.md) | Edit profile | M | [BE-2.2](./BE-2.2.md), [FE-2.1](./FE-2.1.md) | Not started |
| [FE-2.3](./FE-2.3.md) | Change password | M | [BE-2.3](./BE-2.3.md), [FE-1.3](./FE-1.3.md) | Not started |

### E3 — Course Catalog

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [FE-3.1](./FE-3.1.md) | Browse the catalog | M | [BE-3.1](./BE-3.1.md) | Not started |
| [FE-3.2](./FE-3.2.md) | Search and filter | S | [BE-3.2](./BE-3.2.md), [FE-3.1](./FE-3.1.md) | Not started |
| [FE-3.3](./FE-3.3.md) | View course detail | M | [BE-3.3](./BE-3.3.md), [FE-3.1](./FE-3.1.md) | Not started |

### E4 — Enrolment

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [FE-4.1](./FE-4.1.md) | Enrol in a batch | M | [BE-4.1](./BE-4.1.md), [FE-3.3](./FE-3.3.md), [FE-1.3](./FE-1.3.md) | Not started |
| [FE-4.2](./FE-4.2.md) | View my enrolments | M | [BE-4.2](./BE-4.2.md), [FE-1.3](./FE-1.3.md) | Not started |
| [FE-4.3](./FE-4.3.md) | Withdraw from a batch | S | [BE-4.3](./BE-4.3.md), [FE-4.2](./FE-4.2.md) | Not started |
| [FE-4.4](./FE-4.4.md) | Student dashboard | M | [BE-4.4](./BE-4.4.md), [FE-1.3](./FE-1.3.md) | Not started |

### E7 — Platform Foundations

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [FE-7.3](./FE-7.3.md) | Error handling | M | — | Not started |
| [FE-7.4](./FE-7.4.md) | Analytics instrumentation | S | [FE-3.1](./FE-3.1.md), [FE-4.1](./FE-4.1.md) | Not started |

---

See also: [Backend Storyboard](../backend/STORYBOARD.md) · [Architecture](../../docs/ARCHITECTURE.md) · [PRD](../../docs/PRD.md)
