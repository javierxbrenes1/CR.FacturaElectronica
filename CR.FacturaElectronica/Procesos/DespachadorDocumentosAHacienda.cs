using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica.Procesos
{
    class DespachadorDocumentosAHacienda : IProceso<PostRespuestaEnvioHacienda, DocumentoDto>
    {
        #region Variables
        private readonly IdpConector _idpConector;
        private readonly ConectorHaciendaRest _conectorHacienda;
        #endregion

        #region Constructor
        public DespachadorDocumentosAHacienda(ConfiguracionComunicacionHacienda configuracion)
        {
            _idpConector = new IdpConector(configuracion);
            _conectorHacienda = new ConectorHaciendaRest();
            ConfigurarConectorHacienda(configuracion);
        }

        
        #endregion

        #region Metodos

        public List<PostRespuestaEnvioHacienda> EjecutarProceso(IEnumerable<DocumentoDto> documentosAProcesar)
        {
            //ejecuta la llamada al idp
            var tokenCancelacionRefrescamiento = new CancellationTokenSource();
            ConsultarIdpPorToken(tokenCancelacionRefrescamiento.Token);
            var resultadosLista = new List<PostRespuestaEnvioHacienda>();
            object blockObject = new object();
            Parallel.ForEach(documentosAProcesar, CrearOpcionesParalelismo(), doc =>
            {
                _conectorHacienda.TokenSeguridad = _idpConector.TokenInfo.access_token;
                var resultadoAux = _conectorHacienda.EnviarDocumentoAHacienda(doc);
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

        private ParallelOptions CrearOpcionesParalelismo()
        {
            var opciones = new ParallelOptions();
            opciones.MaxDegreeOfParallelism = 4;
            return opciones;
        }

        private void ConfigurarConectorHacienda(ConfiguracionComunicacionHacienda configuracion)
        {
            _conectorHacienda.Metodo = EnumeradoresFEL.TiposMetodo.POST.ToString();
            _conectorHacienda.Url = configuracion.UrlApiHacienda;
            _conectorHacienda.TipoAutenticacion = configuracion.TipoAutenticacion;
        }

        #endregion
    }
}
