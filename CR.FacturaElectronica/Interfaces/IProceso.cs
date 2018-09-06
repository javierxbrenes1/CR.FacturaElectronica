using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Interfaces
{
    public interface IProceso<TRespuesta, TDocumento>
    {
        ConcurrentBag<TRespuesta> EjecutarProceso(IEnumerable<TDocumento> documentosAProcesar);
    }
}
