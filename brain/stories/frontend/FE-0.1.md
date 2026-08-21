---
id: FE-0.1
title: "Scaffold frontend app & workspace tooling"
layer: frontend
epic: "E0 — Project Setup"
prd_ref: N/A
priority: M
status: not-started
depends_on: []
---

# FE-0.1 — Scaffold frontend app & workspace tooling

> As a developer, I want the pnpm/Turborepo workspace and the Next.js app scaffolded with the design system wired in, so that every frontend story from E1 onward has somewhere to land.

**Epic:** E0 — Project Setup · **PRD reference:** N/A — infrastructure setup, not a PRD user story · **Priority:** M · **Layer:** frontend

## Scope

Stand up the root pnpm + Turborepo workspace and the Next.js 16 app in `apps/web`, per architecture §5.1 and the confirmed monorepo tooling decision (Turborepo + pnpm workspaces). Wire in the design tokens from `brain/design-system/base.css` and shadcn/ui so every later screen story starts from a consistent, themed baseline. This is the prerequisite every other `FE-*` story is built on top of.

## Key points

- Root `pnpm-workspace.yaml`, `turbo.json` and root `package.json` created; `apps/web` registered as the first workspace member (`apps/api` is not part of the pnpm workspace — it's a separate .NET solution, see [BE-0.1](../backend/BE-0.1.md)).
- Next.js 16 app scaffolded in `apps/web`: App Router, TypeScript, ESLint.
- Tailwind CSS installed; `brain/design-system/base.css`'s tokens (brand palette, semantic tokens, Roboto) wired into the app's global stylesheet through Tailwind's real v4 build pipeline — this is the first place those `@theme`/`@import "tailwindcss"` directives actually take effect (see the caveat noted when `base.css` was authored).
- shadcn/ui initialized (`components.json`), light theme confirmed as the default per the global convention.
- App boots locally (`pnpm dev`) and renders a placeholder home route using at least one shadcn component, proving the token pipeline end-to-end.

## Dependencies

_None — this is the first frontend story; everything else in `brain/stories/frontend/` builds on it._

## Related

- [BE-0.1](../backend/BE-0.1.md) — the equivalent scaffolding story for the backend solution.
