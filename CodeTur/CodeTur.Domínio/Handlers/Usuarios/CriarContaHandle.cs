using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers;
using CodeTur.Comum.Utills;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class CriarContaHandle : IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CriarContaHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(CriarContaCommand command)
        {
            // Validar Command
            command.Validar();
            
            if(command.Invalid)
            return new GenericCommandResult(false, "Dados do usuário Inválidos", command.Notifications);

            //Verifica se email existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);


            //Criptografar Senha 
            command.Senha = Senha.Criptografar(command.Senha);

            //Salvar Usuário
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);
                if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AdicionarTelefone(command.Telefone);

            if(usuario.Invalid)
                return new GenericCommandResult(false, "Usuário Inválido", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);
            //Enviar Email de Boas Vindas
            //Send Grid

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
