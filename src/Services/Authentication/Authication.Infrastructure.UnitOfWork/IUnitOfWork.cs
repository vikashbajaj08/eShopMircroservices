using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authication.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; }

        IDbConnection Connection { get; }

        IWork Begin();
    }
}
