using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
    public class Product
    {
        [Key]
        public int id_product { set; get; }
        public string name { set; get; }

        [ForeignKey("Category")]
        public int category_id { set; get; }

        public Category Category { set; get; }



    }
}
