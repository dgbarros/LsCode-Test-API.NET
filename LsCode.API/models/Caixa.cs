using LsCode.API.Models;

public class Caixa
{
    public int Id { get; set; }
    public Dimensao Dimensoes { get; set; }
    public int PedidoId { get; set; }
    public string NomeCaixa {get; set;}
    public List<Produto> Produtos { get; set; } = new List<Produto>();

    private int VolumeDisponivel { get; set; }
    public decimal Dimensoes_Altura { get; internal set; }

    public Caixa() { }
    public Caixa(int id, Dimensao dimensoes)
    {
        Id = id;
        Dimensoes = dimensoes;
        NomeCaixa = $"Caixa{id}";
        VolumeDisponivel = dimensoes.Volume();
    }

    public Caixa(int id, Dimensao dimensoes, string nome)
    {
        Id = id;
        Dimensoes = dimensoes;
        NomeCaixa = nome;
        VolumeDisponivel = dimensoes.Volume();
    }

    public bool TentarAdicionarProduto(Produto produto)
    {
        if (produto.Dimensoes.CabeEm(this.Dimensoes) && produto.Dimensoes.Volume() <= VolumeDisponivel)
        {
            Produtos.Add(produto);
            VolumeDisponivel -= produto.Dimensoes.Volume();
            return true;
        }
        return false;
    }
}
