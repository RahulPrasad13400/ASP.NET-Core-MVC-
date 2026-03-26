using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerce.DataAccess.Dtos
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string CollectionName { get; set; } = string.Empty;
    }
}
