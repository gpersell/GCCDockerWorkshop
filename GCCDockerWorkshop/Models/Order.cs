using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GCCDockerWorkshop.Models
{
    public class Order
    {
        [Key]
        public int Id {get; set;}
        public int OrderNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }

    }
}
