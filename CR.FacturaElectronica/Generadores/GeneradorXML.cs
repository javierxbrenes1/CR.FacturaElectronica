using System;
using System.Collections.Generic;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica.Generadores
{
    internal class GeneradorXML : IGeneradorXML
    {
        public List<LineaDetalle> Productos { get; set; }
        public Encabezado Encabezado { get; set; }
        public ResumenFactura Resumen { get; set; }
        public DocumentoReferenciaSistema[] DocsReferencia { get; set; }
        public Dictionary<string, string> SeccionOtros { get; set; }

        public string CrearXML(EnumeradoresFEL.enmTipoDocumento tipoDoc)
        {
            throw new NotImplementedException();
        }
    }
}
