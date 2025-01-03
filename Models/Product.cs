using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NimapInfotech.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }        
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual Category Category { get; set; }
    }

}
