using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Dominio.Queries.Pacotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    [Route("v1/package")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public GenericCommandResult Create(CriarPacoteCommand command,
                                                [FromServices] CriarPacoteCommandHandle handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAll([FromServices] ListarPacoteQueryHandle handle)
        {
            ListarPacotesQuery query = new ListarPacotesQuery();

            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(t => t.Type == ClaimTypes.Role);

            if (tipoUsuario.Value.ToString() == EnTipoUsuario.Comum.ToString())
                query.Ativo = true;

            return (GenericQueryResult)handle.Handle(query);
        }


    }
}
