using e_commerce.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
