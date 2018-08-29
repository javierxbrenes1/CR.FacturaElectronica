using System;


namespace CR.FacturaElectronica.Entidades
{
    public class DocumentoReferencia
    {
        public string TipoDoc { get; set; }
        public string Numero { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Codigo { get; set; }
        public string Razon { get; set; }
    }
}
