using LsCode.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class PackingService
{
    public List<Caixa> EmpacotarPedido(Pedido pedido)
    {
        var caixasUsadas = new List<Caixa>();

        var produtodOrdenados = pedido.Produtos
            .OrderByDescending(p => p.Dimensoes.Volume())
            .ToList();

        foreach (var produto in pedido.Produtos)
        {
            bool produtoEmpacotado = false;

            // Tenta encaixar na caixa já usada
            foreach (var caixa in caixasUsadas)
            {
                if (caixa.TentarAdicionarProduto(produto))
                {
                    produtoEmpacotado = true;
                    break;
                }
            }

            // Se não conseguiu, abre uma nova caixa da lista de padrões
            if (!produtoEmpacotado)
            {
                var caixasQueCabem = CaixaPadrao.Caixas
                    .Where(c => produto.Dimensoes.CabeEm(c.Dimensoes))
                    .OrderBy(c => c.Dimensoes.Volume())
                    .ToList();

                if (!caixasQueCabem.Any())
                    throw new Exception($"Produto {produto.Nome} não cabe em nenhuma caixa disponível");
                
                var caixaPadrao = caixasQueCabem.First();

                var novaCaixa = new Caixa(caixasUsadas.Count + 1, caixasQueCabem.First().Dimensoes){
                    NomeCaixa = caixaPadrao.Nome
                };
                novaCaixa.TentarAdicionarProduto(produto);
                caixasUsadas.Add(novaCaixa);
            }
        }

        return caixasUsadas;
    }
}
