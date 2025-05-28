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
        public ActionResult<List<Caixa>> EmpacotarPedido([FromBody] Pedido pedido)
        {
            try
            {
                var caixas = _packingService.EmpacotarPedido(pedido);
                return Ok(caixas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
