using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Exceptions
{
    public class ForbiddenException : ApiException
    {
        public ForbiddenException(string message) : base((int)HttpStatusCode.Forbidden, message) { }

        public ForbiddenException(string message, params string[] detalles) : base((int)HttpStatusCode.Forbidden, message, detalles) { }
    }
}
