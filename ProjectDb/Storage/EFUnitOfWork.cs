using Domain.Entities;
using Domain.Interfaces;
using ProjectDb.EF;
using ProjectDb.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDb.Storage
{
    /// <summary>
    /// This class gives access to 
    /// properties in application context.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private ApplicationContext db;
        private IRepository<User> userRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            if(context != null)
            {
                db = context;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Getting user repository
        /// </summary>
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        /// <summary>
        /// Clearing context
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        /// <summary>
        /// Disposing data
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
