using LsCode.API.Models;

public class Pedido
{
    public int Id { get; set; }
    public List<Produto> Produtos { get; set; } = new List<Produto>();
    public List<Caixa> Caixas { get; set; } = new List<Caixa>();

    public Pedido (){}

    public Pedido(int id, List<Produto> produtos)
    {
        Id = id;
        Produtos = produtos;
    }
}
