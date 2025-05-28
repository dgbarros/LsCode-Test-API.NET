namespace LsCode.API.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Dimensao Dimensoes { get; set; }
    public int PedidoId { get; set; }

    public Produto(){}

    public Produto(int id, string nome, Dimensao dimensoes)
    {
        Id = id;
        Nome = nome;
        Dimensoes = dimensoes;
    }
}
