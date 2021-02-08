using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Testes.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        List<Usuario> _usuarios = new List<Usuario>()
            {
                new Usuario("fernando", "email2@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum),
                new Usuario("priscila", "email3@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum)
            };

        public void Adicionar(Usuario usuario)
        {
            _usuarios.Add(usuario);
        }

        public void Alterar(Usuario usuario)
        {

        }

        public void AlterarSenha(Usuario usuario)
        {

        }

        public Usuario BuscarPorEmail(string email)
        {
            return _usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<Usuario> Listar()
        {
            return _usuarios;
        }
    }
}
