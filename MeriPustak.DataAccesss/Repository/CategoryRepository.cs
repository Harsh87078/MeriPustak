using MeriPustak.DataAccess.Data;
using MeriPustak.DataAccesss.Repository.IRepository;
using MeriPustak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeriPustak.DataAccesss.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private readonly MeriPustakDbContext _db;
        public CategoryRepository(MeriPustakDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
