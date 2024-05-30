using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_BusinessObject.Model
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        public string AccountID { get; set; }
        [ForeignKey("AccountID")]
        public AccountApplication Account { get; set; }

        public string Title { get; set; }
        
        public string Image { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;

        public DateTime UpdateAt { get; set; }

        public string Content { get; set; }

        public bool Status { get; set; }

    }
}
