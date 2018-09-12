using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR.FacturaElectronica;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Interfaces;

namespace CR.FacturaElectronica.Test
{
    public class GenerarDocumentoElectronico
    {
        public void GenerarXMl()
        {
            ICreadorDocumentos creador = new CreadorDocumentos(obtenerConfiguracion());
            var respuesta = creador.CrearDocumentoXML(obtenerDocumento());
        }

        private ConfiguracionCreacionDocumentos obtenerConfiguracion()
        {
            ConfiguracionCreacionDocumentos c = new ConfiguracionCreacionDocumentos() {
                AlmacenarXMLsEnRutaRespaldos = true,
                HayInternet = true,
                LlaveCriptograficaClave = "1234",
                LlaveCriptograficaRuta = @"E:\FEL\010956066419.p12",
                RutaXMLRespaldos = @"E:\FEL\xmls",
                PoliticaDigest = "Nzk0MTgxMmYxYTNiNDlhYWIxNjkxZjgyMTk0ZTQzMGEzNTFjZTc1ZTA2M2EyMzk0ZjUyZDEyOWIyZTU2ZWM3MQ==",
                Politica = "https://tribunet.hacienda.go.cr/docs/esquemas/2016/v4.2/ResolucionComprobantesElectronicosDGT-R-48-2016_4.2.pdf",
                EmisorInformacion = new Persona() {
                    TipoIdentificacion = "02",
                    NumeroIdentificacion = "0109560664",
                    EsIdExtranjera = false, 
                    Nombre = "Percy Fernandez",
                    Provincia = "01",
                    Canton = "1",
                    Distrito = "1",
                    OtrasSennas = "direccion casa",
                    Correo = "percyfch2010@gmail.com",
                    Telefono=new Telefono() {
                        CodigoArea = "506",
                        Numero = "25368096"
                    },
                    NombreComercial = "Percy Fernandez"
                    
                }
            };
            
            return c;
        }

        private List<LineaDetalle> detalles()
        {
            var lista = new List<LineaDetalle>();

            lista.Add(new LineaDetalle()
            {
                Cantidad = 1,
                Codigo = "121",
                Detalle = "nanzana",
                EsExento = true,
                EsExonerado = false,
                DebeMostrarDescuento = false,
                EsPesable = false,
                EsServicio = false,
                PrecioUnitario = 100,
                MontoTotal = 100,
                MontoDescuento = 0,
                MontoTotalLinea = 100,
                UnidadMedidaOriginal = "Unid",
                UnidadMedida = "Unid",
                TipoCodigo = "1",
                SubTotal = 100,
                Impuestos = new List<Impuesto>(),
                Exoneracion = new Exoneracion(),
                NaturalezaDescuento = ""
            });

            return lista;
           
        }

        private DocumentoParametros obtenerDocumento()
        {
            DocumentoParametros p = new DocumentoParametros()
            {
                ConsecutivoSistema = 1,
                Encabezado = new Encabezado()
                {
                    CodigoMoneda = "CRC",
                    CondicionVenta = "02",
                    MediosPago = new string[] { "01" },
                    TotalDecimales = 5,
                    NormativaFecha = "07-10-2016 12:00:00",
                    NormativaNombre = "DGT-R-48-2016",
                    PlazoCredito = "30 dias"
                },
                EsUnReproceso = false,
                LineasDetalle = detalles(),
                Sucursal = 1,
                Terminal = 1,
                TipoDocumento = Shared.EnumeradoresFEL.enmTipoDocumento.Tiquete,
                Resumen = new Resumen()
                {
                    Moneda = "CRC",
                    TipoCambio = 1,
                    TotalComprobante = 100,
                    TotalDescuentos = 0,
                    TotalExento = 100,
                    TotalGravado = 0,
                    TotalImpuesto = 0,
                    TotalMercanciasExentas = 100,
                    TotalMercanciasGravadas = 0,
                    TotalServExentos = 0,
                    TotalServGravados = 0,
                    TotalVenta = 100,
                    TotalVentaNeta = 100
                },
                DocumentosReferencia = new List<DocumentoReferencia>()
            };
            



            return p;
        }

    }


}
