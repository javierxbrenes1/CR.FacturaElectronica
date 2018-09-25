using CR.FacturaElectronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorSeccionOtros 
    {
        public CR.FEL.Detalles.Otros CrearSeccionDeOtros(Dictionary<string, string> argumentos)
        {
            if (argumentos == null) return null;
            var otros = new CR.FEL.Detalles.Otros();
            
            otros.OtroTexto = new CR.FEL.Detalles.OtrosOtroTexto[argumentos.Count];
            var contador = 0;
            argumentos.ToList().ForEach(t =>
            {
                otros.OtroTexto[contador] = new CR.FEL.Detalles.OtrosOtroTexto
                {
                    codigo = t.Key,
                    Value = t.Value
                };
                contador++;
            });

            return otros;
        }
    }
}
