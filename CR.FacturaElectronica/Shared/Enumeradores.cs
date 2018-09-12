using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Shared
{
    public class EnumeradoresFEL
    {
        public enum enmSituacionComprobante
        {
            Normal = 1,
            Contingencia = 2,
            Sin_Internet = 3
        }

        public enum TiposMetodo
        {
            GET,
            POST
        }

        public enum enmTipoDocumento
        {
            Factura = 1,
            NotaDebito = 2,
            NotaCredito = 3,
            Tiquete = 4,
            ConfirmacionAceptacion = 5,
            ConfirmacionAceptacionParcial = 6,
            ConfirmacionRechazo = 7
        }
    }
}
