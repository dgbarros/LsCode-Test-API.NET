public class Dimensao
{
    public int Altura { get; set; }
    public int Largura { get; set; }
    public int Comprimento { get; set; }
    public int Id { get; set; }

    public Dimensao () {}

    public Dimensao(int altura, int largura, int comprimento)
    {
        Altura = altura;
        Largura = largura;
        Comprimento = comprimento;
    }

    public int Volume()
    {
        return Altura * Largura * Comprimento;
    }

    public bool CabeEm(Dimensao caixa)
    {
        // Aqui podemos considerar só uma orientação fixa para simplificar
        return Altura <= caixa.Altura
            && Largura <= caixa.Largura
            && Comprimento <= caixa.Comprimento;
    }
}
