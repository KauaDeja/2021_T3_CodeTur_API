using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    public class LogarCommand : Notifiable, ICommand
    {
        public LogarCommand(string email, string senha)
        {
            Senha = senha;
            Email = email;
        }
        public string Email { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsEmail(Email, "Email", "Informe um email válido")
               .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
               );
        }
    }
}
