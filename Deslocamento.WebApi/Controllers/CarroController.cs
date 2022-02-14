using ApiDeslocamento.Application.Carros.Commands.AdicionarCarro;
using ApiDeslocamento.Application.Carros.Queries;
using DeslocamentoApp.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeslocamento.WebApp.Controllers
{

    public class CarroController : ApiController
    {

        [HttpGet("{CarroId:long}")]
        public async Task<IActionResult> GetAsync([FromRoute] GetCarroQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetCarrosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);

        }
    }
}