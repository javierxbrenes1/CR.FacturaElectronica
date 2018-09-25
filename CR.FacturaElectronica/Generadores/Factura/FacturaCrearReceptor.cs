using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorReceptor 
    {
        public CR.FEL.Detalles.Receptor CrearPersona(Persona personaDelSistema)
        {

            //Valida si el receptor es tipo cliente general no lo incluye
            if (personaDelSistema == null) return null;

            var receptor = new CR.FEL.Detalles.Receptor();

            receptor.Nombre = personaDelSistema.Nombre;
            //Si el id es extranjero
            if (personaDelSistema.EsIdExtranjera)
            {
                receptor.IdentificacionExtranjero = personaDelSistema.IdentificacionExtranjero;
            }
            else
            {
                receptor.Identificacion = new CR.FEL.Detalles.Identificacion()
                {
                    Tipo = ModFunciones.ObtenerValorEnumerador(personaDelSistema.TipoIdentificacion, CR.FEL.Detalles.Identificacion.IdentificacionTipo.Item04),
                    Numero = personaDelSistema.NumeroIdentificacion
                };
            }
            receptor.NombreComercial = personaDelSistema.NombreComercial;
            if (!string.IsNullOrEmpty(personaDelSistema.Correo))
            {
                receptor.CorreoElectronico = personaDelSistema.Correo;
            }
            DefinirTelefono(receptor, personaDelSistema.Telefono);
            DefinirTelefono(receptor, personaDelSistema.Fax, true);
            DefinirDireccion(receptor, personaDelSistema);
            //Si hay provincia

            return receptor;
        }

        private void DefinirDireccion(CR.FEL.Detalles.Receptor receptor,Persona personaDelSistema) {
            if (!string.IsNullOrEmpty(personaDelSistema.Provincia))
            {
                receptor.Ubicacion = new CR.FEL.Detalles.Ubicacion();
                receptor.Ubicacion.Provincia = personaDelSistema.Provincia;
                receptor.Ubicacion.Canton = personaDelSistema.Canton;
                receptor.Ubicacion.Distrito = personaDelSistema.Distrito;
                if (!string.IsNullOrEmpty(personaDelSistema.Barrio)) receptor.Ubicacion.Barrio = personaDelSistema.Barrio;
                receptor.Ubicacion.OtrasSenas = personaDelSistema.OtrasSennas;
            }
        }

        private void DefinirTelefono(CR.FEL.Detalles.Receptor receptor, Telefono telefonoSistema, bool esFax = false)
        {
            if (telefonoSistema != null)
            {
                var telefonoType = new CR.FEL.Detalles.Telefono()
                {
                    CodigoPais = telefonoSistema.CodigoArea,
                    NumTelefono = telefonoSistema.Numero
                };

                if (!esFax)
                {
                    receptor.Telefono = telefonoType;
                }
                else
                {
                    receptor.Fax = telefonoType;
                }
            }
        }

       
    }
}
