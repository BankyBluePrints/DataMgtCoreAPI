using System;
using System.Collections.Generic;
using System.Text;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;
using Dapper;
using System.Reflection;
using System.Data;
using static System.Data.CommandType;
using System.Linq;
using Dapper.FluentMap.Mapping;

namespace DataManagement.Repository
{

    //public class ProductMap : EntityMap<Product>
    //{
    //    public ProductMap()
    //    {
    //        // Map property 'Name' to column 'strName'.
    //        Map(p => p.Name)
    //            .ToColumn("strName");

    //        // Ignore the 'LastModified' property when mapping.
    //        Map(p => p.LastModified)
    //            .Ignore();
    //    }
    //}

    public class ProductRepository : BaseRepository, IRepository<Product>
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            var columnMap = new ColumnMap();
            columnMap.Add("Id", "ProductId");
            columnMap.Add("Name", "ProductName");
            columnMap.Add("Price", "ProductPrice");
            SqlMapper.SetTypeMap(typeof(Product), 
                new CustomPropertyTypeMap(typeof(Product), (type, columnName) => type.GetProperty(columnMap[columnName])));

           List<Product> products = SqlMapper.Query<Product>(
               Connection, "select * from Products", commandType: Text).ToList();

            return products;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
