using CR.FacturaElectronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorSeccionOtros : ICreadorOtros<FacturaElectronicaOtros>
    {
        public FacturaElectronicaOtros CrearSeccionDeOtros(Dictionary<string, string> argumentos)
        {
            if (argumentos == null) return null;
            var otros = new FacturaElectronicaOtros();
            
            otros.OtroTexto = new FacturaElectronicaOtrosOtroTexto[argumentos.Count];
            var contador = 0;
            argumentos.ToList().ForEach(t =>
            {
                otros.OtroTexto[contador] = new FacturaElectronicaOtrosOtroTexto {
                    codigo = t.Key,
                    Value = t.Value
                };
                contador++;
            });

            return otros;
        }
    }
}
