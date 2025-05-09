namespace ContainRs.Api.Domain;

public record SituacaoProposta(string Status)
{
    public static SituacaoProposta Aceita => new("Aceita");
    public static SituacaoProposta Cancelada => new("Cancelada");
    public static SituacaoProposta Enviada => new("Enviada");
    public static SituacaoProposta Expirada => new("Expirada");
    public static SituacaoProposta Recusada => new("Recusada");
    public override string ToString() => Status;
    public static SituacaoProposta? Parse(string status)
    {
        return status switch
        {
            "Aceita" => Aceita,
            "Cancelada" => Cancelada,
            "Enviada" => Enviada,
            "Expirada" => Expirada,
            "Recusada" => Recusada,
            _ => null
        };
    }
}

public class Proposta
{
    public Proposta() { }
    public Guid Id { get; set; }
    public SituacaoProposta Situacao { get; set; } = SituacaoProposta.Enviada;
    public decimal ValorTotal { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataExpiracao { get; set; }
    public string NomeArquivo { get; set; }
    public Guid ClienteId { get; set; }
    public Guid SolicitacaoId { get; set; }
    public PedidoLocacao Solicitacao { get; set; }
    public ICollection<Comentario> Comentarios { get; } = [];

    public Comentario AddComentario(Comentario comentario)
    {
        Comentarios.Add(comentario);
        return comentario;
    }

    public void RemoveComentario(Comentario comentario)
    {
        Comentarios.Remove(comentario);
    }
}
