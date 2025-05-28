namespace LsCode.API.Models
{
    public class CaixaPadraoModel
    {
        public string Nome { get; set; }
        public Dimensao Dimensoes { get; set; }

        public CaixaPadraoModel(string nome, Dimensao dimensoes)
        {
            Nome = nome;
            Dimensoes = dimensoes;
        }
    }
}
