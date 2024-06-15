using Microsoft.EntityFrameworkCore;
using MilmomStore_BusinessObject.Model;
using MilmomStore_DataAccessObject.BaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilmomStore_DataAccessObject
{
    public class RatingDAO : BaseDAO<Rating>
    {
        private readonly MilmomSystemContext _context;

        public RatingDAO(MilmomSystemContext context) : base(context)
        {
            _context = context;
        }
    }
}
