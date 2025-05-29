using LsCode.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeuProjeto.Data; // ajuste o namespace conforme o seu projeto
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly PackingService _packingService;
    private readonly AppDbContext _context;

    public PedidoController(AppDbContext context)
    {
        _packingService = new PackingService();
        _context = context;
    }

    [HttpPost("processar")]
    public async Task<IActionResult> ProcessarPedidos([FromBody] RequisicaoPedido requisicao)
    {
        var resultado = new List<object>();

        foreach (var pedido in requisicao.Pedidos)
        {
            var caixasUsadas = _packingService.EmpacotarPedido(pedido);

            // Adiciona pedido ao contexto
            _context.Pedidos.Add(pedido);

            // Atualiza o PedidoId em cada caixa e adiciona ao contexto
            foreach (var caixa in caixasUsadas)
            {
                caixa.PedidoId = pedido.Id;
                _context.Caixas.Add(caixa);

                foreach (var produto in caixa.Produtos)
                {
                    produto.PedidoId = pedido.Id;
                    _context.Produtos.Add(produto);
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

        await _context.SaveChangesAsync();

        return Ok(resultado);
    }
}
