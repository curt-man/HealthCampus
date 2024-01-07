using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCampus.CommonUtilities.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, Exception? innerException = null) : base(message, innerException)
        {
        }
    }
}
