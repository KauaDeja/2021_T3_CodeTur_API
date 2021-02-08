using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Commands
{
    public interface ICommand
    {
        // Para toda vez que o ICommand for herdado ele fará uma validação do meu comando
        void Validar();
    }
}
