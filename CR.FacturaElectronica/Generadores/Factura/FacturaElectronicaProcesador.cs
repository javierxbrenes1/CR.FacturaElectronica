using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaElectronicaProcesador :IDocumentoProcesador
    {
        #region Propiedades
        public List<LineaDetalle> Productos { get; set; }

        public Encabezado Encabezado { get; set; }

        public Resumen Resumen { get; set; }

        public DocumentoReferenciaSistema[] DocsReferencia { get; set; }

        public Dictionary<string, string> SeccionOtros { get; set; }

        #endregion

        public string CrearXML()
        {
            var factura = new CR.FEL.Encabezados.FacturaElectronica();
            factura.Clave = Encabezado.Clave;
            factura.NumeroConsecutivo = Encabezado.NumeroConsecutivo;
            factura.FechaEmision = Encabezado.FechaEmision;
            factura.Emisor = new FacturaCreadorEmisor().CrearPersona(Encabezado.Emisor);
            factura.Receptor = new FacturaCreadorReceptor().CrearPersona(Encabezado.Receptor);
            factura.CondicionVenta = ModFunciones.ObtenerValorEnumerador(Encabezado.CondicionVenta, CR.FEL.Detalles.Enumeradores.CondicionVenta.Item99);
            factura.PlazoCredito = Encabezado.PlazoCredito;
            factura.MedioPago = AsignarMediosPago();
            factura.DetalleServicio = new FacturaCreadorDetalles().DefinirDetalles(Productos);
            factura.ResumenFactura = new FacturaCreadorResumen().CrearResumen(Resumen);
            factura.InformacionReferencia = new FacturaCreadorDocumentoReferencia().CrearArregloReferencias(DocsReferencia);
            factura.Normativa = AsignarNormativa();
            factura.Otros = new FacturaCreadorSeccionOtros().CrearSeccionDeOtros(SeccionOtros);
            return ModFunciones.ObtenerXMLComoString(factura);
        }

        private CR.FEL.Detalles.Enumeradores.MedioPago[] AsignarMediosPago()
        {
            var medioPagos = new CR.FEL.Detalles.Enumeradores.MedioPago[Encabezado.MediosPago.Length];
            for (int i = 0; i < Encabezado.MediosPago.Length; i++)
            {
                medioPagos[i] = ModFunciones.ObtenerValorEnumerador(Encabezado.MediosPago[i], CR.FEL.Detalles.Enumeradores.MedioPago.Item99);
            }
            return medioPagos;
        }

        private CR.FEL.Detalles.Normativa AsignarNormativa()
        {
            var normativa = new CR.FEL.Detalles.Normativa();
            normativa.NumeroResolucion = Encabezado.NormativaNombre;
            normativa.FechaResolucion = Encabezado.NormativaFecha;
            return normativa;
        }
    }
}