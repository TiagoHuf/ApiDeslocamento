using ApiDeslocamento.Application.Clientes.Commands.AdicionarCliente;
using ApiDeslocamento.Application.Clientes.Queries;
using DeslocamentoApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeslocamento.WebApp.Controllers
{

    public class ClienteController : ApiController
    {

        [HttpGet("{ClienteId:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetClienteQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetClientesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);

        }
    }
}