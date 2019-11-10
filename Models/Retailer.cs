using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Inventory.Business
{
    //Retailer information
    public class Retailer
    {
        //Retailer Id primary key
        public int Id { get; set; }

        //Retailer name.
        public string Name { get; set; }

        //Retailer contact number
        public string ContactNumber { get; set; }

        //Retailer code 
        [NotMapped]
        public string RetailerCode
        {
            get { return "RET0000" + Id; }
        }

        //Retailer display name.
        [NotMapped]
        public string RetailerDisplayName
        {
            get { return "RET0000" + Id + "-" + Name; }
        }


    }
   
   
}
