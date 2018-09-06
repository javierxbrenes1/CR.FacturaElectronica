

using Newtonsoft.Json;

namespace CR.FacturaElectronica.Entidades
{
    public class EstadoDocumentoDto
    {
        public string clave { get; set; }
        public string fecha { get; set; }
        [JsonProperty("ind-estado")]
        public string indEstado { get; set; }
        [JsonProperty("respuesta-xml")]
        public string respuestaXml { get; set; }
    }
}
