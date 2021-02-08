using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Testes.Repositorios
{
    class FakePacoteRepositorio : IPacoteRepositorio
    {
        List<Pacote> _pacotes = new List<Pacote>()
            {
                new Pacote("Viagem para Austrália", "País Exótico", "png.1",true),
                new Pacote("Viagem para Japão", "Tudo pago", "png.2",true),
            };

        public void Adicionar(Pacote pacote)
        {
            _pacotes.Add(pacote);
        }

        public void Alterar(Pacote pacote)
        {

        }

        public Pacote BuscarPorId(Guid id)
        {
            return _pacotes.FirstOrDefault(u => u.Id == id);
        }

        public Pacote BuscarPorPacote(string titulo)
        {
            return _pacotes.FirstOrDefault(u => u.Titulo == titulo);
        }

        IEnumerable<Pacote> IPacoteRepositorio.Listar(bool? ativo)
        {
            return _pacotes;
        }
    }
}
