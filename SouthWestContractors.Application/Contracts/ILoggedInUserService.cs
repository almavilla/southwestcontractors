using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Contracts
{
    public interface ILoggedInUserService
    {
        //only get
        public string UserId { get; }
    }
}
