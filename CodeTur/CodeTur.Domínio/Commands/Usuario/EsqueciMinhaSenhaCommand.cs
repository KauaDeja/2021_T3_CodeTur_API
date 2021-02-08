﻿using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    public class EsqueciMinhaSenhaCommand : Notifiable, ICommand
    {
        public EsqueciMinhaSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
              .Requires()
              .IsEmail(Email, "Email", "Informe um email válido")
              );
        }
    }
}
