using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApplication.Models
{
    public class Product
    {
        [Display(Name="Product Id")]
        public int ProductId { set; get; }

        [Display(Name = "Product Name")]
        [DataType(DataType.Text)]
        [Required (ErrorMessage ="plese enter product name")]
        public string ProductName { set; get; }


        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "This field is Required")]
        public Decimal Rate { set; get; }


        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "plese enter product description")]
        public string Description { set; get; }

        [Display(Name = "Category Name")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "plese enter Category name")]
         public string CategoryName{ set; get; }



    }
}