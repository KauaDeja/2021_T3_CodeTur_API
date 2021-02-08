using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class PacotesTestes
    {
        // Fact serve como fato na hora de testar
        [Fact]
        public void DeveRetornarErroSePacoteInvalido()
        {
            var pacote = new Pacote("Viagem a Cuba", "Melhor Arquipélago do Mundo","", false);
            Assert.True(pacote.Invalid, "Pacote é válido");
        }

        [Fact]
        public void DeveRetornarSucessoSePacoteInvalido()
        {
            var pacote = new Pacote("Viagem a Cuba", "Melhor Arquipélago do Mundo", "Imagem Cuba",true);
            Assert.True(pacote.Valid, "Pacote é válido");
        }
    }
}
