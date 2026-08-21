---
id: BE-0.1
title: "Scaffold backend solution"
layer: backend
epic: "E0 — Project Setup"
prd_ref: N/A
priority: M
status: not-started
depends_on: []
---

# BE-0.1 — Scaffold backend solution

> As a developer, I want the ASP.NET Core solution scaffolded and connected to a real database, so that every backend story from E1 onward has somewhere to land.

**Epic:** E0 — Project Setup · **PRD reference:** N/A — infrastructure setup, not a PRD user story · **Priority:** M · **Layer:** backend

## Scope

Stand up the ASP.NET Core 10 solution per the architecture doc's Clean Architecture layering (§4.1), and connect it to the developer's local PostgreSQL instance so migrations can actually run. This is the prerequisite every other `BE-*` story is built on top of.

## Key points

- Solution created with four projects — `MIM.Portal.Domain`, `MIM.Portal.Application`, `MIM.Portal.Infrastructure`, `MIM.Portal.Api` — wired per the dependency direction in architecture §4.1 (`Domain` has zero framework references).
- Minimal API host (`MIM.Portal.Api`) boots and serves a `GET /health` endpoint returning 200.
- EF Core + the Npgsql provider installed; `PortalDbContext` registered in `Infrastructure`.
- Connection string points at the **local PostgreSQL instance** — host `localhost`, port `5432` (default), database `student_portal_db`, user `postgres`. Supplied via .NET user-secrets (`dotnet user-secrets set ConnectionStrings:Portal ...`) in dev, or an environment variable in other environments — the password is never written into `appsettings.json` or any other file committed to the repo.
- An initial (empty) migration is created and applies cleanly against the local database, proving the connection end-to-end.
- The vertical-slice folder convention inside `Application/` (architecture §4.2 — one folder per epic, one subfolder per story) is created empty and ready for `BE-1.1` onward.

## Dependencies

_None — this is the first backend story; everything else in `brain/stories/backend/` builds on it._

## Related

- [FE-0.1](../frontend/FE-0.1.md) — the equivalent scaffolding story for the frontend/workspace side.
