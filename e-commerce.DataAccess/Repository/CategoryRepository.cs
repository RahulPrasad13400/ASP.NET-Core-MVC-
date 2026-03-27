using e_commerce.DataAccess.Repository.IRepository;
using e_commerce.Models;
using e_commerce.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace e_commerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MongoService _mongoService;
        public CategoryRepository(MongoService mongoService) : base(mongoService)
        {
            _mongoService = mongoService;
        }

        public void Update(Category obj)
        {
            _mongoService.GetCollection<Category>(typeof(Category).Name)
                .ReplaceOne(Builders<Category>.Filter.Eq(x => x.Id, obj.Id), obj);
        }
    }
}
