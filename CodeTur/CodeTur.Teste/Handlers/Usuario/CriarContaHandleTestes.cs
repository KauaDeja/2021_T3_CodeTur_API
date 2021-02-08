using CodeTur.Comum.Commands;
using CodeTur.Comum.Enum;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Usuario
{
    public class CriarContaHandleTestes
    {
        [Fact]
        public void DeveRetornarErroSeDadosHandlerInvalidos()
        {
            //Criar um command
            var command = new CriarContaCommand("Kaua", "kaua@gmail.com", "123456", "", EnTipoUsuario.Admin);

            //Criar um handle
            var handle = new CriarContaHandle(new FakeUsuarioRepositorio()); // Criar um Fake Repositorie
                                                                             // Ou podemos usar o mock
            //Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);

            //Valida a condição
            Assert.False(resultado.Sucesso, "O usuario é válido");


        }

        [Fact]
        public void DeveRetornarErroSeDadosHandlerValidos()
        {
            //Criar um command
            var command = new CriarContaCommand("KauaDeja da Silva", "kaua@gmail.com", "12345678", "", EnTipoUsuario.Admin);

            //Criar um handle
            var handle = new CriarContaHandle(new FakeUsuarioRepositorio()); // Criar um Fake Repositorie
                                                                             // Ou podemos usar o mock
                                                                             //Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);

            //Valida a condição
            Assert.False(resultado.Sucesso, "O usuario é inválido");


        }
    }
}
