# Harness Engineering para .NET

Repositório de referência da série de artigos **Harness Engineering para .NET**. Cada artigo corresponde a uma tag neste repositório, permitindo acompanhar a evolução do projeto por diff.

A aplicação é uma API de reembolso de despesas em ASP.NET Core, organizada em camadas (Clean Architecture). O domínio existe como pano de fundo: o foco da série é o harness que envolve o agente de codificação — rules, skills, sensores, hooks e avaliação.

## Estado atual

Baseline (estado zero): solução em camadas, sem regras de negócio implementadas e sem harness configurado. As features são construídas ao longo da série via Spec-Driven Development.

## Estrutura

```
src/
  Reimbursements.Domain/          # entidades e regras de negócio
  Reimbursements.Application/     # casos de uso
  Reimbursements.Infrastructure/  # EF Core + PostgreSQL
  Reimbursements.Api/             # ASP.NET Core Minimal API
tests/
  Reimbursements.UnitTests/
```

## Requisitos

- .NET SDK 10 (versão fixada em `global.json`)
- Docker (PostgreSQL local)

## Execução local

```powershell
docker compose up -d
dotnet build Reimbursements.slnx
dotnet test Reimbursements.slnx
dotnet run --project src/Reimbursements.Api
```

As credenciais em `compose.yaml` e `appsettings.Development.json` são exclusivas do banco local em container e não devem ser reutilizadas em outro ambiente.
