using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string message): base((int)HttpStatusCode.NotFound, message) { }

        public NotFoundException(string message, params string[] detalles): base((int)HttpStatusCode.NotFound, message, detalles) { }
    }
}
