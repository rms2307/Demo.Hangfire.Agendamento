using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config => config.UsePostgreSqlStorage(c => c.UseNpgsqlConnection(connectionString)));

var app = builder.Build();

app.MapPost("/agendar-comunicacao", (ComunicacaoDto dto) =>
{
    var jobId = $"{dto.UsuarioId}-{dto.Mensagem}";
    var cron = CronBuilder.GerarCron(dto.Cron.Frequencia, dto.Cron.Hora, dto.Cron.Minuto, dto.Cron.IntervaloMinutos);

    RecurringJob.AddOrUpdate<ComunicacaoService>(jobId, service => service.EnviarMensagem(dto.UsuarioId, dto.Mensagem), cron);

    Console.WriteLine($"Comunica��o agendada com sucesso.");
    return Results.Ok("Comunica��o agendada com sucesso.");
});

app.Run();
