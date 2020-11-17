using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace connectoToPostgres.AbstractClass
{
    public abstract class Pagos
    {
        public abstract int CalculateTotal(int initial, int end);

        public int GetTotal(int initial, int end)
        {
            initial += 3;
            end += 5;
            
            var total = this.CalculateTotal(initial, end);
            return total;
        }
    }
}
