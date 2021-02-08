using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    public class EfetuarLoginCommand : Notifiable, ICommand
    {
        public EfetuarLoginCommand(string email, string senha)
        {
            Senha = senha;
            Email = email;
        }
        public string Senha { get; set; }
        public string Email { get; set; }
 

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .IsEmail(Email, "Email", "Informe um email válido")
               .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
               .HasMaxLen(Senha, 12, "Senha", "A nome deve ter no máximo 12 caracteres")
               );
        }
    }
}
