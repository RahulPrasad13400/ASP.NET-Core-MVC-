using e_commerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
