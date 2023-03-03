using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecom.Models;

namespace Ecom.Db.Dboperation
{
   public class Categoryoperation
    {
        public int savecategory (Categorymodel model)
        {
            using (var context = new EcomdbEntities()) 
            {
                Category cc = new Category()
                { 
                Id=model.Id,
                Name=model.Name,
                Description=model.Description,
                ProductID=model.ProductID
                };
                context.Category.Add(cc);
                context.SaveChanges();
                return cc.Id;
            }
        }
        public List<Categorymodel> Getallcategory()
        {
            using (var context = new EcomdbEntities())
            {
                var result = context.Category.Select(x => new Categorymodel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ProductID = x.ProductID
                }).ToList();
                return result;
                // = context.Category.ToList();
                ////return result;
            }


        }
        public Categorymodel Getcategory(int id)
        {
            using (var context = new EcomdbEntities())
            {
                var result = context.Category.Where(x=>x.Id==id).Select(x => new Categorymodel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ProductID = x.ProductID
                }).FirstOrDefault();
                return result;
                // = context.Category.ToList();
                ////return result;
            }


        }
        public bool updatecategory(int id ,Categorymodel model) 
        {
            using (var context = new EcomdbEntities()) 
            {
                var category = context.Category.FirstOrDefault(x => x.Id == id);
                if (category != null) 
                {
                    category.Name = model.Name;
                    category.Description = model.Description;
                    category.ProductID = model.ProductID;
                }
                context.SaveChanges();
                return true;
            }
        }
        public bool deletecategory(int id) 
        {
            using (var context = new EcomdbEntities()) 
            {
                var category = context.Category.FirstOrDefault(x => x.Id == id);
                if (category != null) 
                {
                    context.Category.Remove(category);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
   
}
