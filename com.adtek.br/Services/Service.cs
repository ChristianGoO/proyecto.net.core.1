using com.adtek.br.Dtos;
using com.adtek.br.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Services
{
    public class Service
    {

        public Result<T> GeneraError<T>(Exception ex)
        {
            ApiException apiException;

            if (ex is ApiException) 
            {
                apiException = (ApiException)ex;
            }
            else 
            {
                apiException = new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.Message);
            }

            Result<T> result = new Result<T>();
            result.Codigo = apiException.Code;
            result.Mensaje = apiException.Message;
            result.Detalles = apiException.Detalles;
            
            return result;
        }
    }
}
