using Hangfire;
using Hangfire.PostgreSql;
using Hangfire.Storage;

var builder = WebApplication.CreateBuilder(args);

// Configurar Hangfire com PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config => config.UsePostgreSqlStorage(c => c.UseNpgsqlConnection(connectionString)));

builder.Services.AddHangfireServer();
builder.Services.AddSingleton<ComunicacaoService>();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

app.MapPost("/agendamentos-recorrentes", (ComunicacaoRecorrenteDto dto, ComunicacaoService service) =>
{
    var jobId = $"{dto.UsuarioId}-{dto.Mensagem}";
    var cron = CronBuilder.GerarCron(dto.Cron.Frequencia, dto.Cron.Hora, dto.Cron.Minuto, dto.Cron.IntervaloMinutos);

    RecurringJob.AddOrUpdate(jobId, () => service.EnviarMensagem(dto.UsuarioId, dto.Mensagem), cron);

    return Results.Ok("Comunicacao recorrente agendada com sucesso.");
});

app.MapPost("/agendamentos-unicos", (ComunicacaoUnicaDto dto, ComunicacaoService service) =>
{
    BackgroundJob.Schedule(() => service.EnviarMensagem(dto.UsuarioId, dto.Mensagem), new DateTimeOffset(dto.DataAgendamento));

    return Results.Ok("Comunicacao unica agendada com sucesso.");
});

app.MapGet("/agendamentos", () =>
{
    var monitor = JobStorage.Current.GetMonitoringApi();
    
    var unicos = monitor.ScheduledJobs(0, 100)
        .Select(kv => new
        {
            JobId = kv.Key,
            Method = kv.Value.Job.Method.Name,
            Args = kv.Value.Job.Args,
            EnqueueAt = kv.Value.EnqueueAt
        });
    
    using var connection = JobStorage.Current.GetConnection();
    var recorrentes = connection.GetRecurringJobs()
        .Select(job => new
        {
            Id = job.Id,
            Method = job.Job?.Method?.Name,
            Cron = job.Cron,
            LastExecution = job.LastExecution,
            NextExecution = job.NextExecution
        });
    
    return Results.Ok(new { AgendamentosUnicos = unicos, AgendamentosRecorrentes = recorrentes });
});

app.Run();
