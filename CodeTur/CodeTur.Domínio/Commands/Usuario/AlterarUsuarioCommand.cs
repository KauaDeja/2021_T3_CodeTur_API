﻿using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    public class AlterarUsuarioCommand : Notifiable, ICommand
    {
        public AlterarUsuarioCommand(string nome, string email)
        {
            Email = email;
            Nome = nome;
        }

        public string Nome { get; set; }
        public string Email { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
            .Requires()
                .HasMinLen(Nome, 3, "Nome", "O nome deve ter pelo menos 3 caracteres")
                .HasMaxLen(Nome, 40, "Nome", "O nome deve ter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "Informe um email válido")
              );
        }
    }
}
