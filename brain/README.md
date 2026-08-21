# MIM Student Portal — Brain

Root navigation for this project's knowledge base. Update this file whenever a document is added anywhere under `brain/`.

## Docs

- [`docs/PRD.md`](docs/PRD.md) — Phase 1 Product Requirements Document (Course Discovery & Enrolment, Web). **Approved**, baselined 21 Aug 2026.
- [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) — Phase 1 architecture: Next.js 16 + ASP.NET Core 10 (Minimal APIs, Clean Architecture) + PostgreSQL/EF Core. Draft, derived from the PRD.

## Design system

- [`design-system/base.css`](design-system/base.css) — design tokens: brand color scales (Punch Red, Honeydew, Frosted Blue, Cerulean, Oxford Navy), shadcn-style semantic tokens (light theme), Roboto font, Tailwind v4 `@theme` mapping.
- [`design-system/guide.html`](design-system/guide.html) — visual component guide (two-column layout) for every token and component in `base.css`. Open directly in a browser.
- [`design-system/mokups/MIM Student Portal Mockups.dc.html`](design-system/mokups/MIM%20Student%20Portal%20Mockups.dc.html) — interactive Phase 1 screen mockups (Home, Course detail, Register, Check email, Login, Dashboard) with a desktop/mobile viewport toggle. Uses the same Roboto + Oxford Navy palette as `base.css`, styled inline rather than via the token file.

## Daily notes

- [`daily-notes/`](daily-notes/) — one file per day worked, named `dd-mm-yyyy.md`, logging what was completed.
