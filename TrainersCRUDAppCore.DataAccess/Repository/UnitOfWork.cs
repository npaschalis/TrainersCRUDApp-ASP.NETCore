using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainersCRUDAppCore.DataAccess.Data;
using TrainersCRUDAppCore.DataAccess.Repository.IRepository;

namespace TrainersCRUDAppCore.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Trainer = new TrainerRepository(_db);
        }
        public ITrainerRepository Trainer { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
