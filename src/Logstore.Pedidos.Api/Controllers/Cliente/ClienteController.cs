using System;
using System.Threading.Tasks;
using Logstore.Pedidos.Application.UseCases.Commands.Clientes.AddClient;
using Logstore.Pedidos.Application.UseCases.Queries.Clientes;
using Logstore.Pedidos.Application.ViewModels;
using Logstore.Pedidos.Infrastructure.Shared.Comunication;
using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using Microsoft.AspNetCore.Mvc;

namespace Logstore.Pedidos.Api.Controllers.Cliente
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMediatorBus _mediator;
        private readonly IFindClientQuerie _querie;

        public ClienteController(IMediatorBus mediator,
                                 IFindClientQuerie querie)
        {
            _mediator = mediator;
            _querie = querie;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteViewModel entidade)
        {
            var result = await _mediator.SendCommadAsync(new
                                                   AddClientCommand(entidade.Nome,
                                                                    entidade.Telefone,
                                                                    entidade.CPF));
            if (result.StatusCode == Infrastructure.Shared.Constants.StatusCode.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _querie.FindAsyncById(id);
                return Ok(new ResultCommand(result, Infrastructure.Shared.Constants.StatusCode.IsSuccess));;
            }
            catch (Exception err)
            {
                return BadRequest(new ResultCommand(err.Message, Infrastructure.Shared.Constants.StatusCode.Invalid));
            }
            
        }
    }
}