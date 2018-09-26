using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Shared;
using System.Collections.Generic;


namespace CR.FacturaElectronica.Entidades
{
    public class DocumentoParametros
    {
        

        public int Terminal { get; set; }
        public int Sucursal { get; set; }
        public long ConsecutivoSistema { get; set; }
        public bool EsUnReproceso { get; set; }
        public EnumeradoresFEL.enmTipoDocumento TipoDocumento { get; set; }

        public Encabezado Encabezado { get; set; }
        public List<LineaDetalleSistema> LineasDetalle { get; set; }
        public ResumenFactura Resumen { get; set; }
        public List<DocumentoReferenciaSistema> DocumentosReferencia { get; set; }

        public Dictionary<string, string> SeccionOtros { get; set; }
        
    }
}
