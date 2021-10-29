using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var result = _db.Products.FirstOrDefault(x => x.Id == product.Id);
            if (result != null)
            {
                if (result.ImageUrl !=null)
                {
                    result.ImageUrl = product.ImageUrl;
                }
                result.ISBN = product.ISBN;
                result.Price = product.Price;
                result.Price50 = product.Price50;
                result.ListPrice = product.ListPrice;
                result.Price100 = product.Price100;
                result.Title = product.Title;
                result.Description = product.Description;
                result.CategoryId = product.CategoryId;
                result.Author = product.Author;
                result.CoverTypeId = product.CoverTypeId;
                //_db.SaveChanges();
            }
        }
    }
}
