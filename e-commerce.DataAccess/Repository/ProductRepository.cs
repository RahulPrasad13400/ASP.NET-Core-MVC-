using e_commerce.DataAccess.Repository.IRepository;
using e_commerce.Models.Models;
using e_commerce.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly MongoService _mongoService;
        public ProductRepository(MongoService mongoService) : base(mongoService)
        {
            _mongoService = mongoService;
        }

        public void Update(Product obj)
        {
            _mongoService.GetCollection<Product>("product")
                .ReplaceOne(Builders<Product>.Filter.Eq(p => p.Id, obj.Id), obj);
        }

    }
}
