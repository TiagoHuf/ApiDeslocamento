using ApiDeslocamento.Application.Condutores.Commands.AdicionarCondutor;
using ApiDeslocamento.Application.Condutores.Queries;
using DeslocamentoApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeslocamento.WebApp.Controllers
{

    public class CondutorController : ApiController
    {

        [HttpGet("{CondutorId:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetCondutorQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetCondutoresQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);

        }
    }
}