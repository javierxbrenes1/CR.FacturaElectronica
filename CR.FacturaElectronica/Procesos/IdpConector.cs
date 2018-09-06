using CR.FacturaElectronica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CR.FacturaElectronica.Procesos
{
    public class IdpConector
    {
        public TokenDto TokenInfo { get; set; }
        private const string cGRANT_TYPE_REFRESH = "refresh_token";
        private readonly ConfiguracionComunicacionHacienda _configuracion;
        public IdpConector(ConfiguracionComunicacionHacienda configuracionComunicacion)
        {
            this._configuracion = configuracionComunicacion;
        }

        public void ObtenerToken(bool refrescarToken = false)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(_configuracion.UrlIdpLogIn);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var contenido = new FormUrlEncodedContent(ParametrosIdp(refrescarToken));

                var respuestaApi = cliente.PostAsync("token", contenido).Result;
                respuestaApi.EnsureSuccessStatusCode();

                var contenidoJson = respuestaApi.Content.ReadAsStringAsync().Result;
                TokenInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenDto>(contenidoJson);
            }
        }

        public bool CerrarSesionIdp()
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_configuracion.TipoAutenticacion, TokenInfo.access_token);
                cliente.BaseAddress = new Uri(_configuracion.UrlIdpLogOut);
                cliente.DefaultRequestHeaders.Accept.Clear();
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var datosEnvio = new List<KeyValuePair<string, string>>();
                datosEnvio.Add(new KeyValuePair<string, string>("refresh_token", TokenInfo.refresh_token));
                datosEnvio.Add(new KeyValuePair<string, string>("client_id", _configuracion.ClientID));
                var contenido = new FormUrlEncodedContent(datosEnvio);
                var respuestaApi = cliente.PostAsync("logout", contenido).Result;

                return respuestaApi.StatusCode == System.Net.HttpStatusCode.NoContent;

            }
        }

        private List<KeyValuePair<string, string>> ParametrosIdp(bool esRefrescamiento)
        {
            var vloPostData = new List<KeyValuePair<string, string>>();
            if (!esRefrescamiento)
            {
                vloPostData.Add(new KeyValuePair<string, string>("grant_type",_configuracion.GrantType));
                vloPostData.Add(new KeyValuePair<string, string>("client_id", _configuracion.ClientID));
                vloPostData.Add(new KeyValuePair<string, string>("client_secret", _configuracion.ClientSecret));
                vloPostData.Add(new KeyValuePair<string, string>("username", _configuracion.IdpUsuario));
                vloPostData.Add(new KeyValuePair<string, string>("password", _configuracion.IdpContrasenna));
            }
            else {
                vloPostData.Add(new KeyValuePair<string, string>("refresh_token", TokenInfo.refresh_token));
                vloPostData.Add(new KeyValuePair<string, string>("grant_type", cGRANT_TYPE_REFRESH));
                vloPostData.Add(new KeyValuePair<string, string>("client_id", _configuracion.ClientID));
            }

            return vloPostData;
        }
    }
}
