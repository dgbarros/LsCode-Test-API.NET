using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    [HttpPost("processar")]
    public IActionResult ProcessarPedidos([FromBody] List<Pedido> pedidos)
    {
        var resultado = new List<object>();

        foreach (var pedido in pedidos)
        {
            var caixasDisponiveis = ObterCaixasPadrao();
            var caixasUsadas = new List<Caixa>();

            foreach (var produto in pedido.Produtos)
            {
                bool adicionado = false;

                foreach (var caixa in caixasUsadas)
                {
                    if (caixa.TentarAdicionarProduto(produto))
                    {
                        adicionado = true;
                        break;
                    }
                }

                if (!adicionado)
                {
                    var novaCaixa = caixasDisponiveis
                        .FirstOrDefault(c => produto.Dimensoes.CabeEm(c.Dimensoes));

                    if (novaCaixa != null)
                    {
                        var caixaNova = new Caixa(novaCaixa.Id, novaCaixa.Dimensoes);
                        caixaNova.TentarAdicionarProduto(produto);
                        caixasUsadas.Add(caixaNova);
                    }
                }
            }

            resultado.Add(new
            {
                PedidoId = pedido.Id,
                Caixas = caixasUsadas.Select(c => new
                {
                    CaixaId = c.Id,
                    Produtos = c.Produtos.Select(p => new
                    {
                        p.Id,
                        p.Nome,
                        Dimensoes = p.Dimensoes
                    })
                })
            });
        }

        return Ok(resultado);
    }

    private List<Caixa> ObterCaixasPadrao()
    {
        return new List<Caixa>
        {
            new Caixa(1, new Dimensao(30, 40, 80)),
            new Caixa(2, new Dimensao(80, 50, 40)),
            new Caixa(3, new Dimensao(50, 80, 60))
        };
    }
}
