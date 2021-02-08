using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Repositorios
{
    public interface IComentarioRepositorio
    {
        void Adicionar(Comentario comentario);
        void Alterar(Comentario comentario);
        Comentario BuscarPorComentario(string texto);
        Comentario BuscarPorId(Guid id);
        ICollection<Comentario> Listar();
    }
}
