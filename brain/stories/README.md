# Stories

Phase 1 delivery stories, derived from [`brain/docs/PRD.md`](../docs/PRD.md) and structured per [`brain/docs/ARCHITECTURE.md`](../docs/ARCHITECTURE.md)'s frontend/backend split. Each PRD user story becomes one story per layer that touches it (most stories have both a `BE-` and `FE-` pair; some — notifications, seeding, exports, role model, audit logging — are backend-only, and analytics instrumentation is frontend-only). An `E0 — Project Setup` epic sits ahead of the PRD epics for one-time monorepo scaffolding that every other story depends on.

- [Backend Storyboard](backend/STORYBOARD.md) — 24 stories (`BE-*`)
- [Frontend Storyboard](frontend/STORYBOARD.md) — 19 stories (`FE-*`)

## Start here

[BE-0.1](backend/BE-0.1.md) and [FE-0.1](frontend/FE-0.1.md) scaffold the monorepo (ASP.NET solution + local PostgreSQL connection; pnpm/Turborepo workspace + Next.js app) and have no PRD reference — everything else is built on top of them.

## Conventions

- **Location:** `brain/stories/backend/` and `brain/stories/frontend/`.
- **Naming:** `{PREFIX}-{PRD user story number}.md`, e.g. `BE-4.1.md`, `FE-4.1.md`.
- **Frontmatter:** every story has `id`, `title`, `layer`, `epic`, `prd_ref`, `priority` (PRD MoSCoW), `status`, `depends_on`.
- **Dependencies:** listed in frontmatter and linked in the story body's "Dependencies" section.
- **Pairing:** a story with both a frontend and backend half links to its counterpart under "Related".
