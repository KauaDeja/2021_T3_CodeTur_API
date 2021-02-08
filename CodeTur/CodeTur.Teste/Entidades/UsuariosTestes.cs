
using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class UsuariosTestes
    {   // Fact serve como fato na hora de testar
        [Fact]
        public void DeveRetornarErroSeUsuarioInvalido()
        {
            var usuario = new Usuario("", "12345678", "kaua@gmail.com", EnTipoUsuario.Admin);
            Assert.True(usuario.Invalid, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarSucessoSeUsuarioInvalido()
        {
            var usuario = new Usuario("Kaua Deja", "12345678", "kaua@gmail.com", EnTipoUsuario.Admin);
            Assert.True(usuario.Valid, "Usuário é válido");
        }

        [Fact]
        public void DeveRetornarErroSeTelefoneUsuarioInvalido()
        {
            var usuario = new Usuario("Kaua Deja", "12345678", "kaua@gmail.com", EnTipoUsuario.Admin);
            usuario.AdicionarTelefone("11977376");
            Assert.True(usuario.Invalid, "Número de telefone é válido");
        }

        [Fact]
        public void DeveRetornarSucessoSeTelefoneUsuarioValido()
        {
            var usuario = new Usuario("Kaua Deja", "12345678", "kaua@gmail.com", EnTipoUsuario.Admin);
            usuario.AdicionarTelefone("11977376394");
            Assert.True(usuario.Valid, "Número de telefone é Invalido");
        }



    }
}
