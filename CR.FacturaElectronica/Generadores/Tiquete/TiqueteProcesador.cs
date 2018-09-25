using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica.Tiquete
{

    public class TiqueteProcesador : IDocumentoProcesador
    {
        #region Propiedades

         

        public List<LineaDetalle> Productos { get; set; }

        public Encabezado Encabezado { get; set; }

        public Resumen Resumen { get; set; }

        public DocumentoReferencia[] DocsReferencia { get; set; }

        public Dictionary<string, string> SeccionOtros { get; set; }

        #endregion

        #region Funciones

        // Retorna la ruta donde creo el archivo
        public string CrearXML()
        {
            var tiquete = new TiqueteElectronico();
            tiquete.Clave = Encabezado.Clave;
            tiquete.NumeroConsecutivo = Encabezado.NumeroConsecutivo;
            tiquete.FechaEmision = Encabezado.FechaEmision;
            tiquete.Emisor = new TiqueteCreadorEmisor().CrearPersona(Encabezado.Emisor);
            tiquete.Receptor = new TiqueteCreadorReceptor().CrearPersona(Encabezado.Receptor);
            tiquete.CondicionVenta = ModFunciones.ObtenerValorEnumerador(Encabezado.CondicionVenta, TiqueteElectronicoCondicionVenta.Item99);
            tiquete.PlazoCredito = Encabezado.PlazoCredito;
            tiquete.MedioPago = AsignarMediosPago();
            tiquete.DetalleServicio = new TiqueteCreadorDetalles().DefinirDetalles(Productos);
            tiquete.ResumenFactura = new TiqueteCreadorResumen().CrearResumen(Resumen);
            tiquete.InformacionReferencia = new TiqueteCreadorDocumentoReferencia().CrearArregloReferencias(DocsReferencia);
            tiquete.Normativa = AsignarNormativa();
            tiquete.Otros = new TiqueteCreadorSeccionOtros().CrearSeccionDeOtros(SeccionOtros);
            return ModFunciones.ObtenerXMLComoString(tiquete);

        }

        private TiqueteElectronicoMedioPago[] AsignarMediosPago()
        {
            var medioPagos = new TiqueteElectronicoMedioPago[Encabezado.MediosPago.Length];
            for (int i = 0; i < Encabezado.MediosPago.Length; i++)
            {
                medioPagos[i] = ModFunciones.ObtenerValorEnumerador(Encabezado.MediosPago[i], TiqueteElectronicoMedioPago.Item99);
            }
            return medioPagos;
        }

        private TiqueteElectronicoNormativa AsignarNormativa()
        {
            var normativa = new TiqueteElectronicoNormativa();
            normativa.NumeroResolucion = Encabezado.NormativaNombre;
            normativa.FechaResolucion = Encabezado.NormativaFecha;
            return normativa;
        }

        #endregion
    }
}
