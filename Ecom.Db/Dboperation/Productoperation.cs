using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Models;

namespace Ecom.Db.Dboperation
{
   public class Productoperation
    {
        public List<Productmodel> Getallproduct()
        {
            using (var context = new EcomdbEntities())
            {
                var result = context.Product.Select(x => new Productmodel()
                {
                    Id=x.Id,
                    Name=x.Name,
                    Description=x.Description,
                    price=x.price,
                    CategoryId=x.CategoryId
                }).ToList();
                return result;
                // = context.Category.ToList();
                ////return result;
            }


        }
        public int Saveproduct(Productmodel model) 
        {
            using (var context=new EcomdbEntities()) 
            {
                Product pr = new Product() 
                {
                Id=model.Id,
                Name=model.Name,
                Description=model.Description,
                price=model.price,
                CategoryId=model.CategoryId
                };
                context.Product.Add(pr);
                context.SaveChanges();
                return pr.Id;
            }
        }
        public Productmodel Getcategory(int id)
        {
            using (var context = new EcomdbEntities())
            {
                var result = context.Product.Where(x => x.Id == id).Select(x => new Productmodel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    price=x.price,
                    CategoryId=x.CategoryId
                }).FirstOrDefault();
                return result;
                // = context.Category.ToList();
                ////return result;
            }


        }
        public bool updateproduct(int id, Productmodel model)
        {
            using (var context = new EcomdbEntities())
            {
                var product= context.Product.FirstOrDefault(x => x.Id == id);
                if (product != null)
                {
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.price = model.price;
                    product.CategoryId = model.CategoryId;
                }
                context.SaveChanges();
                return true;
            }
        }
        public bool deleteproduct(int id) 
        {
            using (var context = new EcomdbEntities()) 
            {
                var result = context.Product.FirstOrDefault(x => x.Id == id);
                if (result != null) 
                {
                    context.Product.Remove(result);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
