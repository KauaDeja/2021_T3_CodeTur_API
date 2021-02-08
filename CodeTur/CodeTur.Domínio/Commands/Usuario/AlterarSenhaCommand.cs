using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    class AlterarSenhaCommand : Notifiable, ICommand
    {
        public AlterarSenhaCommand(Guid idUsuario, string senha)
        {
            IdUsuario = idUsuario;
            Senha = senha;
        }

        public Guid IdUsuario { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()  
               .HasMinLen(Senha, 6, "Senha", "A senha deve ter pelo menos 6 caracteres")
               .HasMaxLen(Senha, 12, "Senha", "A nome deve ter no máximo 12 caracteres")
               .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe um Id usuário válido")
               );
        }
    }
}
