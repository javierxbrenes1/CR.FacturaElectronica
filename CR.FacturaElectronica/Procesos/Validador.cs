using CR.FacturaElectronica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Procesos
{
    public class Validador
    {
        public static bool EsReceptorDespacheValido(PersonaDocumentoDto persona)
        {
            if (persona == null) return false;
            if (string.IsNullOrEmpty(persona.numeroIdentificacion)) return false;
            if (string.IsNullOrEmpty(persona.tipoIdentificacion)) return false;
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
