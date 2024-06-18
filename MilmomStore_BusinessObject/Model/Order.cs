﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.Model
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
        public double Total { get; set; }

        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public AccountApplication AccountApplication { get; set; }

        public string? transactionID { get; set; }
        public int? ShippingInforID { get; set; }
        //
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Transaction Transaction { get; set; }
        public ShippingInfor ShippingInfor { get; set; } = null!;

    }
    public enum OrderStatus
    {
        ToPay = 0,
        ToShip = 1,
        ToReceive = 2,
        Completed = 3,
        Cancelled = 4,
        ReturnRefund = 5,
    }

}
