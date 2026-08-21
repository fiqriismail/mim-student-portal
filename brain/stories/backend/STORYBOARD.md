---
title: Backend Storyboard
layer: backend
story_count: 24
---

# Backend Storyboard

All backend (ASP.NET Core API) stories for Phase 1, grouped by PRD epic. Prefixed `BE-`. Each story links back to its PRD reference and to the stories it depends on.

### E0 — Project Setup

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-0.1](./BE-0.1.md) | Scaffold backend solution | M | — | Done |

### E1 — Account & Identity

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-1.1](./BE-1.1.md) | Self-registration | M | — | Done |
| [BE-1.2](./BE-1.2.md) | Email verification | M | [BE-1.1](./BE-1.1.md) | Not started |
| [BE-1.3](./BE-1.3.md) | Login | M | [BE-1.1](./BE-1.1.md), [BE-1.6](./BE-1.6.md) | Not started |
| [BE-1.4](./BE-1.4.md) | Logout | M | [BE-1.6](./BE-1.6.md) | Not started |
| [BE-1.5](./BE-1.5.md) | Password reset | M | [BE-1.1](./BE-1.1.md), [BE-1.6](./BE-1.6.md) | Not started |
| [BE-1.6](./BE-1.6.md) | Session management | M | [BE-1.1](./BE-1.1.md) | Not started |

### E2 — Student Profile

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-2.1](./BE-2.1.md) | View profile | M | [BE-1.3](./BE-1.3.md) | Not started |
| [BE-2.2](./BE-2.2.md) | Edit profile | M | [BE-2.1](./BE-2.1.md) | Not started |
| [BE-2.3](./BE-2.3.md) | Change password | M | [BE-1.3](./BE-1.3.md) | Not started |

### E3 — Course Catalog

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-3.1](./BE-3.1.md) | Browse the catalog | M | [BE-6.1](./BE-6.1.md) | Not started |
| [BE-3.2](./BE-3.2.md) | Search and filter | S | [BE-3.1](./BE-3.1.md) | Not started |
| [BE-3.3](./BE-3.3.md) | View course detail | M | [BE-3.1](./BE-3.1.md) | Not started |

### E4 — Enrolment

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-4.1](./BE-4.1.md) | Enrol in a batch | M | [BE-3.3](./BE-3.3.md), [BE-1.3](./BE-1.3.md), [BE-7.1](./BE-7.1.md), [BE-7.2](./BE-7.2.md) | Not started |
| [BE-4.2](./BE-4.2.md) | View my enrolments | M | [BE-4.1](./BE-4.1.md) | Not started |
| [BE-4.3](./BE-4.3.md) | Withdraw from a batch | S | [BE-4.1](./BE-4.1.md) | Not started |
| [BE-4.4](./BE-4.4.md) | Student dashboard | M | [BE-4.1](./BE-4.1.md), [BE-2.1](./BE-2.1.md) | Not started |

### E5 — Notifications

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-5.1](./BE-5.1.md) | Account emails | M | [BE-1.1](./BE-1.1.md), [BE-1.2](./BE-1.2.md), [BE-1.5](./BE-1.5.md), [BE-2.3](./BE-2.3.md) | Not started |
| [BE-5.2](./BE-5.2.md) | Enrolment emails | M | [BE-4.1](./BE-4.1.md), [BE-4.3](./BE-4.3.md) | Not started |

### E6 — Catalog Seeding & Ops

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-6.1](./BE-6.1.md) | Seed course data | M | — | Not started |
| [BE-6.2](./BE-6.2.md) | Export enrolments | M | [BE-4.1](./BE-4.1.md) | Not started |

### E7 — Platform Foundations

| Story | Title | Priority | Depends on | Status |
|---|---|---|---|---|
| [BE-7.1](./BE-7.1.md) | Role model | M | — | Not started |
| [BE-7.2](./BE-7.2.md) | Audit logging | M | — | Not started |
| [BE-7.3](./BE-7.3.md) | Error handling | M | — | Not started |

---

See also: [Frontend Storyboard](../frontend/STORYBOARD.md) · [Architecture](../../docs/ARCHITECTURE.md) · [PRD](../../docs/PRD.md)
