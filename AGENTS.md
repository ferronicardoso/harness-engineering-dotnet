# AGENTS.md

## Projeto

API de reembolso de despesas em ASP.NET Core (.NET 10), organizada em camadas. Repositório de referência da série de artigos "Harness Engineering para .NET".

## Estrutura e regra de dependência

```
src/Reimbursements.Domain          # entidades e regras de negócio; não depende de nenhum outro projeto
src/Reimbursements.Application     # casos de uso; depende apenas de Domain
src/Reimbursements.Infrastructure  # EF Core + PostgreSQL; depende de Application e Domain
src/Reimbursements.Api             # Minimal API; depende de Application e Infrastructure
tests/Reimbursements.UnitTests     # testes de Domain e Application
```

- Não adicione referências que invertam essa direção (por exemplo, Domain referenciando Infrastructure).
- Tipos do EF Core ficam restritos a Infrastructure.
- Regras de negócio ficam em Domain/Application, não em endpoints.

## Critério de pronto

Uma tarefa só está concluída quando os três comandos abaixo terminam com sucesso (exit code 0):

```powershell
dotnet build Reimbursements.slnx
dotnet test Reimbursements.slnx
dotnet format Reimbursements.slnx --verify-no-changes
```

O build trata avisos como erro (`Directory.Build.props`). Um build com falha indica que a alteração ainda não atende às regras do projeto.

## Convenções

- Identificadores de código em inglês; documentação (README, PRD, ADR) em português.
- Namespaces com escopo de arquivo.
- Use `TimeProvider` em vez de `DateTime.Now`/`UtcNow`.
- Acesso a SQL apenas via LINQ ou `ExecuteSql`/`FromSql` com string interpolada; nunca `*Raw` com concatenação.

## Restrições

- Não suprima diagnósticos (`#pragma warning disable`, `[SuppressMessage]`, `NoWarn`, severidade `none` no `.editorconfig`) para fazer o build passar. Se uma regra parecer inadequada, pare e explique o motivo.
- Não altere `Directory.Build.props`, `.editorconfig` ou `BannedSymbols.txt` para relaxar regras sem solicitação explícita.
- Não adicione credenciais a arquivos versionados. As credenciais de `compose.yaml` e `appsettings.Development.json` são exclusivas do banco local em container.
- Não execute migrations ou comandos de banco contra ambientes que não sejam o container local.

## Ambiente local

```powershell
docker compose up -d
dotnet run --project src/Reimbursements.Api
```
