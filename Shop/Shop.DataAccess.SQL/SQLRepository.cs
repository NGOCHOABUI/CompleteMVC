﻿using Shop.Core.Contracts;
using Shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext _context;
        internal DbSet<T> _dbSet;

        //CONSTRUCTOR
        public SQLRepository(DataContext context){
            this._context = context;
            this._dbSet = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return _dbSet;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var t = _dbSet.Find(Id);
            if (_context.Entry(t).State == EntityState.Detached) {
                _dbSet.Attach(t);
            }
            _dbSet.Remove(t);
        }

        public T Find(string Id)
        {
            return _dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            _dbSet.Add(t);
        }

        public void Update(T t)
        {
            _dbSet.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
        }
    }
}
