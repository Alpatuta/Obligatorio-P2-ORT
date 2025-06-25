using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PasajesPorPrecio : IComparer<Pasaje>
    {
        public int Compare(Pasaje? x, Pasaje? y)
        {
            if(x == null || y == null)
            {
                return 0;
            }

            return y.CostoPasaje().CompareTo(x.CostoPasaje());
        }
    }
}
