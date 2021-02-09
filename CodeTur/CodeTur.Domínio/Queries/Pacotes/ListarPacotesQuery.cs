using CodeTur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Dominio.Queries.Pacotes
{
    public class ListarPacotesQuery : IQuery
    {
        public bool Ativo { get; set; }
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }

    public class ListarPacotesQueryResult
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int QuantidadeComentarios { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
