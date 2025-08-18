using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config => config.UsePostgreSqlStorage(c => c.UseNpgsqlConnection(connectionString)));

builder.Services.AddHangfireServer();
builder.Services.AddSingleton<ComunicacaoService>();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

app.Run();