using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersCRUDAppCore.Models;

namespace TrainersCRUDAppCore.DataAccess.Repository.IRepository
{
    public interface ITrainerRepository : IRepository<Trainer>
    {
        void Update(Trainer obj);
    }
}
