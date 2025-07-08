using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vendas.Application.Commands;
using Vendas.Application.Handlers.VendedoresHandlers;
using Vendas.Application.Querys;
using Vendas.Application.Responses;
using Vendas.Domain.Entitys;

namespace Vendas.API.Controllers
{
    [ApiController]
    [Route("api/Vendedores")]
    public class VendedoresController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public VendedoresController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost("CriarNovoVendedor")]
        public async Task<ActionResult<VendedoresResponseHTTP>>
        CriarNovoVendedor([FromBody] VendedoresCommandCreate command, CancellationToken cancellationToken)
        {
            var Response = await _mediatR.Send(command);

            if (Response.HttpCodeStatus == 201)
            {
                return Ok(new { HttpStatusCode = Response.HttpCodeStatus, Message = Response.HttpMessage });
            }
            return BadRequest(new { HttpStatusCode = Response.HttpCodeStatus, Message = Response.HttpMessage });
        }

        [HttpGet("ListarTodosVendedores")]
        public async Task<ActionResult<VendedoresResponseGetAll>>
        ListarTodosVendedores([FromBody] VendedoresQueryGetAll query, CancellationToken cancellationToken)
        {
            var Response = await _mediatR.Send(query);

            if (Response.HttpCodeStatus == 404)
            {
                return NotFound();
            }

            return Ok(new { HttpStatusCode = Response.HttpCodeStatus, Message = Response.VendedoresDTOs });
        }

        [HttpGet("GetIDByEmail")]
        public async Task<ActionResult<VendedoresResponseGetByEmail>>
        GetIDByEmail([FromBody] VendedoresQueryGetByEmail query, CancellationToken cancellationToken)
        {
            var Response = await _mediatR.Send(query);

            if (Response.HttpStatusCode == 404)
            {
                return NotFound();
            }

            return Ok(new { HttpStatusCode = Response.HttpStatusCode, Message = Response.ID });
        }

        [HttpGet("GetByID")]
        public async Task<ActionResult<VendedoresResponseGetByID>>
        GetByID([FromBody] VendedoresQueryGetByID query, CancellationToken cancellationToken)
        {

            var Response = await _mediatR.Send(query);

            if (Response.HttpCodeStatus == 404)
            {
                return NotFound();
            }

            return Ok(new { HttpStatusCode = Response.HttpCodeStatus,Message =  Response.Vendedores });
        }

        [HttpPut("UpdateVendedor")]
        public async Task<ActionResult<VendedoresResponseHTTP>>
        UpdateVendedor ([FromBody] VendedoresCommandUpdate command, CancellationToken cancellationToken)
        {
            var Response = await _mediatR.Send(command);

            if (Response.HttpCodeStatus == 400)
            {
                return BadRequest(new { HttpStatus = Response.HttpCodeStatus, Message = Response.HttpMessage });
            }

            return Ok(new { HttpStatusCode = Response.HttpCodeStatus, Message = Response.HttpMessage });
        }

        [HttpDelete("DeleteVendedor")]
        public async Task<ActionResult<VendedoresResponseHTTP>>
        DeleteVendedor([FromBody] VendedoresCommandDelete command, CancellationToken cancellationToken)
        {
            var Response = await _mediatR.Send(command);

            if (Response.HttpCodeStatus == 400)
            {
                return BadRequest(new { HttpStatus = Response.HttpCodeStatus, Message = Response.HttpMessage });
            }

            return Ok(new { HttpStatusCode = Response.HttpCodeStatus, Message = Response.HttpMessage });
        }
    }
}