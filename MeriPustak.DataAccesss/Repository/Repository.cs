﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeriPustak.DataAccess.Data;
using MeriPustak.DataAccesss.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MeriPustak.DataAccesss.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MeriPustakDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(MeriPustakDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //-db.Category == dbSet
            _db.Products.Include(u => u.Category).Include(u=> u.CategoryId);
        }

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        //Category,CoverType
        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
