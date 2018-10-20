using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica
{
    public class CreadorDocumentos : ICreadorDocumentos
    {

        private readonly ConfiguracionCreacionDocumentos _configuracion;
        private readonly IFirmadorElectronico _firmadorElectronico;

        public CreadorDocumentos(ConfiguracionCreacionDocumentos configuracion)
        {
            this._configuracion = configuracion;
            this._firmadorElectronico = new FirmadorElectronico(configuracion);
        }

        #region Metodos de interfaz

        public RespuestaCreacionDoc CrearDocumentoXML(DocumentoParametros docParams)
        {
            var respuesta = new RespuestaCreacionDoc();
            try
            {
                docParams.Encabezado.FechaEmision = DateTime.Now;
                docParams.Encabezado.Emisor = _configuracion.EmisorInformacion;
                docParams.Encabezado.NumeroConsecutivo = GenerarConsecutivo(docParams.Sucursal, docParams.Terminal,
                    docParams.ConsecutivoSistema, docParams.TipoDocumento);
                docParams.Encabezado.Clave = GenerarClave(docParams.Encabezado.NumeroConsecutivo, docParams.Encabezado.FechaEmision,
                    GeneraTokenSeguridad(8), docParams.EsUnReproceso);

                var creadorXml = new GeneradorXML();

                creadorXml.Encabezado = docParams.Encabezado;
                creadorXml.DocsReferencia = docParams.DocumentosReferencia == null ? null : docParams.DocumentosReferencia.ToArray();
                creadorXml.Detalles = new LineasDetalleParser().ParsearLineas(docParams.LineasDetalle);
                creadorXml.Resumen = docParams.Resumen;
                creadorXml.SeccionOtros = docParams.SeccionOtros;

                var xml = creadorXml.CrearXML(docParams.TipoDocumento);

                var rutaGuardado = GuardarElXMlParaFirmarlo(docParams.Encabezado.Clave, xml);
                respuesta.XmlDocCreado = _firmadorElectronico.FirmarDocumento(rutaGuardado);
                respuesta.ConsecutivoDocCreado = docParams.Encabezado.NumeroConsecutivo;
                respuesta.ClaveDocCreada = docParams.Encabezado.Clave;
                respuesta.EstadoDocumento = RespuestaCreacionDoc.enmEstadoDocumento.CreadoCorrectamente;
                respuesta.NuevoConsecutivoSistema = docParams.ConsecutivoSistema + 1;
            }
            catch (Exception ex)
            {
                respuesta.ErrorMensaje = ex.Message;

                respuesta.EstadoDocumento = RespuestaCreacionDoc.enmEstadoDocumento.NoCreado;
                respuesta.NuevoConsecutivoSistema = docParams.ConsecutivoSistema;
            }
            return respuesta;
        }

        private string GuardarElXMlParaFirmarlo(string clave, string xml)
        {
            var ruta = _configuracion.RutaXMLRespaldos;
           if (string.IsNullOrEmpty(ruta))
                ruta = string.Format("{0}\\XMLS", Environment.CurrentDirectory) ;

            if (!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            ruta = string.Format("{0}\\{1}.xml", ruta, clave);
            File.WriteAllText(ruta , xml);
            return ruta;

        }

        private string GenerarConsecutivo(int sucursal, int terminal, long consecutivo,
            EnumeradoresFEL.enmTipoDocumento tipoDocumento)
        {
            return string.Format("{0}{1}{2}{3}", sucursal.ToString().PadLeft(3, '0'), 
                terminal.ToString().PadRight(5, '0'), ((int)tipoDocumento).ToString().PadLeft(2, '0'),
                consecutivo.ToString().PadLeft(10, '0'));
          
        }


        private string GenerarClave(string consecutivo, DateTime fechaTransaccion, 
            string codigoSeguridad, bool esUnReproceso)
        {
            var dia = fechaTransaccion.Day.ToString().PadLeft(2, '0');
            var mes = fechaTransaccion.Month.ToString().PadLeft(2, '0');
            var anno = fechaTransaccion.Year.ToString().Substring(2, 2);
            var cedulaEmisor = _configuracion.EmisorInformacion.Identificacion.Numero.PadLeft(12, '0');

            var docSituacion = esUnReproceso ? 
                EnumeradoresFEL.enmSituacionComprobante.Contingencia :
                _configuracion.HayInternet ? EnumeradoresFEL.enmSituacionComprobante.Normal :
                EnumeradoresFEL.enmSituacionComprobante.Sin_Internet;

            return Constantes.PAIS_CODIGO+dia+mes+anno+cedulaEmisor+consecutivo+(int)docSituacion+codigoSeguridad;
        }

        private string GeneraTokenSeguridad(int pvcTamaño)
        {
            string vlocharSet;
            char[] vloCarArray;
            byte[] vloDato;
            RNGCryptoServiceProvider vloObjCripto;
            StringBuilder vloResultado;
            try
            {
                vlocharSet = "0123456789";
                vloCarArray = vlocharSet.ToCharArray();
                vloDato = new byte[1];
                vloObjCripto = new RNGCryptoServiceProvider();
                vloObjCripto.GetNonZeroBytes(vloDato);
                vloDato = new byte[pvcTamaño];
                vloObjCripto.GetNonZeroBytes(vloDato);
                vloResultado = new StringBuilder(pvcTamaño);
                foreach (byte vloByte in vloDato)
                {
                    vloResultado.Append(vloCarArray[vloByte % (vloCarArray.Length)]);
                }
                return vloResultado.ToString();
            }
            catch (Exception)
            {
                return "12345678";
            }
        }

        #endregion
    }
}
