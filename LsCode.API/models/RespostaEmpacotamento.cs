using LsCode.API.Models;
public class RespostaEmpacotamento
{
    public int PedidoId { get; set; }
    public List<CaixaResposta> Caixas { get; set; }

}

public class CaixaResposta
{
    public int Id { get; set; }
    public string NomeCaixa { get; set; }
    public Dimensao Dimensoes { get; set; }
    public List<Produto> Produtos { get; set; }
}
