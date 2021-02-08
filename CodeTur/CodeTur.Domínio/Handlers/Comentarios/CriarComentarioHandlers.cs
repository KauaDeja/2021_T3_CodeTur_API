using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers;
using CodeTur.Dominio.Commands.Comentario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers
{
    public class CriarComentarioHandlers : IHandler<CriarComentárioCommand>
    {
        private readonly IComentarioRepositorio _comentarioRepositorio;

        public CriarComentarioHandlers(IComentarioRepositorio comentarioRepositorio)
        {
            _comentarioRepositorio = comentarioRepositorio;
        }

        public ICommandResult Handle(CriarComentárioCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do comentario inválido", command.Notifications);

            var comentario = new Comentario(command.Texto, command.Sentimento, command.IdUsuario, command.IdPacote, command.Status );

            // Salvar comentario
            if (comentario.Invalid)
                return new GenericCommandResult(false, "Comentario Inválido", command.Notifications);

            // Salvar comentario no banco
            _comentarioRepositorio.Adicionar(comentario);

            // Mensagem sucesso
            return new GenericCommandResult(true, "Comentario criado", comentario);
        }
    }
}
