using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CR.FacturaElectronica.Entidades;

namespace CR.FacturaElectronica
{
    public interface IDocumentoProcesador
    {

        #region Propiedades
        
        List<LineaDetalle> Productos { get; set; }
        Encabezado Encabezado { get; set; }
        Resumen Resumen { get; set; }
        DocumentoReferencia[] DocsReferencia { get; set; }

        #endregion

        #region Procesos
        string CrearXML();
        #endregion
    }
}
