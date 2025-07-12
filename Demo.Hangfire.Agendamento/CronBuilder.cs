public static class CronBuilder
{
    public static string GerarCron(string frequencia, int hora = 0, int minuto = 0, int intervaloMinutos = 0)
    {
        return frequencia.ToLower() switch
        {
            "diario" => $"{minuto} {hora} * * *",
            "semanal" => $"{minuto} {hora} * * 1", // Segunda-feira
            "mensal" => $"{minuto} {hora} 1 * *",  // Dia 1 de cada mês
            "horaemhora" => $"{minuto} * * * *",
            "cadaminutos" when intervaloMinutos > 0 => $"*/{intervaloMinutos} * * * *",
            _ => throw new ArgumentException("Frequência inválida")
        };
    }
}
