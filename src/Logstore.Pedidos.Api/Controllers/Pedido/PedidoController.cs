using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logstore.Pedidos.Application.UseCases.Commands.Pedidos.AddPedidos;
using Logstore.Pedidos.Application.UseCases.Queries.Clientes;
using Logstore.Pedidos.Application.ViewModels;
using Logstore.Pedidos.Infrastructure.Shared.Comunication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logstore.Pedidos.Api.Controllers.Pedido
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediatorBus _mediator;
        

        public PedidoController(IMediatorBus mediator)
        {
            _mediator = mediator;            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoViewModel entidade)
        {
            var result = await _mediator.SendCommadAsync(new AddPedidoCommand(entidade.ClienteId,
                                                                              entidade.PedidoItens,
                                                                              entidade.Cliente));

            if (result.StatusCode == Infrastructure.Shared.Constants.StatusCode.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }
    }
}