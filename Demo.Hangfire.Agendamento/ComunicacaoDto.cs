public class ComunicacaoDto
{
    public int UsuarioId { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public CronDto Cron { get; set; }
}