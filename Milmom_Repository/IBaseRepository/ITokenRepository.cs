﻿using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.IBaseRepository
{
    public interface ITokenRepository
    {
       public Task<string> createToken(AccountApplication application);
    }
}
