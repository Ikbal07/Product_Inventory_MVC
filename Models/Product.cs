using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Inventory.Business
{
    //Product information
    public class Product
    {

        //Product primary key.
        public int Id { get; set; }

        //Product Name
        public string ProductName { get; set; }

        //Product Price
        public decimal Price { get; set; }
        
        //Returns product Code
        [NotMapped]
        public string ProductCode {
            get { return "PRD0000" + Id; } 
        }

        //Product display name
        [NotMapped]
        public string ProductDisplayName
        {
            get { return "PRD0000" + Id + "-"+ProductName; }
        }

        //Product category Link
        public ProductCategory ProductCategory { get; set; }

        //Product category foriegn key.
        public int ProductCategoryId { get; set; }
    }


   


}
