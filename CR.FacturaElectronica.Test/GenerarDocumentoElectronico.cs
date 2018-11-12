using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Test
{
    class GenerarDocumentoElectronico
    {
        public void GenerarXMl()
        {
            ICreadorDocumentos x = new CreadorDocumentos(obtenerConfiguracion());
            var xmlres = x.CrearDocumentoXML(obtenerInfoDoc());
        }

        private DocumentoParametros obtenerInfoDoc()
        {
            var param = new DocumentoParametros
            {
                ConsecutivoSistema = 2,
                Encabezado = new Encabezado {
                    CondicionVenta = "02",
                    MediosPago = new string[] { "01","02" },
                    PlazoCredito = "30 dias",
                    NormativaFecha = "07-10-2016 12:00:00",
                    NormativaNombre = "DGT-R-48-2016",
                },
                Sucursal = 1,
                Terminal = 1,
                TipoDocumento = Shared.EnumeradoresFEL.enmTipoDocumento.Tiquete,
                LineasDetalle = new List<LineaDetalleSistema>(),
                Resumen = new ResumenFactura {
                    CodigoMoneda = ResumenFactura.Moneda.CRC, 
                    TipoCambio = 1, 
                    TotalComprobante = 12
                    
                }
            };

            param.Encabezado.Receptor = new Receptor();
            param.LineasDetalle.Add(new LineaDetalleSistema {
                Cantidad = 1,
                Codigo = "121",
                Detalle = "nanzana",
                PrecioUnitario = 100,
                MontoTotal = 100,
                MontoDescuento = 0,
                MontoTotalLinea = 100,
                UnidadMedida = "Unid",
                TipoCodigo = "1",
                SubTotal = 100,
                Impuesto = getImpuestos(),
                NaturalezaDescuento = ""
            });

            

            return param;
        }

        private List<ImpuestoSistema> getImpuestos()
        {
            var imp = new List<ImpuestoSistema>();
            imp.Add(new ImpuestoSistema { Tarifa = 13, Codigo = "01", Monto = 20 });
            return imp;
        }

        private ConfiguracionCreacionDocumentos obtenerConfiguracion()
        {
            ConfiguracionCreacionDocumentos c = new ConfiguracionCreacionDocumentos()
            {
                AlmacenarXMLsEnRutaRespaldos = true,
                HayInternet = true,
                LlaveCriptograficaClave = "1234",
                LlaveCriptograficaRuta = @"E:\FEL\010956066419.p12",
                RutaXMLRespaldos = @"E:\FEL\xmls",
                PoliticaDigest = "Nzk0MTgxMmYxYTNiNDlhYWIxNjkxZjgyMTk0ZTQzMGEzNTFjZTc1ZTA2M2EyMzk0ZjUyZDEyOWIyZTU2ZWM3MQ==",
                Politica = "https://tribunet.hacienda.go.cr/docs/esquemas/2016/v4.2/ResolucionComprobantesElectronicosDGT-R-48-2016_4.2.pdf",

                EmisorInformacion = new Generadores.Detalles.Emisor {
                    Identificacion = new Generadores.Detalles.Identificacion
                    {
                        Tipo = Generadores.Detalles.Identificacion.IdentificacionTipo.Item02,
                        Numero = "0109560664"
                    },
                    CorreoElectronico = "percyfch2010@gmail.com",
                    Fax = new Generadores.Detalles.Telefono {
                        CodigoPais = "506",
                        NumTelefono = "25368096"
                    },
                    Ubicacion = new Generadores.Detalles.Ubicacion
                    {
                        Provincia = "01",
                        Canton = "1",
                        Distrito = "1",
                        OtrasSenas = "direccion casa"
                    },
                    Nombre = "Percy Fernandez",
                    NombreComercial = "Percy Fernandez",


                    Telefono = new Generadores.Detalles.Telefono()
                    {
                        CodigoPais = "506",
                        NumTelefono = "25368096"
                    },
                    
                }
           
            };

            return c;
        }
    }
}
