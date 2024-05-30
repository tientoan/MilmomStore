using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.Model
{
    public class Transaction
    {
        [Key]
        public string ResponseId { get; set; }
        //
        //public int OrderID { get; set; }
        //[ForeignKey("OrderID")]
        public Order? Order { get; set; } = null!;

        public string TmnCode { get; set; }

        public string TxnRef { get; set; }

        public int Amount { get; set; }

        public int OrderInfo { get; set; }

        public int ResponseCode { get; set; }

        public string Message { get; set; }

        public string BankCode { get; set; }

        public int TransactionNo { get; set; }

        public int TransactionType { get; set; }

        public int TransactionStatus { get; set; }

        public string SecureHash { get; set; }

    }
}
