using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.Model
{
    [Table("ShippingInfor")]
    public class ShippingInfor
    {
        [ForeignKey("Order ")]
        public int ShippingInforID { get; set; }
        public string Address { get; set; }
        public string Receiver { get; set; }
        public string Phone { get; set; }
        public double ShippingCost { get; set; }
        //
        //public int OrderID { get; set; }

        public Order? Order { get; set; } = null!;

    }

}
