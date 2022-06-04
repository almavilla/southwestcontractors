using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        //(string name, object key) : 
        //base($"{name} ({key}) is not found")
        public NotFoundException(string name, object key) :
            base($"{name} ({key}) is not found")
        {
        }
    }
}
