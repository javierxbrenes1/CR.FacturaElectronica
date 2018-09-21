using CR.FacturaElectronica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Generadores.Interfaces
{
    internal interface IDefinidorDetalles<T>
    {
        T[] DefinirDetalles(List<LineaDetalle> detallesDelSistema);
    }
}
