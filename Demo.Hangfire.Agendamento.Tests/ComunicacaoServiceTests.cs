public class ComunicacaoServiceTests
{
    [Fact]
    public void EnviarMensagem_DeveExecutarSemErros()
    {
        var service = new ComunicacaoService();
        var usuarioId = 1;
        var mensagem = "Teste de mensagem";

        using var sw = new StringWriter();
        Console.SetOut(sw);

        service.EnviarMensagem(usuarioId, mensagem);

        var output = sw.ToString();
        Assert.Contains($"[ENVIO] Mensagem para Usuário {usuarioId}: {mensagem}", output);
    }
}
