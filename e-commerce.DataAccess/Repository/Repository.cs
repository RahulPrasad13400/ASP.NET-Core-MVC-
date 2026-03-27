using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using e_commerce.DataAccess.Repository.IRepository;
using e_commerce.Services;
using MongoDB.Driver;

namespace e_commerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;
        public Repository(MongoService mongoService)
        {
            _collection = mongoService.GetCollection<T>(typeof(T).Name);
        }
        public void Add(T entity)
        {
            _collection.InsertOne(entity);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _collection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public void Remove(T entity)
        {
            object id = GetId(entity);
            _collection.DeleteOne(Builders<T>.Filter.Eq("_id", id));
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            List<object> ids = [.. entities.Select(e => GetId(e))];
            _collection.DeleteMany(Builders<T>.Filter.In("_id", ids));
        }

        public void Update(T entity)
        {
            object id = GetId(entity);
            _collection.ReplaceOne(Builders<T>.Filter.Eq("_id",id), entity);
        }

        private object GetId(T entity)
        {
            PropertyInfo? props = typeof(T).GetProperty("Id");

            if (props != null)
                throw new Exception("Entity must have an Id Property");

            return props.GetValue(entity);
        }
    }
}
