# Demo.Hangfire.Agendamento.Worker

Worker responsável pela execução dos jobs agendados pelo Hangfire.

## Funcionalidades

- ✅ Execução de jobs em segundo plano
- ✅ Dashboard do Hangfire disponível em `/hangfire`
- ✅ Processamento de comunicações agendadas

## Como executar

```bash
dotnet run
```

O worker será executado na porta 5001 e o dashboard estará disponível em: http://localhost:5001/hangfire

## Configuração

O worker utiliza a mesma string de conexão PostgreSQL configurada no `appsettings.json`.