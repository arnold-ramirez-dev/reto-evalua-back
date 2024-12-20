using API.Queries.Clients;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        [HttpGet("list/sp")]
        public async Task<IActionResult> GetListClienteSPQuery([FromQuery] GetListClienteSPQuery dto)
        {
            try
            {
                return Ok(await _mediator.Send(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("list/ef")]
        public async Task<IActionResult> GetListClienteEFQuery([FromQuery] GetListClienteEFQuery dto)
        {
            try
            {
                return Ok(await _mediator.Send(dto));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
