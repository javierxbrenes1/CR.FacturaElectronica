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
    internal class FacturaElectronicaProcesador :IDocumento
    {
        #region Propiedades


 

        public List<LineaDetalle> Productos { get; set; }

        public Encabezado Encabezado { get; set; }

        public Resumen Resumen { get; set; }

        public DocumentoReferencia[] DocsReferencia { get; set; }

        #endregion

        #region Funciones

        
        // Obtiene la lista de detalles
        private FacturaElectronicaLineaDetalle[] ObtenerDetalle(List<LineaDetalle> pvoListaProductos)
        {

            FacturaElectronicaLineaDetalle[] vloArrProductosNodos;
            FacturaElectronicaLineaDetalle vloProductoNodo;
            LineaDetalle vloProducto;
            Impuesto vloImp;
            try
            {
               //Define el total de productos
                //Encabezado.TotalLineasDetalle = Encabezado.TotalLineasDetalle > pvoListaProductos.Count ? pvoListaProductos.Count : Encabezado.TotalLineasDetalle;
                //Agrega el nodo padre
                vloArrProductosNodos = new FacturaElectronicaLineaDetalle[pvoListaProductos.Count];
                //Recorre la lista de los articulos
                for (int vlnI = 0; vlnI < pvoListaProductos.Count; vlnI++)
                {
                    //Obtengo el producto
                    vloProducto = pvoListaProductos[vlnI];
                    //Creo el campo linea de detalle
                    vloProductoNodo = new FacturaElectronicaLineaDetalle();
                    //Agrego el numero de linea
                    vloProductoNodo.NumeroLinea = (vlnI + 1).ToString();
                    //Agrego el codigo 
                    vloProductoNodo.Codigo = new CodigoType[1];
                    vloProductoNodo.Codigo[0] = new CodigoType() { Tipo = ObtenerTipoCodigoProducto(vloProducto.tipoCodigo), Codigo = vloProducto.Codigo };
                    //Agrego la cantidad de productos 
                    vloProductoNodo.Cantidad = vloProducto.Cantidad;
                    //Agrego la unidad de medida
                    try
                    {
                        vloProductoNodo.UnidadMedida = (UnidadMedidaType)Enum.Parse(typeof(UnidadMedidaType), vloProducto.UnidadMedida);
                    }
                    catch (Exception)
                    {
                        vloProductoNodo.UnidadMedida = UnidadMedidaType.Unid;
                    }
                    //Agrego el nombre del producto 
                    vloProductoNodo.Detalle = ModFunciones.RemplazarCaracteresHTML(vloProducto.Detalle);
                    //Agrega el precio unitario
                    vloProductoNodo.PrecioUnitario = vloProducto.PrecioUnitario;

                    //Agrega el monto total 
                    vloProductoNodo.MontoTotal = vloProducto.MontoTotal;

                    //Agrega el monto del descuento
                    vloProductoNodo.MontoDescuento = vloProducto.MontoDescuento;
                    //<JBR08012018 >
                    vloProductoNodo.MontoDescuentoSpecified = vloProducto.MostrarDescuento;//(vloProducto.MontoDescuento > 0);
                    //Agrega la naturaleza del descuento 
                    vloProductoNodo.NaturalezaDescuento = vloProducto.NaturalezaDescuento;
                    vloProductoNodo.NaturalezaDescuentoSpecified = vloProducto.MostrarDescuento;
                    //</JBR08012018>
                    //Agrega el subtotal 
                    vloProductoNodo.SubTotal = vloProducto.SubTotal;

                    /****** Se agregan los campos de exoneracion luego se validan si van o no *******/

                    //Agrego los impuestos
                    vloProductoNodo.Impuesto = new ImpuestoType[vloProducto.Impuestos.Count];

                    //Se agregan los impuestos
                    for (int vlnJ = 0; vlnJ < vloProducto.Impuestos.Count; vlnJ++)
                    {
                        vloImp = vloProducto.Impuestos[vlnJ];
                        vloProductoNodo.Impuesto[vlnJ] = new ImpuestoType() { Codigo = ObtenerCodigoImpuesto(vloImp.CodigoImpuesto), Tarifa = vloImp.Tarifa, Monto = vloImp.MontoImpuesto };

                        //Validar
                        if (vloProducto.Exonerado)
                        {
                            //Agrego la exoneracion
                            vloProductoNodo.Impuesto[vlnJ].Exoneracion = new ExoneracionType();
                            vloProductoNodo.Impuesto[vlnJ].Exoneracion.TipoDocumento = ObtenerTipoDocumento(vloProducto.TipoDocumento);
                            vloProductoNodo.Impuesto[vlnJ].Exoneracion.NumeroDocumento = vloProducto.NumeroDocumento;
                            vloProductoNodo.Impuesto[vlnJ].Exoneracion.FechaEmision = vloProducto.FechaEmision;
                            vloProductoNodo.Impuesto[vlnJ].Exoneracion.MontoImpuesto = vloProducto.MontoImpuestoExon;
                            vloProductoNodo.Impuesto[vlnJ].Exoneracion.PorcentajeCompra = Convert.ToInt32(vloProducto.PorcentajeCompra).ToString();
                            vloProductoNodo.Impuesto[vlnJ].Exoneracion.NombreInstitucion = vloProducto.NombreInstitucion;
                        }
                    }

                    //Agrega el monto total del producto
                    vloProductoNodo.MontoTotalLinea = vloProducto.MontoTotalLinea;
                    //Redondea el producto
                    //pRedondearMontos(ref vloProductoNodo, vlnParamTotalDecimales);
                    //Agrega el producto 
                    vloArrProductosNodos[vlnI] = vloProductoNodo;

                }
                return vloArrProductosNodos;
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        // Obtiene el resumen del detalle
        private FacturaElectronicaResumenFactura ObtenerResumen()
        {
            FacturaElectronicaResumenFactura vloResumen;
            try
            {
                vloResumen = new FacturaElectronicaResumenFactura();
                //Agrega la moneda
                try
                {
                    vloResumen.CodigoMoneda = (FacturaElectronicaResumenFacturaCodigoMoneda)Enum.Parse(typeof(FacturaElectronicaResumenFacturaCodigoMoneda), Resumen.Moneda);
                }
                catch (Exception)
                {
                    vloResumen.CodigoMoneda = FacturaElectronicaResumenFacturaCodigoMoneda.CRC;
                }
                vloResumen.CodigoMonedaSpecified = true;
                vloResumen.TipoCambio = Resumen.TipoCambio;
                vloResumen.TipoCambioSpecified = true;
                vloResumen.TotalServGravados = Resumen.TotalServGravados;
                vloResumen.TotalServGravadosSpecified = true;
                //Agrega la etiqueta para total de servicios exentos
                vloResumen.TotalServExentos = Resumen.TotalServExentos;
                vloResumen.TotalServExentosSpecified = true;
                //Agrega la etiqueta para total de mercaderias gravadas
                vloResumen.TotalMercanciasGravadas = Resumen.TotalMercanciasGravadas;
                vloResumen.TotalMercanciasGravadasSpecified = true;
                //Agrega la etiqueta para total de mercaderias exentas
                vloResumen.TotalMercanciasExentas = Resumen.TotalMercanciasExentas;
                vloResumen.TotalMercanciasExentasSpecified = true;
                //Agrega la etiqueta para total gravado
                vloResumen.TotalGravado = Resumen.TotalGravado;
                vloResumen.TotalGravadoSpecified = true;
                //Agrega la etiqueta para total exento
                vloResumen.TotalExento = Resumen.TotalExento;
                vloResumen.TotalExentoSpecified = true;
                //Agrega la etiqueta para total de venta
                vloResumen.TotalVenta = Resumen.TotalVenta;
                //Agrega la etiqueta para total de descuentos
                vloResumen.TotalDescuentos = Resumen.TotalDescuentos;
                vloResumen.TotalDescuentosSpecified = true;
                //Agrega la etiqueta para total venta neta
                vloResumen.TotalVentaNeta = Resumen.TotalVentaNeta;
                //Obtengo el total de impuestos
                vloResumen.TotalImpuesto = Resumen.TotalImpuesto;
                vloResumen.TotalImpuestoSpecified = true;
                //Agrega el total de la factura
                vloResumen.TotalComprobante = Resumen.TotalComprobante;
                return vloResumen;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Obtiene la lista de detalles
        private FacturaElectronicaInformacionReferencia[] ObtenerReferencia()
        {
            FacturaElectronicaInformacionReferencia[] vloReferenciaArr = null;
            FacturaElectronicaInformacionReferencia vloReferencia;
            try
            {
                //Valido si el objeto trae documentos
                if (DocsReferencia != null && DocsReferencia.Length > 0)
                {
                    vloReferenciaArr = new FacturaElectronicaInformacionReferencia[DocsReferencia.Length];
                    //Recorro los documentos enviados
                    for (int vlnI = 0; vlnI < DocsReferencia.Length; vlnI++)
                    {
                        //Creo una nueva instancia 
                        vloReferencia = new FacturaElectronicaInformacionReferencia();
                        //Asigno los parametros
                        vloReferencia.Codigo = DefinirCodigoReferencia(DocsReferencia[vlnI].Codigo);
                        vloReferencia.TipoDoc = DefinirReferenciaTipoDoc(DocsReferencia[vlnI].TipoDoc);
                        vloReferencia.FechaEmision = DocsReferencia[vlnI].FechaEmision;
                        vloReferencia.Numero = DocsReferencia[vlnI].Numero;
                        vloReferencia.Razon = DocsReferencia[vlnI].Razon;
                        //Lo agrego al arreglo
                        vloReferenciaArr[vlnI] = vloReferencia;
                    }
                }
                return vloReferenciaArr;
            }
            catch (Exception)
            {

                throw;
            }

        }

        // Retorna la ruta donde creo el archivo
        public string CrearXML()
        {
            FacturaElectronica vloTiquete = new FacturaElectronica();
            int vlnContador = 0;

            try
            {
                //Agrega la clave
                vloTiquete.Clave = Encabezado.Clave;
                //agrega el número de consecutivo 
                vloTiquete.NumeroConsecutivo = Encabezado.NumeroConsecutivo;
                //Agrega la fecha de emision 
                vloTiquete.FechaEmision = Encabezado.FechaEmision;

                //Agrega la informacion del emisor
                vloTiquete.Emisor = new EmisorType()
                {
                    Nombre = Encabezado.Emisor.Nombre,
                    Identificacion = new IdentificacionType()
                    {
                        Tipo = IdentificacionTypeTipo.Item02,
                        Numero = Encabezado.Emisor.NumeroIdentificacion
                    },
                    NombreComercial = Encabezado.Emisor.NombreComercial,
                    Ubicacion = new UbicacionType()
                    {
                        Provincia = Encabezado.Emisor.Provincia,
                        Canton = Encabezado.Emisor.Canton,
                        Distrito = Encabezado.Emisor.Distrito,
                        Barrio = Encabezado.Emisor.Barrio,
                        OtrasSenas = Encabezado.Emisor.OtrasSennas
                    },
                    CorreoElectronico = Encabezado.Emisor.Correo,

                };
                //Valida el telefono 
                if (Encabezado.Emisor.Telefono != null)
                {
                    vloTiquete.Emisor.Telefono = new TelefonoType()
                    {
                        CodigoPais = Encabezado.Emisor.Telefono.CodigoArea,
                        NumTelefono = Encabezado.Emisor.Telefono.Numero
                    };
                }
                //Valida el fax 
                if (Encabezado.Emisor.Fax != null)
                {
                    vloTiquete.Emisor.Fax = new TelefonoType()
                    {
                        CodigoPais = Encabezado.Emisor.Fax.CodigoArea,
                        NumTelefono = Encabezado.Emisor.Fax.Numero
                    };
                }
                //Valida si el receptor es tipo cliente general no lo incluye
                if (Encabezado.Receptor != null)
                {
                    vloTiquete.Receptor = new ReceptorType();

                    vloTiquete.Receptor.Nombre = Encabezado.Receptor.Nombre;
                    //Si el id es extranjero
                    if (Encabezado.Receptor.EsIdExtranjera)
                    {
                        vloTiquete.Receptor.IdentificacionExtranjero = Encabezado.Receptor.IdentificacionExtranjero;
                    }
                    else
                    {
                        vloTiquete.Receptor.Identificacion = new IdentificacionType()
                        {
                            Tipo = ObtenertipoIdentificacion(Encabezado.Receptor.TipoIdentificacion),
                            Numero = Encabezado.Receptor.NumeroIdentificacion
                        };
                    }
                    vloTiquete.Receptor.NombreComercial = Encabezado.Receptor.NombreComercial;
                    if (!string.IsNullOrEmpty(Encabezado.Receptor.Correo))
                    {
                        vloTiquete.Receptor.CorreoElectronico = Encabezado.Receptor.Correo;
                    }

                    //Agrega el telefono
                    if (Encabezado.Receptor.Telefono != null)
                    {
                        vloTiquete.Receptor.Telefono = new TelefonoType()
                        {
                            CodigoPais = Encabezado.Receptor.Telefono.CodigoArea,
                            NumTelefono = Encabezado.Receptor.Telefono.Numero
                        };
                    }


                    //Si hay provincia
                    if (!string.IsNullOrEmpty(Encabezado.Receptor.Provincia))
                    {
                        vloTiquete.Receptor.Ubicacion = new UbicacionType();
                        vloTiquete.Receptor.Ubicacion.Provincia = Encabezado.Receptor.Provincia;
                        vloTiquete.Receptor.Ubicacion.Canton = Encabezado.Receptor.Canton;
                        vloTiquete.Receptor.Ubicacion.Distrito = Encabezado.Receptor.Distrito;
                        if (!string.IsNullOrEmpty(Encabezado.Receptor.Barrio)) vloTiquete.Receptor.Ubicacion.Barrio = Encabezado.Receptor.Barrio;
                        vloTiquete.Receptor.Ubicacion.OtrasSenas = Encabezado.Receptor.OtrasSennas;
                    }
                }
                //condicion de venta
                vloTiquete.CondicionVenta = ObtenerCondicionVenta(Encabezado.CondicionVenta);
                //Plazo
                vloTiquete.PlazoCredito = Encabezado.PlazoCredito;
                //Medios de pago 
                vloTiquete.MedioPago = new FacturaElectronicaMedioPago[Encabezado.MediosPago.Length];
                foreach (string vlcMedio in Encabezado.MediosPago)
                {
                    vloTiquete.MedioPago[vlnContador] = ObtenerMedioPago(vlcMedio);
                    vlnContador++;
                }
                //Asigna los detalles de servicio
                vloTiquete.DetalleServicio = ObtenerDetalle(Productos);
                //Resumen de factura
                vloTiquete.ResumenFactura = ObtenerResumen();

                //Obtiene referencias
                vloTiquete.InformacionReferencia = ObtenerReferencia();

                //Agrega la normativa
                vloTiquete.Normativa = new FacturaElectronicaNormativa();
                //Agrega el nombre de la normativa
                vloTiquete.Normativa.NumeroResolucion = Encabezado.NormativaNombre;
                //Agrega la fecha
                vloTiquete.Normativa.FechaResolucion = Encabezado.NormativaFecha;

                vloTiquete.Otros = new FacturaElectronicaOtros();
                vloTiquete.Otros.OtroTexto = new FacturaElectronicaOtrosOtroTexto[1];
                //vloTiquete.Otros.OtroTexto[0] = new FacturaElectronicaOtrosOtroTexto() { codigo = "00", Value = IdTransaccion };
                //Retorna el texto
                return fcObtenerStringXML(vloTiquete);


            }
            catch (Exception)
            {

                throw;
            }
        }

        // Guarda el XML en un archivo fisico
        public string fcObtenerStringXML(FacturaElectronica pvoTiquete)
        {
            try
            {
                //Crea Objeto serializador
                XmlSerializer vloSerializador = new XmlSerializer(typeof(FacturaElectronica));
                //Define las configuraciones
                XmlWriterSettings vloConfiguraciones = new XmlWriterSettings();
                //Asinga los valores
                vloConfiguraciones.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
                vloConfiguraciones.Indent = true;
                vloConfiguraciones.OmitXmlDeclaration = true;

                using (StringWriter vloEscritor = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(vloEscritor, vloConfiguraciones))
                    {
                        vloSerializador.Serialize(xmlWriter, pvoTiquete);
                    }
                    //Antes de retornarlo lo guarda 
                    //File.WriteAllText(pvcRuta, vloEscritor.ToString());
                    return vloEscritor.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private FacturaElectronicaCondicionVenta ObtenerCondicionVenta(string vlcCondicionVenta)
        {
            FacturaElectronicaCondicionVenta vloValor;
            try
            {

                switch (vlcCondicionVenta)
                {
                    case "01":
                        vloValor = FacturaElectronicaCondicionVenta.Item01;
                        break;
                    case "02":
                        vloValor = FacturaElectronicaCondicionVenta.Item02;
                        break;
                    case "03":
                        vloValor = FacturaElectronicaCondicionVenta.Item03;
                        break;
                    case "04":
                        vloValor = FacturaElectronicaCondicionVenta.Item04;
                        break;
                    case "05":
                        vloValor = FacturaElectronicaCondicionVenta.Item05;
                        break;
                    case "06":
                        vloValor = FacturaElectronicaCondicionVenta.Item06;
                        break;
                    default:
                        vloValor = FacturaElectronicaCondicionVenta.Item99;
                        break;
                }
                return vloValor;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private FacturaElectronicaMedioPago ObtenerMedioPago(string vlcMedioPago)
        {
            FacturaElectronicaMedioPago vloValor;
            try
            {
                switch (vlcMedioPago)
                {
                    case "01":
                        vloValor = FacturaElectronicaMedioPago.Item01;
                        break;
                    case "02":
                        vloValor = FacturaElectronicaMedioPago.Item02;
                        break;
                    case "03":
                        vloValor = FacturaElectronicaMedioPago.Item03;
                        break;
                    case "04":
                        vloValor = FacturaElectronicaMedioPago.Item04;
                        break;
                    case "05":
                        vloValor = FacturaElectronicaMedioPago.Item05;
                        break;
                    default:
                        vloValor = FacturaElectronicaMedioPago.Item99;
                        break;

                }
                return vloValor;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private ExoneracionTypeTipoDocumento ObtenerTipoDocumento(string pvcTipoDoc)
        {
            ExoneracionTypeTipoDocumento vloValor;
            try
            {
                switch (pvcTipoDoc)
                {
                    case "01":
                        vloValor = ExoneracionTypeTipoDocumento.Item01;
                        break;
                    case "02":
                        vloValor = ExoneracionTypeTipoDocumento.Item02;
                        break;
                    case "03":
                        vloValor = ExoneracionTypeTipoDocumento.Item03;
                        break;
                    case "04":
                        vloValor = ExoneracionTypeTipoDocumento.Item04;
                        break;
                    case "05":
                        vloValor = ExoneracionTypeTipoDocumento.Item05;
                        break;
                    default:
                        vloValor = ExoneracionTypeTipoDocumento.Item99;
                        break;
                }
                return vloValor;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private ImpuestoTypeCodigo ObtenerCodigoImpuesto(string pvcCodigo)
        {
            ImpuestoTypeCodigo vloValor;
            try
            {
                switch (pvcCodigo)
                {
                    case "01":
                        vloValor = ImpuestoTypeCodigo.Item01;
                        break;
                    case "02":
                        vloValor = ImpuestoTypeCodigo.Item02;
                        break;
                    case "03":
                        vloValor = ImpuestoTypeCodigo.Item03;
                        break;
                    case "04":
                        vloValor = ImpuestoTypeCodigo.Item04;
                        break;
                    case "05":
                        vloValor = ImpuestoTypeCodigo.Item05;
                        break;
                    case "06":
                        vloValor = ImpuestoTypeCodigo.Item06;
                        break;
                    case "07":
                        vloValor = ImpuestoTypeCodigo.Item07;
                        break;
                    case "08":
                        vloValor = ImpuestoTypeCodigo.Item08;
                        break;
                    case "09":
                        vloValor = ImpuestoTypeCodigo.Item09;
                        break;
                    case "10":
                        vloValor = ImpuestoTypeCodigo.Item10;
                        break;
                    case "11":
                        vloValor = ImpuestoTypeCodigo.Item11;
                        break;
                    default:
                        vloValor = ImpuestoTypeCodigo.Item99;
                        break;
                }
                return vloValor;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private CodigoTypeTipo ObtenerTipoCodigoProducto(string pvcTipocodigo)
        {
            CodigoTypeTipo vloValor;
            try
            {
                switch (pvcTipocodigo)
                {
                    case "01":
                        vloValor = CodigoTypeTipo.Item01;
                        break;
                    case "02":
                        vloValor = CodigoTypeTipo.Item02;
                        break;
                    case "03":
                        vloValor = CodigoTypeTipo.Item03;
                        break;
                    case "04":
                        vloValor = CodigoTypeTipo.Item04;
                        break;
                    default:
                        vloValor = CodigoTypeTipo.Item99;
                        break;

                }
                return vloValor;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private IdentificacionTypeTipo ObtenertipoIdentificacion(string vlcTipoIdentificacionReceptor)
        {
            IdentificacionTypeTipo vloRespuesta;
            try
            {
                switch (vlcTipoIdentificacionReceptor)
                {
                    case "01":
                        vloRespuesta = IdentificacionTypeTipo.Item01;
                        break;
                    case "02":
                        vloRespuesta = IdentificacionTypeTipo.Item02;
                        break;
                    case "03":
                        vloRespuesta = IdentificacionTypeTipo.Item03;
                        break;
                    default:
                        vloRespuesta = IdentificacionTypeTipo.Item04;
                        break;



                }
                return vloRespuesta;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private FacturaElectronicaInformacionReferenciaTipoDoc DefinirReferenciaTipoDoc(string pvcTipoDocRef)
        {
            FacturaElectronicaInformacionReferenciaTipoDoc vloRes;
            try
            {
                switch (pvcTipoDocRef)
                {
                    /// <comentarios/>
                    case "01":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item01;
                        break;
                    case "02":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item02;
                        break;
                    case "03":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item03;
                        break;
                    case "04":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item04;
                        break;
                    case "05":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item05;
                        break;
                    case "06":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item06;
                        break;
                    case "07":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item07;
                        break;
                    case "08":
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item08;
                        break;
                    default:
                        vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item99;
                        break;
                }
                return vloRes;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private FacturaElectronicaInformacionReferenciaCodigo DefinirCodigoReferencia(string pvcCodigo)
        {
            FacturaElectronicaInformacionReferenciaCodigo vloRes;
            try
            {
                switch (pvcCodigo)
                {
                    case "01":
                        vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item01;
                        break;
                    case "02":
                        vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item02;
                        break;
                    case "03":
                        vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item03;
                        break;
                    case "04":
                        vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item04;
                        break;
                    case "05":
                        vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item05;
                        break;
                    default:
                        vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item99;
                        break;
                }
                return vloRes;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
