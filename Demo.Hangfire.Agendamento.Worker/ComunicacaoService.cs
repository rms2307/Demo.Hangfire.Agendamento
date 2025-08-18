public class ComunicacaoService
{
    public void EnviarMensagem(int usuarioId, string mensagem)
    {
        Console.WriteLine($"[ENVIO] Mensagem para Usuario {usuarioId}: {mensagem} - {DateTime.Now}");
    }
}