# 🌀 Hangfire Agendamento de Comunicações (Demo com .NET + PostgreSQL)

Este projeto demonstra como utilizar o [Hangfire](https://www.hangfire.io/) em uma **Minimal API .NET** para agendar e processar **tarefas em segundo plano** (background jobs), com **persistência em PostgreSQL**.

## 🔧 Tecnologias Utilizadas

- [.NET 8 Minimal API](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Hangfire](https://www.hangfire.io/) (agendador de tarefas)
- [Hangfire.PostgreSql](https://github.com/frankhommers/Hangfire.PostgreSql) (storage)
- PostgreSQL

---

## 🎯 Funcionalidades

- ✅ Agendamento dinâmico de jobs com `RecurringJob.AddOrUpdate`, com base em data informada pelo usuário.
- ✅ Exemplo simples de comunicação agendada (simulada via console).
- ✅ Interface web do Hangfire Dashboard disponível em `/hangfire` para monitoramento.
- ✅ Pronto para rodar em ambiente com múltiplos pods/instâncias (com compartilhamento de storage).

---

## 📦 Endpoints disponíveis

### `POST /agendamentos-recorrentes`

Agenda uma mensagem recorrente com base em configuração CRON.

#### Corpo da requisição (JSON):

```json
{
    "usuarioId": 890,
    "mensagem": "Teste 7!",
    "cron": {
        "frequencia": "Diario",
        "hora": 10,
        "minuto": 0,
        "intervaloMinutos": 0
    }
}
```

### `POST /agendamentos-unicos`

Agenda uma mensagem única para ser enviada em data e hora específicas.

#### Corpo da requisição (JSON):

```json
{
    "usuarioId": 123,
    "mensagem": "Mensagem única",
    "dataAgendamento": "2024-12-25T10:30:00"
}
```

### `GET /jobs`

Lista todas as tarefas agendadas (únicas) e recorrentes.

#### Resposta (JSON):

```json
{
    "scheduled": [
        {
            "jobId": "123",
            "method": "EnviarMensagem",
            "args": [123, "Mensagem única"],
            "enqueueAt": "2024-12-25T10:30:00Z"
        }
    ],
    "recurring": [
        {
            "id": "890-Teste 7!",
            "method": "EnviarMensagem",
            "cron": "0 10 * * *",
            "lastExecution": "2024-12-20T10:00:00Z",
            "nextExecution": "2024-12-21T10:00:00Z"
        }
    ]
}
