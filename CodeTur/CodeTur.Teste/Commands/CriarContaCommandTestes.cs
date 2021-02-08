using CodeTur.Comum.Enum;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Commands.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands
{
    public class CriarContaCommandTestes
    {
        [Fact]
        public void DeveRetornarErroSeDadosInvalido()
        {
            // Para que eu n precise passar os parametros basta eu criar um ctor vazio
            var command = new CriarPacoteCommand("Viagem para Austrália", "País Exótico", "png.1", true);


            command.Validar();

            Assert.True(command.Valid, "Pacote é válido");
        }

        [Fact]
        public void DeveRetornarErroSeDadosValidos()
        {
            // Para que eu n precise passar os parametros basta eu criar um ctor vazio
            var command = new CriarPacoteCommand("", "País Exótico", "png.1", true);

            command.Validar();

            // Se o meu objeto command passar pelas validacoes
            // Invalid = false
            // Se não Invalid = true

            // Valid = true
            // Se não = false

            Assert.True(command.Invalid, "Pacote é válido");
        }
    }
}
