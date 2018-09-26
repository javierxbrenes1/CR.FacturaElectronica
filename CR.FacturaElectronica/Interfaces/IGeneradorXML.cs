using System.Collections.Generic;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica
{
    public interface IGeneradorXML
    {

        #region Propiedades
        
        List<LineaDetalle> Detalles { get; set; }
        Encabezado Encabezado { get; set; }
        ResumenFactura Resumen { get; set; }
        DocumentoReferenciaSistema[] DocsReferencia { get; set; }
        Dictionary<string, string> SeccionOtros { get; set; }

        #endregion

        #region Procesos
        string CrearXML(EnumeradoresFEL.enmTipoDocumento tipoDoc);
        #endregion
    }
}
