using Microsoft.AspNetCore.Mvc;
using LsCode.API.Models;
using System.Collections.Generic;

namespace LsCode.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpacotamentoController : ControllerBase
    {
        private readonly PackingService _packingService;

        public EmpacotamentoController()
        {
            _packingService = new PackingService();
        }

        [HttpPost("empacotar")]
        public ActionResult<List<RespostaEmpacotamento>> EmpacotarPedidos([FromBody] RequisicaoEmpacotamento requisicao)
        {
            try
            {

                var pedidos = requisicao.Pedidos.Select(p => new Pedido
            {
                Produtos = p.Produtos.Select(prod => new Produto
                {
                    Nome = prod.Nome,
                    Dimensoes = prod.Dimensoes
                }).ToList()
            }).ToList();
                var resposta = _packingService.EmpacotarPedidos(requisicao.Pedidos);
                return Ok(resposta);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}
