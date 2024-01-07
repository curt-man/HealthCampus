using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCampus.CommonUtilities.Exceptions
{
    internal class NotImplementedException : Exception
    {
        public NotImplementedException(string message, Exception? innerException = null) : base(message, innerException)
        {
        }
    }
}
