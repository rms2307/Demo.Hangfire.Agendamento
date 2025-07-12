using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// Configurar Hangfire com PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config => config.UsePostgreSqlStorage(c => c.UseNpgsqlConnection(connectionString)));

builder.Services.AddHangfireServer();
builder.Services.AddSingleton<ComunicacaoService>();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

app.MapPost("/agendar-comunicacao", (ComunicacaoDto dto, ComunicacaoService service) =>
{
    var jobId = $"{dto.UsuarioId}-{dto.Mensagem}";
    var cron = CronBuilder.GerarCron(dto.Cron.Frequencia, dto.Cron.Hora, dto.Cron.Minuto, dto.Cron.IntervaloMinutos);

    RecurringJob.AddOrUpdate(jobId, () => service.EnviarMensagem(dto.UsuarioId, dto.Mensagem), cron);

    Console.WriteLine($"Comunicação agendada com sucesso.");
    return Results.Ok("Comunicação agendada com sucesso.");
});

app.Run();
