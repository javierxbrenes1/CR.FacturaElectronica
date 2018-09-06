

namespace CR.FacturaElectronica.Entidades
{
    public class DocumentoDto
    {
        public string clave { get; set; }

        public string fecha { get; set; }

        public PersonaDocumentoDto emisor { get; set; }

        public PersonaDocumentoDto receptor { get; set; }

        public string callbackUrl { get; set; }

        public string consecutivoReceptor { get; set; }

        public string comprobanteXml { get; set; }
    }
}
