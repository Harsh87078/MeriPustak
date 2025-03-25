using MeriPustak.DataAccess.Data;
using MeriPustak.DataAccesss.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeriPustak.DataAccesss.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MeriPustakDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(MeriPustakDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
