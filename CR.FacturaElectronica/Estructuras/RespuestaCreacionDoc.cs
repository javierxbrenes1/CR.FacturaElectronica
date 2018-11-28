using CR.FacturaElectronica.Entidades;
using System;

namespace CR.FacturaElectronica
{
    public struct RespuestaCreacionDoc
    {

        public enum enmEstadoDocumento
        {
            CreadoCorrectamente,
            NoCreado,
        }

        public string ConsecutivoDocCreado;
        public string ClaveDocCreada;
        public string XmlDocCreado;
        public string ErrorMensaje;
        public long NuevoConsecutivoSistema;
        public enmEstadoDocumento EstadoDocumento;
        public DateTime FechaCreacion { get; set; }

    }
}
