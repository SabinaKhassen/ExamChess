﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories;
using System.Data.Entity;

namespace DataLayer.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        protected readonly DbContext db;
        protected bool disposed = false;

        Repository<T> entityRepository;

        public Repository<T> EntityRepository
        {
            get
            {
                return entityRepository == null ? new Repository<T>(db) : entityRepository;
            }
        }

        public UnitOfWork(DbContext db)
        {
            this.db = db;
        }

        public void BeginTransaction()
        {
            db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            db.Database.CurrentTransaction.Commit();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (db != null) db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
