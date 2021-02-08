using CodeTur.Comum.Commands;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Pacote
{
    public class CriarPacoteHandleTestes
    {
        [Fact]
        public void DeveRetornarErroSeDadosHandlerPacoteInvalidos()
        {
            // Criar um command
            var command = new CriarPacoteCommand("", "País Exótico", "png.1", true);

            // Criar um Handle
            // Criar um Fake Repositorie
            // Ou podemos usar o mock
            var handle = new CriarPacoteHandle(new FakePacoteRepositorio());

            // Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);

            //Valida a condição
            Assert.False(resultado.Sucesso, "O pacote é válido");

        }

        [Fact]
        public void DeveRetornarErroSeDadosHandlerInvalidos()
        {
            //Criar um command
            var command = new CriarPacoteCommand("Viagem para Austrália", "País Exótico", "png.1", true);

            //Criar um handle        
            var handle = new CriarPacoteHandle(new FakePacoteRepositorio());

            //Pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);

            //Valida a condição
            Assert.True(resultado.Sucesso, "O pacote é válido");


        }
    }
}
