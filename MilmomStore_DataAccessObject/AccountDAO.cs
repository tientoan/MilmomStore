using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;

namespace MilmomStore_DataAccessObject
{
    public class AccountDAO : BaseDAO<AccountApplication>
    {
        private readonly MilmomSystemContext _context;

        public AccountDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
