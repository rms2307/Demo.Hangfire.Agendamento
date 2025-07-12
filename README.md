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

### `POST /agendar-comunicacao`

Agenda uma mensagem para ser enviada em uma data e hora futuras.

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
