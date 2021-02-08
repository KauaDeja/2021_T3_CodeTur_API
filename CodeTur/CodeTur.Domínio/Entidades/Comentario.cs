using CodeTur.Comum.Entidades;
using CodeTur.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Entidades
{
    public class Comentario : Entidade
    {
        public Comentario(string texto, string sentimento, Guid idUsuario, Guid idPacote, EnStatusComentario status)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(texto, "Texto", "Informe o Texto do comentário")
                .IsNotNullOrEmpty(sentimento, "Sentimento", "Informe o sentimento do comentário")
                .AreNotEquals(idUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário")
                .AreNotEquals(idPacote, Guid.Empty, "IdPacote", "Informe o Id do Pacote do comentário")
            );

            if (Valid)
            {
                Texto = texto;
                Sentimento = sentimento;
                IdUsuario = idUsuario;
                IdPacote = idPacote;
                Status = status;
            }

        }

        private readonly List<Comentario> _comentarios;
        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }
        public Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid IdPacote { get; private set; }
        public virtual Pacote Pacote { get; private set; }
        public IReadOnlyCollection<Comentario> Comentarios { get { return _comentarios.ToArray(); } }


        public void ExcluirComentario(Comentario comentario)
        {
            if (Valid)
                _comentarios.Remove(comentario);
        }
        public void AtualizarComentario(string texto, string sentimento)
        {
            AddNotifications(new Contract()
                   .Requires()
                .IsNotNullOrEmpty(sentimento, "Sentimento", "Informe o sentimento do comentario")
                .IsNotNullOrEmpty(texto, "Texto", "Informe o texto do comentario")
                    );

            if (Valid)
               Texto = texto;
            Sentimento = sentimento;

        }

    }
}
