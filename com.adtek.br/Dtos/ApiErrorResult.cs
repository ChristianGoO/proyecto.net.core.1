using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Dtos
{
    public class ApiErrorResult<T>
    {
        public int codigo { set; get; }

        public string? mensaje { set; get; }

        public IEnumerable<string>? detalles { set; get; }
    }
}
