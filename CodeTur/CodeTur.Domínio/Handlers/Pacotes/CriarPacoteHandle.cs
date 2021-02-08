using CodeTur.Comum.Commands;
using CodeTur.Comum.Handlers;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class CriarPacoteHandle : IHandler<CriarPacoteCommand>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;

        public CriarPacoteHandle(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }


        public ICommandResult Handle(CriarPacoteCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do pacote inválidos", command.Notifications);

            // Verificar se existe alum pacote igual cadastrado
            var pacoteExiste = _pacoteRepositorio.BuscarPorPacote(command.Titulo);

            if (pacoteExiste != null)
                return new GenericCommandResult(true, "Pacote já cadastrado", null);

            // Salvar pacote
            var pacote = new Pacote(command.Titulo, command.Descricao, command.Imagem, command.Ativo);

            if (pacote.Invalid)
                return new GenericCommandResult(false, "Pacote Inválido", command.Notifications);

            // Slavr pacote no banco
            _pacoteRepositorio.Adicionar(pacote);

            // Mensagem sucesso
            return new GenericCommandResult(true, "Pacote criado", pacote);
        }
    }
}
