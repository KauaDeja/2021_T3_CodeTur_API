using CodeTur.Dominio.Commands.Pacote;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Commands
{
    public class CriarPacoteCommandTestes
    {
        [Fact]
        public void DeveRetornarErroSeDadosPacoteInvalido()
        {
            // Para que eu n precise passar os parametros basta eu criar um ctor vazio
            var command = new CriarPacoteCommand();

            command.Validar();

            Assert.True(command.Invalid, "Pacote é válido");
        }

        //[Fact]
        //public void DeveRetornarErroSeDadosValidos()
        //{
        //    // Para que eu n precise passar os parametros basta eu criar um ctor vazio
        //    var command = new CriarContaCommand("Kaua", "kaua@gmail.com", "12345678","11977376394", EnTipoUsuario.Comum);

        //    command.Validar();

        //    // Se o meu objeto command passar pelas validacoes
        //    // Invalid = false
        //    // Se não Invalid = true

        //    // Valid = true
        //    // Se não = false

        //    Assert.True(command.Invalid, "Usuário é válido");
        //}
    }
}
