using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    //V1 = versão 1 para que a manutenção seja feita no v2
    // Definir account para o ingles
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Route("signin")]
        [HttpPost]
        // Aqui nós passamos como parametro os Command e Handler
        public GenericCommandResult Signup(CriarContaCommand command,
                                                // Definimos que o CriarContaHanlde é um serviço
                                                [FromServices] CriarContaHandle handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
