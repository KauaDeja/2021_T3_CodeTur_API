using CodeTur.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Infra.Data.Contexts
{
    public class CodeTurContext : DbContext
    {
         public CodeTurContext(DbContextOptions<CodeTurContext> options) : 
            base(options) 
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pacote> Pacotes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        // Configurar minha tabela desejada
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignorar notifictaions
            modelBuilder.Ignore<Notification>();

            #region Mapeamento Tabela Usuários
            modelBuilder.Entity<Usuario>().ToTable("Usuários");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();

            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //Comentários
            //Relacionamento de 1 para muitos
            modelBuilder.Entity<Usuario>()
                .HasMany(c => c.Comentarios)
                .WithOne(u => u.Usuario)
                .HasForeignKey(fk => fk.IdUsuario);

            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");


            #endregion

            #region Mapeamento Tabela Pacotes
            modelBuilder.Entity<Pacote>().ToTable("Pacotes");
            modelBuilder.Entity<Pacote>().Property(x => x.Id);

            //Titulo
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).HasMaxLength(40);
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).HasColumnType("varchar(40)");
            modelBuilder.Entity<Pacote>().Property(x => x.Titulo).IsRequired();

            //Descricao
            modelBuilder.Entity<Pacote>().Property(x => x.Descricao).HasColumnType("Text");
            modelBuilder.Entity<Pacote>().Property(x => x.Descricao).IsRequired();

            //Imagem
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).HasMaxLength(80);
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).HasColumnType("varchar(80)");
            modelBuilder.Entity<Pacote>().Property(x => x.Imagem).IsRequired();

            //Ativo
            modelBuilder.Entity<Pacote>().Property(x => x.Ativo).HasColumnType("bit");

            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            #region Mapeamento Tabela Comentarios
            modelBuilder.Entity<Comentario>().ToTable("Comentarios");
            modelBuilder.Entity<Comentario>().Property(x => x.Id);

            //Texto
            modelBuilder.Entity<Comentario>().Property(x => x.Texto).HasMaxLength(200);
            modelBuilder.Entity<Comentario>().Property(x => x.Texto).HasColumnType("varchar(500)");
            modelBuilder.Entity<Comentario>().Property(x => x.Texto).IsRequired();

            //Sentimento
            modelBuilder.Entity<Comentario>().Property(x => x.Sentimento).HasMaxLength(30);
            modelBuilder.Entity<Comentario>().Property(x => x.Sentimento).HasColumnType("varchar(100)");
            modelBuilder.Entity<Comentario>().Property(x => x.Sentimento).IsRequired();

            //Status
            modelBuilder.Entity<Comentario>().Property(x => x.Status).HasColumnType("int");


            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");
            #endregion

            base.OnModelCreating(modelBuilder);
        }


    }
}
