using CodeTur.Comum.Commands;
using System;
using System.Collections.Generic;


namespace CodeTur.Comum.Handlers
{
    // Foi criado o handle para fazer a manipulação do command
    // Quem herdar desta classe, terá regras a serem seguidas
    // Handler: IHandler<Classe> se Classe : ICommand
    // Definindo que  ao herdar o IHandler

    public interface IHandler <T> where T: ICommand
    {
        // Para que retorne uma resposta
        ICommandResult Handle(T command);
    }
}
