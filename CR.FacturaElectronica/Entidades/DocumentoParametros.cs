using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public class DocumentoParametros
    {
        public enum enmTipoDocumento {
            Factura = 1,
            NotaDebito = 2,
            NotaCredito = 3,
            Tiquete = 4,
            ConfirmacionAceptacion = 5,
            ConfirmacionAceptacionParcial = 6,
            ConfirmacionRechazo = 7
        }

        public int Terminal { get; set; }
        public int Sucursal { get; set; }
        public long ConsecutivoSistema { get; set; }
        public enmTipoDocumento TipoDocumento { get; set; }

        public Encabezado Encabezado { get; set; }
        public List<LineaDetalle> LineasDetalle { get; set; }
        public Resumen Resumen { get; set; }
        public List<DocumentoReferencia> DocumentosReferencia { get; set; }

        public  bool EsUnReproceso { get; set; }
    }
}
