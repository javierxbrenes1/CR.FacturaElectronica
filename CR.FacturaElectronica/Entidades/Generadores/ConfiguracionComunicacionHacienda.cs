using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public class ConfiguracionComunicacionHacienda
    {
        public string IdpUsuario { get; set; }
        public string IdpContrasenna { get; set; }

        public string UrlIdpLogIn { get; set; }
        public string UrlIdpLogOut { get; set; }

        public string ClientID { get; set; }
        public string GrantType { get; set; }
        public string ClientSecret { get; set; }

        public string UrlApiHacienda { get; set; }

        public string TipoAutenticacion { get; set; }

    }
}
