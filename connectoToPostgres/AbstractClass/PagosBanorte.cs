﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connectoToPostgres.AbstractClass
{
    public class PagosBanorte : Pagos
    {
        public override int CalculateTotal(int initial, int end)
        {
            return initial * end;
        }
    }
}
