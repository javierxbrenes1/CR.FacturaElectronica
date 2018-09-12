using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Procesos
{
    class ConsultorDocumentosEnHacienda : IProceso<GetRespuestaConsultaHacienda, string>
    {
        #region Variables
        private readonly IdpConector _idpConector;
        private readonly ConectorHaciendaRest _conectorHacienda;
        #endregion

        public ConsultorDocumentosEnHacienda(ConfiguracionComunicacionHacienda configuracion)
        {
            _idpConector = new IdpConector(configuracion);
            _conectorHacienda = new ConectorHaciendaRest();
            ConfigurarConectorHacienda(configuracion);
        }

        public List<GetRespuestaConsultaHacienda> EjecutarProceso(IEnumerable<string> documentosAProcesar)
        {
            //ejecuta la llamada al idp
            var tokenCancelacionRefrescamiento = new CancellationTokenSource();
            ConsultarIdpPorToken(tokenCancelacionRefrescamiento.Token);
            var resultadosLista = new List<GetRespuestaConsultaHacienda>();
            object blockObject = new object();
            Parallel.ForEach(documentosAProcesar, clave =>
            {
                _conectorHacienda.TokenSeguridad = _idpConector.TokenInfo.access_token;
                var resultadoAux = _conectorHacienda.ConsultarDocumentoEnHacienda(clave);
                lock (blockObject)
                {
                    resultadosLista.Add(resultadoAux);
                }

            });
            tokenCancelacionRefrescamiento.Cancel();
            _idpConector.CerrarSesionIdp();
            return resultadosLista;
        }

        private void ConsultarIdpPorToken(CancellationToken token)
        {
            _idpConector.ObtenerToken();
            var TaskTokenRefrescamiento = Task.Run(() => {
                if (!token.IsCancellationRequested)
                {
                    Thread.Sleep(_idpConector.TokenInfo.refresh_expires_in - 40);
                    _idpConector.ObtenerToken(true);
                }

            }, token);
        }



        private void ConfigurarConectorHacienda(ConfiguracionComunicacionHacienda configuracion)
        {
            _conectorHacienda.Metodo = EnumeradoresFEL.TiposMetodo.GET.ToString();
            _conectorHacienda.Url = configuracion.UrlApiHacienda;
            _conectorHacienda.TipoAutenticacion = configuracion.TipoAutenticacion;
        }
    }
}
