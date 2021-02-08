using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Testes.Repositorios
{
    public class FakeComentariosRepositorio : IComentarioRepositorio
    {
        //var comentario = new Comentario("Pacote com ótimo preço","Coração",EnStatusComentario.Publicado);
        List<Comentario> __comentarios = new List<Comentario>()
            {
                new Comentario("Pacote com ótimo preço","Coração",new Guid("9F73D5B2-1F1D-4A64-8450-9D5AB6233106"),new Guid("1240624A-44B1-4B7E-A75B-41B8EACB68DD"), EnStatusComentario.Publicado),
                new Comentario("Viagem Perfeita","Coração",new Guid("9F73D5B2-1F1D-4A64-8450-9D5AB6233106"),new Guid("1240624A-44B1-4B7E-A75B-41B8EACB68DD"), EnStatusComentario.Publicado),

            };
        public void Adicionar(Comentario comentario)
        {
            __comentarios.Add(comentario);        
        }

        public void Alterar(Comentario comentario)
        {

        }

        public Comentario BuscarPorComentario(string texto)
        {
            return __comentarios.FirstOrDefault(u => u.Texto == texto);
        }

        public Comentario BuscarPorId(Guid id)
        {
            return __comentarios.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<Comentario> Listar()
        {
            return __comentarios;
        }

     
    }
}

