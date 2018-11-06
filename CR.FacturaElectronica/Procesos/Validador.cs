using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Detalles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Procesos
{
    public class Validador
    {
        public static bool esReceptorValido(Receptor receptor)
        {
            if (receptor.Identificacion == null) return false;
            if (receptor.Identificacion.Numero == null) return false;
            return true;
        }

        public static bool esReceptorJsonEnvioValido(PersonaDocumentoDto persona)
        {
            if (persona == null) return false;
            if (persona.numeroIdentificacion == null || persona.tipoIdentificacion == null) return false;
            return true;
        }
    }
}
