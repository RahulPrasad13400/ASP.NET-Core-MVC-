using e_commerce.DataAccess.Repository.IRepository;
using e_commerce.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.DataAccess.Repository
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly MongoService _mongoService;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(MongoService mongoService)
        {
            _mongoService = mongoService;
            Category = new CategoryRepository(_mongoService);  
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
