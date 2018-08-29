

namespace CR.FacturaElectronica.Entidades
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public bool EsIdExtranjera { get; set; }
        public string IdentificacionExtranjero { get; set; }
        public string NombreComercial { get; set; }
        public string Canton { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Barrio { get; set; }
        public string OtrasSennas { get; set; }
        public Telefono Telefono { get; set; }
        public Telefono Fax { get; set; }
        public string Correo { get; set; }
        
    }
}
