using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        void Save();
    }
}
