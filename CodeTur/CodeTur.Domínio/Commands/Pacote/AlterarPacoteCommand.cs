using CodeTur.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacote
{
    public class AlterarPacoteCommand : Notifiable, ICommand
    {
        public AlterarPacoteCommand(string titulo, string descricao, string imagem, bool ativo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Ativo = ativo;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
              .Requires()
              .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o titulo do pacote")
              .IsNotNullOrEmpty(Descricao, "Descricao", "Informe a descrição do pacote")
              .IsNotNullOrEmpty(Imagem, "Imagem", "Informe a Imagem do pacote")
              );
        }
    }
}
