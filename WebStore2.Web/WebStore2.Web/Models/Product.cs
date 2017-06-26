using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore2.Web.Models
{
    public class Product
    {
        public int id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле")]
        [StringLength(100)]
        [DisplayName("Наименование")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле")]
        [DisplayName("Цена")]
        public int Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Обязательное поле")]
        [StringLength(100)]
        [DisplayName("Категория товара")]
        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Category, Name);
        }
    }
}