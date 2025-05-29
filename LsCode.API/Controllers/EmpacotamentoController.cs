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
