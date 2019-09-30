using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Category
    {
        [Key]
        public int id_category { set; get; }

        public string name { set; get; }

        public List<Product> Products { set; get; }

        ApplicationDbContext context = new ApplicationDbContext();

        public List<Category> findAll()
        {
            return context.Categories.ToList();
        }

        public Category findById(int id)
        {
            return context.Categories.Include(x => x.Products).FirstOrDefault(x => x.id_category == id);
        }

        public void Update(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Save(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

    }
}
