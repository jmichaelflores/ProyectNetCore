using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class CategoriesBL
    {

        Category category;

        public CategoriesBL()
        {
            category = new Category();
        }

        public List<Category> findAll()
        {
            return category.findAll();
        }

        public Category findById(int id)
        {
            return category.findById(id);
        }

        public void Update(Category category)
        {
            this.category.Update(category);
        }

        public void Save(Category category)
        {
            this.category.Save(category);
        }
        public void Delete(Category category)
        {
            this.category.Delete(category);
        }
    }
}
