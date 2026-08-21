# MIM Student Portal

Phase 1 monorepo: course discovery & enrolment. See [`brain/README.md`](brain/README.md) for the full knowledge base (PRD, architecture, design system, delivery stories).

## Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) 20+
- [pnpm](https://pnpm.io/) 9+ (`corepack enable` or `npm i -g pnpm`)
- [PostgreSQL](https://www.postgresql.org/) running locally on port 5432

## Backend — `apps/api`

ASP.NET Core 10 (Minimal APIs, Clean Architecture) + EF Core / Npgsql.

```bash
cd apps/api
```

**First-time setup** — point the API at your local Postgres instance via user-secrets (never commit a connection string):

```bash
createdb student_portal_db   # or: psql -U postgres -c "CREATE DATABASE student_portal_db;"

cd MIM.Portal.Api
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:Portal" "Host=localhost;Port=5432;Database=student_portal_db;Username=postgres"
cd ..
```

**Apply migrations:**

```bash
dotnet tool install --global dotnet-ef   # first time only
dotnet ef database update --project MIM.Portal.Infrastructure --startup-project MIM.Portal.Api
```

**Run the API:**

```bash
dotnet run --project MIM.Portal.Api
```

The API listens on the URL printed in the console (see `MIM.Portal.Api/Properties/launchSettings.json`). Verify it's up:

```bash
curl http://localhost:5176/health
```

## Frontend — `apps/web`

Next.js 16 (App Router, TypeScript, Tailwind v4, shadcn/ui), managed via the root pnpm + Turborepo workspace.

**First-time setup** (from the repo root):

```bash
pnpm install
```

**Run the dev server:**

```bash
pnpm dev
```

This runs `turbo run dev`, which starts `apps/web` on [http://localhost:3000](http://localhost:3000).

**Other workspace commands** (run from the repo root, apply to all `apps/*` packages via Turborepo):

```bash
pnpm build   # production build
pnpm lint    # lint
```

## Running both together

The frontend calls the backend server-to-server (Next.js is a session-owning BFF — see [`brain/docs/ARCHITECTURE.md`](brain/docs/ARCHITECTURE.md) §6). For full-stack local development, run each in its own terminal:

```bash
# terminal 1
cd apps/api && dotnet run --project MIM.Portal.Api

# terminal 2
pnpm dev
```
