using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersCRUDAppCore.DataAccess.Data;
using TrainersCRUDAppCore.DataAccess.Repository.IRepository;
using TrainersCRUDAppCore.Models;

namespace TrainersCRUDAppCore.DataAccess.Repository
{
    public class TrainerRepository : Repository<Trainer>, ITrainerRepository
    {
        private readonly ApplicationDbContext _db;

        public TrainerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Trainer obj)
        {
            _db.Trainers.Update(obj);
        }
    }
}
