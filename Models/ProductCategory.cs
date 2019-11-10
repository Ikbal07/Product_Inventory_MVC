using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Inventory.Business
{
    //Product Category information
    public class ProductCategory
    {
        
        //Product category primary key
        public int Id{ get; set; }

        //Category name
        public string Name { get; set; }

        //Category code
        [NotMapped]
        public string CategoryCode {
            get { return "CAT0000" + Id; }  
        }

        //Category display name
        [NotMapped]
        public string CategoryDisplayName
        {
            get { return "CAT0000" + Id +"-"+Name; }
        }

        //Category description.
        public string Description { get; set; }
    }
}
