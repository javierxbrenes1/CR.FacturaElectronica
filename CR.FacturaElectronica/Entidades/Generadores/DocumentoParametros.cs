using CR.FacturaElectronica.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public class DocumentoParametros
    {
        

        public int Terminal { get; set; }
        public int Sucursal { get; set; }
        public long ConsecutivoSistema { get; set; }
        public EnumeradoresFEL.enmTipoDocumento TipoDocumento { get; set; }

        public Encabezado Encabezado { get; set; }
        public List<LineaDetalle> LineasDetalle { get; set; }
        public Resumen Resumen { get; set; }
        public List<DocumentoReferencia> DocumentosReferencia { get; set; }

        public  bool EsUnReproceso { get; set; }
    }
}
