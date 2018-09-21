using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Interfaces
{
    internal interface ICreadorOtros<T>
    {
        T CrearSeccionDeOtros(Dictionary<string, string> argumentos);
    }
}
