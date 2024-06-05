﻿using Milmom_Repository.IBaseRepository;
using Milmom_Service.IService;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        public TokenService(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public string createToken(AccountApplication application)
        {
            return _tokenRepository.createToken(application);
        }
    }
}
