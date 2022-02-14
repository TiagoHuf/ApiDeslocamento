using ApiDeslocamento.Application.Condutores.Queries;
using ApiDeslocamento.Application.Deslocamento.Commands.AdicionarDeslocamento;
using DeslocamentoApp.Application.DeslocamentosCommands;
using DeslocamentoApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeslocamento.WebApp.Controllers
{

    public class DeslocamentoController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{DeslocamentoId:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetDeslocamentoQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);

        }

        [HttpPut("{deslocamentoId:long}/finalizar_deslocamento")]
        public async Task<IActionResult> PutAdicionarSignatarioAsync(
            [FromRoute] long deslocamentoId,
            [FromBody] FinalizarDeslocamentoCommand command)
        {
            if (deslocamentoId != command.DeslocamentoId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}