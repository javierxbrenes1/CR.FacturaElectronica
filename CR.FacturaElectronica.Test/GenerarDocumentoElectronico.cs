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
            Console.WriteLine(respuesta.ErrorMensaje);
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
                EsExonerado = true,
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
                Impuestos = getImpuestos(),
                Exoneracion =  exo(),
                NaturalezaDescuento = ""
            });

            return lista;
           
        }

        private List<Impuesto> getImpuestos()
        {
            var imp = new List<Impuesto>();
            imp.Add(new Impuesto { Tarifa = 0, MontoImpuesto = 0, CodigoImpuesto = "99" });
            return imp;
        }

        private Exoneracion exo()
        {
            return new Exoneracion()
            {
                FechaEmision = DateTime.Now,
                MontoImpuestoExon = 12,
                MontoTotalLinea = 12,
                NombreInstitucion = "Liceo experimental",
                NumeroDocumento = "123243",
                PorcentajeCompra = 100,
                TipoDocumento = "99"
            };
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
                TipoDocumento = Shared.EnumeradoresFEL.enmTipoDocumento.Factura,
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

            p.DocumentosReferencia.Add(new DocumentoReferencia()
            {
                Codigo = "",
                FechaEmision = DateTime.Now,
                Numero = "32323232",
                Razon = "prueba",
                TipoDoc = "00"
            });

            p.SeccionOtros = new Dictionary<string, string>();
            p.SeccionOtros.Add("llave 1", "valor 1");
            p.SeccionOtros.Add("llave 2", "valor 2");
            p.SeccionOtros.Add("llave 3", "valor 3");
            p.SeccionOtros.Add("llave 4", "valor 4");
            p.SeccionOtros.Add("llave 5", "valor 5");
            p.SeccionOtros.Add("llave 6", "valor 6");
            p.SeccionOtros.Add("llave 7", "valor 7");
            p.SeccionOtros.Add("llave 8", "valor 8");

            return p;
        }

    }


}
