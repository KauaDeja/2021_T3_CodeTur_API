using CodeTur.Comum.Commands;
using CodeTur.Comum.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Comum.Handlers
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        IQueryResult Handle(T query);
    }
}
