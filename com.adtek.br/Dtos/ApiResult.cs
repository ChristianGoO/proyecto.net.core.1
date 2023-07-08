﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.adtek.br.Dtos
{
    public class ApiResult<T>
    {
        public int codigo { set; get; }

        public string? mensaje { set; get; }

        public T? resultado { set; get; }
    }
}
