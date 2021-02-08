using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Comentario;
using CodeTur.Dominio.Handlers;
using CodeTur.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Comentario
{
    public class CriarComentarioHandleTestes
    {
        [Fact]
        public void DeveRetornarErroSeDadosHandlerComentarioInvalidos()
        {
            // Criar um command
            var command = new CriarComentárioCommand("", "coração", Comum.Enum.EnStatusComentario.Publicado, new Guid("9F73D5B2-1F1D-4A64-8450-9D5AB6233106"), new Guid("9F73D5B2-1F1D-4A64-8450-9D5AB6233106"));

            //Criar um handle
            // Ou podemos usar o mock
            // Criar um Fake Repositorie
            var handle = new CriarComentarioHandlers(new FakeComentariosRepositorio()); 

            //Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);

            //Valida a condição
            Assert.False(resultado.Sucesso, "O Comentário é válido");

        }

        [Fact]
        public void DeveRetornarErroSeDadosHandlerComentarioValidos()
        {
            // Criar um command
            var command = new CriarComentárioCommand("Viagem Sensacional", "coração", Comum.Enum.EnStatusComentario.Publicado, new Guid("9F73D5B2-1F1D-4A64-8450-9D5AB6233106"), new Guid("9F73D5B2-1F1D-4A64-8450-9D5AB6233106"));

            //Criar um handle
            // Ou podemos usar o mock
            // Criar um Fake Repositorie
            var handle = new CriarComentarioHandlers(new FakeComentariosRepositorio());

            //Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);

            //Valida a condição
            Assert.True(resultado.Sucesso, "O Comentário é válido");

        }
    }
}
