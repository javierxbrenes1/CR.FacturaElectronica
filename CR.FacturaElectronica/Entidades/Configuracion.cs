
namespace CR.FacturaElectronica.Entidades
{
    public class Configuracion
    {
        public Persona EmisorInformacion { get; set; }
        public string IdpUsuario { get; set; }
        public string IdpContrasenna { get; set; }
        public string UrlIdpLogIn { get; set; }
        public string UrlIdpLogOut { get; set; }
        public string ApiHacienda { get; set; }
        public string LlaveCriptograficaNombre { get; set; }
        public string LlaveCriptograficaClave { get; set; }
        public string PolicyHash { get; set; }
        public bool AlmacenarXMLsEnRutaRespaldos { get; set; }
        public string RutaXMLRespaldos { get; set; }
    }
}
