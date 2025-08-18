# 🌀 Hangfire Agendamento de Comunicações (Demo com .NET + PostgreSQL)

Este projeto demonstra como utilizar o [Hangfire](https://www.hangfire.io/) em uma arquitetura separada com **API** e **Worker** para agendar e processar **tarefas em segundo plano** (background jobs), com **persistência em PostgreSQL**.

## 🏗️ Arquitetura

- **Demo.Hangfire.Agendamento**: API responsável pelo agendamento de jobs
- **Demo.Hangfire.Agendamento.Worker**: Worker responsável pela execução dos jobs e dashboard

## 🔧 Tecnologias Utilizadas

- [.NET 8 Minimal API](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Hangfire](https://www.hangfire.io/) (agendador de tarefas)
- [Hangfire.PostgreSql](https://github.com/frankhommers/Hangfire.PostgreSql) (storage)
- PostgreSQL

---

## 🎯 Funcionalidades

- ✅ Agendamento dinâmico de jobs via API
- ✅ Execução de jobs em worker separado
- ✅ Exemplo simples de comunicação agendada (simulada via console)
- ✅ Interface web do Hangfire Dashboard disponível no Worker em `/hangfire`
- ✅ Pronto para rodar em ambiente com múltiplos pods/instâncias (com compartilhamento de storage)

---

## 🚀 Como executar

### 1. Executar o Worker
```bash
cd Demo.Hangfire.Agendamento.Worker
dotnet run
```
Dashboard disponível em: http://localhost:5001/hangfire

### 2. Executar a API
```bash
cd Demo.Hangfire.Agendamento
dotnet run
```
API disponível em: http://localhost:5000

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
