﻿using MilmomStore_BusinessObject.IdentityModel;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Repository.InterfaceRepository
{
    public interface ITokenRepository
    {
        public Task<TokenModel> createToken(AccountApplication application);
    }
}
