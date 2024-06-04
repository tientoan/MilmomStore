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
        string createToken(AccountApplication application);
    }
}
