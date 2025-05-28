using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PackingService _packingService;

    public PedidoController()
    {
        _packingService = new PackingService();
    }

    [HttpPost("processar")]
    public IActionResult ProcessarPedidos([FromBody] List<Pedido> pedidos)
    {
        var resultado = new List<object>();

        foreach (var pedido in pedidos)
        {
            var caixasUsadas = _packingService.EmpacotarPedido(pedido);

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
}
