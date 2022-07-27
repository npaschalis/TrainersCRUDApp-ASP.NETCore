using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainersCRUDAppCore.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITrainerRepository Trainer { get; }

        void Save();
    }
}
