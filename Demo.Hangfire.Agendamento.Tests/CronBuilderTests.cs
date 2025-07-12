public class CronBuilderTests
{
    [Theory]
    [InlineData("diario", 8, 30, 0, "30 8 * * *")]
    [InlineData("semanal", 9, 15, 0, "15 9 * * 1")]
    [InlineData("mensal", 10, 45, 0, "45 10 1 * *")]
    [InlineData("horaemhora", 0, 5, 0, "5 * * * *")]
    [InlineData("cadaminutos", 0, 0, 10, "*/10 * * * *")]
    public void GerarCron_DeveRetornarExpressaoEsperada(string frequencia, int hora, int minuto, int intervaloMinutos, string esperado)
    {
        var resultado = CronBuilder.GerarCron(frequencia, hora, minuto, intervaloMinutos);
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public void GerarCron_FrequenciaInvalida_DeveLancarExcecao()
    {
        Assert.Throws<ArgumentException>(() => CronBuilder.GerarCron("invalido"));
    }
}
