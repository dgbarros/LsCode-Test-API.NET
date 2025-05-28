using LsCode.API.Models;
using System.Collections.Generic;

public static class CaixaPadrao
{
    public static List<CaixaPadraoModel> Caixas { get; } = new List<CaixaPadraoModel>
    {
        new CaixaPadraoModel("Caixa Padrão 1", new Dimensao(30, 40, 80)),
        new CaixaPadraoModel("Caixa Padrão 2", new Dimensao(80, 50, 40)),
        new CaixaPadraoModel("Caixa Padrão 3", new Dimensao(50, 80, 60))
    };
}
