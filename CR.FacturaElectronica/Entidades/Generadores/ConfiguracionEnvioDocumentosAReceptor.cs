using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public class ConfiguracionEnvioDocumentosAReceptor
    {
        public string Host { get; set; }
        public string HostUsuario { get; set; }
        public string HostConstrasenna { get; set; }
        public string Remitente { get; set; }
        public int Puerto { get; set; }
        public bool UsaSSL { get; set; }
    }
}
