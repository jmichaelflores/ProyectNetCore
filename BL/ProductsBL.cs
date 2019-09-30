using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class ProductsBL
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public List<Product> findAll()
        {
            return context.Products.ToList();
        }

        public Product findById(int id)
        {
            return context.Products.Include(x=>x.Category).FirstOrDefault(x=>x.id_product == id);
        }

        public void Update(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Save(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
