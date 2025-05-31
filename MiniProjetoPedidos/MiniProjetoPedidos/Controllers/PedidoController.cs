using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProjetoPedidos.Models;
using MiniProjetoPedidos.Auxiliares;
using Microsoft.AspNetCore.Authorization;

namespace MiniProjetoPedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            //
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Storage.SalvaPedido(pedido);
            return Ok(new { message = "Pedido salvo com sucesso!" });
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pedidos = Storage.CarregaPedidos();
            return Ok(pedidos);
        }
    }
}
