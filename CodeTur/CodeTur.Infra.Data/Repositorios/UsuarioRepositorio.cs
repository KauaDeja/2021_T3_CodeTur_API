﻿using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using CodeTur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CodeTurContext _context;

        public UsuarioRepositorio(CodeTurContext context)
        {
            _context = context;
        }
        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);

        }

        public ICollection<Usuario> Listar()
        {
            return _context.Usuarios
                    .AsNoTracking()
                    .Include(u => u.Comentarios)
                    .OrderBy(u => u.DataCriacao)
                    .ToList();

        }
    }
}
