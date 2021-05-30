using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ArticlesProject.Repository.Interfaces;
using ArticlesProject.DBEntities;

namespace ArticlesProject.Repository.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private DatabaseContext context
        {
            get
            {
                return _db as DatabaseContext; 
            }
        }
        public ProductRepository(DbContext db) : base(db)
        {

        }
        public IEnumerable<ProductViewModel> GetProductList()
        {
            var products = (from prd in context.Products
                            join cat in context.Categories
                            on prd.CatId equals cat.CategoryId
                            select new ProductViewModel
                            {
                                ProductId = prd.ProductId,
                                Name = prd.Name,
                                Description = prd.Description,
                                CreatedDate = prd.CreatedDate,
                                UnitPrice = prd.UnitPrice,
                                Category = cat.Name
                            }).ToList();
            return products;
        }
    }
}
