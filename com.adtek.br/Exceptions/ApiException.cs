using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {

        public int Code { get; set; }

        public IEnumerable<string> Detalles { get; set; }

        public ApiException(string message, params string[] detalles) : base(message)
        {
            this.Code = (int)HttpStatusCode.Created;
            this.Detalles = detalles;
        }

        public ApiException(int code, string message, params string[] detalles) : base (message) 
        {
            this.Code = code;
            this.Detalles = detalles;
        }

        public ApiException(int code, string message, Exception inmer,params string[] detalles) : base(message, inmer)
        {
            this.Code = code;
            this.Detalles = detalles;
        }

        public ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Code = (int)HttpStatusCode.InternalServerError;
            this.Detalles = new List<string>();
        }
    }
}
