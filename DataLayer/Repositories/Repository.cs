using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext db = null;
        protected readonly DbSet<T> table = null;

        public Repository()
        {
            db = new Model1();
            table = db.Set<T>();
        }

        public Repository(DbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public void Add(T entity)
        {
            table.Add(entity);
        }

        public void Delete(int id)
        {
            T entity = table.Find(id);
            table.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
