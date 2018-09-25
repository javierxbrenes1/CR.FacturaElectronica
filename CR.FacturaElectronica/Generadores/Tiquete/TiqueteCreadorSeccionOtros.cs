using CR.FacturaElectronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Tiquete
{
    internal class TiqueteCreadorSeccionOtros : ICreadorOtros<TiqueteElectronicoOtros>
    {
        public TiqueteElectronicoOtros CrearSeccionDeOtros(Dictionary<string, string> argumentos)
        {
            if (argumentos == null) return null;
            var otros = new TiqueteElectronicoOtros();

            otros.OtroTexto = new TiqueteElectronicoOtrosOtroTexto[argumentos.Count];
            var contador = 0;
            argumentos.ToList().ForEach(t =>
            {
                otros.OtroTexto[contador] = new TiqueteElectronicoOtrosOtroTexto
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
