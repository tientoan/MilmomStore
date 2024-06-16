using Milmom_Repository.InterfaceRepository;
using Milmom_Service.InterfaceService;
using MilmomStore_BusinessObject.IdentityModel;
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

        public Task<TokenModel> createToken(AccountApplication application)
        {
            return _tokenRepository.createToken(application);
        }
    }
}
