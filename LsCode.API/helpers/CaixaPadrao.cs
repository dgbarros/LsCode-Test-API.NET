using LsCode.API.Models;
using System.Collections.Generic;

public static class CaixaPadrao
{
    public static List<Caixa> Caixas { get; } = new List<Caixa>
    {
        new Caixa(1, new Dimensao(30, 40, 80)),
        new Caixa(2, new Dimensao(80, 50, 40)),
        new Caixa(3, new Dimensao(50, 80, 60))
    };
}
