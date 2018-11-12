using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Detalles;
using System.Collections.Generic;

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

        public static bool HayImpuestosDeSistema(List<ImpuestoSistema> impuestos)
        {
            if (impuestos == null) return false;
            if (impuestos.Count <= 0) return false;
            return true;
        }

    }
}
