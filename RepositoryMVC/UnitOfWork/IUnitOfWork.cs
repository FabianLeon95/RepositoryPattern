using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryMVC.UnitOfWork
{
    public interface IUnitOfWork<out TContext> where TContext: DbContext, new()
    {
        TContext Context { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
