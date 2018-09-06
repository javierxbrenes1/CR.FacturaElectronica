using CR.FacturaElectronica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CR.FacturaElectronica.Procesos
{
    public class ConectorHaciendaRest
    {
        #region Propiedades

        public string Metodo { get; set; }
        public string Url { get; set; }
        public string TipoAutenticacion { get; set; }
        public string TokenSeguridad { get; set; }


        #endregion

        #region Metodos

        private HttpResponseMessage PostDocumento(string data)
        {
            using (var cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TipoAutenticacion, TokenSeguridad);
                return cliente.PostAsync(Url, new StringContent(data, Encoding.UTF8, "application/json")).Result;
            }
        }

        private HttpResponseMessage GetDocumento(string clave, string urlAlmacenado = "")
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TipoAutenticacion, TokenSeguridad);
                var url = string.IsNullOrEmpty(urlAlmacenado) ? $"{Url}/{clave}" : urlAlmacenado;
                return cliente.GetAsync(url).Result;
            }
        }

        public PostRespuestaEnvioHacienda EnviarDocumento(string data)
        {
            var respuesta = new PostRespuestaEnvioHacienda();
            var respuestaApi = PostDocumento(data);
            respuesta.TramaRecibida = respuestaApi.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrEmpty(respuesta.TramaRecibida)) respuesta.TramaRecibida = respuestaApi.ToString();
            respuesta.Mensaje = respuestaApi.ReasonPhrase;
            IEnumerable<string> valoresHeader;
            if (respuestaApi.IsSuccessStatusCode)
            {
                respuesta.DocumentoEnviado = true;
                if (respuestaApi.Headers.TryGetValues("Location", out valoresHeader))
                    respuesta.RutaConsultaEstadoDocumento = valoresHeader.FirstOrDefault();
                
            }
            else
            {
                if (respuestaApi.Headers.TryGetValues("X-Error-Cause", out valoresHeader))
                {
                    respuesta.Mensaje = valoresHeader.FirstOrDefault();
                    respuesta.DocumentoEnviado = respuesta.Mensaje.Contains("ya fue recibido");
                }
            }
            return respuesta;
        }

        public GetRespuestaConsultaHacienda ConsultarDocumento(string clave, string urlConsultaAlmacenada = "")
        {
            var respuesta = new GetRespuestaConsultaHacienda();
            var respuestaApi = GetDocumento(clave, urlConsultaAlmacenada);
            if (respuestaApi.IsSuccessStatusCode)
            {
                respuesta.ConsultaExitosa = true;
                var jsonRespuesta = respuestaApi.Content.ReadAsStringAsync().Result;
                respuesta.Estado = Newtonsoft.Json.JsonConvert.DeserializeObject<EstadoDocumentoDto>(jsonRespuesta);
                if (!string.IsNullOrEmpty(respuesta.Estado.respuestaXml))
                    respuesta.Estado.respuestaXml = DecodificarBase64(respuesta.Estado.respuestaXml);
            }
            else
            {
                IEnumerable<string> valoresHeader;
                if (respuestaApi.Headers.TryGetValues("X-Error-Cause", out valoresHeader))
                    respuesta.Mensaje = valoresHeader.FirstOrDefault();
                 
            }
            return respuesta;
        }


        private string DecodificarBase64(string textoEnBase64)
        {
            var bytes = Convert.FromBase64String(textoEnBase64);
            return Encoding.UTF8.GetString(bytes);
        }
    }

    #endregion

}

