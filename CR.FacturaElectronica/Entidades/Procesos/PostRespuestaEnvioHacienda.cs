

namespace CR.FacturaElectronica.Entidades
{
    public class PostRespuestaEnvioHacienda
    {
        public bool DocumentoEnviado { get; set; }
        public string TramaRecibida{get;set;}
        public string Mensaje { get; set; }
        public string RutaConsultaEstadoDocumento { get; set; }
    }
}
