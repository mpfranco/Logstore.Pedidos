using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logstore.Pedidos.Application.UseCases.Queries.Historico;
using Logstore.Pedidos.Infrastructure.Shared.Comunication;
using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logstore.Pedidos.Api.Controllers.Historico
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {        
        private readonly IFindHistoricQuerie _querie;
        public HistoricoController(IFindHistoricQuerie querie)
        {
            _querie = querie;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _querie.FindAsyncByClienteId(id);
                return Ok(new ResultCommand(result, Infrastructure.Shared.Constants.StatusCode.IsSuccess));
            }
            catch (Exception err)
            {
                return BadRequest(new ResultCommand(err.Message, Infrastructure.Shared.Constants.StatusCode.Invalid));
            }

        }
    }
}