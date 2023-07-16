using Library.DataAccess.Data;
using Library.DataAccess.Repository.IRepository;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
            _db= db;
        }

       

        public void Update(Product obj)
        {
            //_db.Products.Update(obj);

            var objFromDb = _db.Products.FirstOrDefault(u=>u.Id == obj.Id);

            if (objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                //objFromDb.Category = obj.Category;
                objFromDb.Author = obj.Author;
                objFromDb.CategoryId = obj.CategoryId;

                if(obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }


            }

        }
    }
}
