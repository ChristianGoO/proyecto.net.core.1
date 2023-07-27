using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Exceptions
{
    public class ConflictException : ApiException
    {
        public ConflictException(string message): base((int)HttpStatusCode.Conflict, message) { }

        public ConflictException(string message, params string[] detalles): base((int)HttpStatusCode.Conflict, message, detalles) { }
    }
}
