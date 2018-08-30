
namespace CR.FacturaElectronica.Entidades
{
    public class ConfiguracionCreacionDocumentos
    {
        public Persona EmisorInformacion { get; set; }

        public string LlaveCriptograficaRuta { get; set; }
        public string LlaveCriptograficaClave { get; set; }
        public string PoliticaDigest { get; set; }
        public string Politica { get; set; }
        public bool AlmacenarXMLsEnRutaRespaldos { get; set; }
        public bool HayInternet { get; set; }
        public string RutaXMLRespaldos { get; set; }

    }
}
