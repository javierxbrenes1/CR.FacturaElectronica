using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Tiquete
{
    internal class TiqueteCreadorReceptor : ICreadorPersona<ReceptorType>
    {
        public ReceptorType CrearPersona(Persona personaDelSistema)
        {
            //Valida si el receptor es tipo cliente general no lo incluye
            if (personaDelSistema == null) return null;

            var receptor = new ReceptorType();

            receptor.Nombre = personaDelSistema.Nombre;
            //Si el id es extranjero
            if (personaDelSistema.EsIdExtranjera)
            {
                receptor.IdentificacionExtranjero = personaDelSistema.IdentificacionExtranjero;
            }
            else
            {
                receptor.Identificacion = new IdentificacionType()
                {
                    Tipo = ModFunciones.ObtenerValorEnumerador(personaDelSistema.TipoIdentificacion, IdentificacionTypeTipo.Item04),
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

        private void DefinirDireccion(ReceptorType receptor, Persona personaDelSistema)
        {
            if (!string.IsNullOrEmpty(personaDelSistema.Provincia))
            {
                receptor.Ubicacion = new UbicacionType();
                receptor.Ubicacion.Provincia = personaDelSistema.Provincia;
                receptor.Ubicacion.Canton = personaDelSistema.Canton;
                receptor.Ubicacion.Distrito = personaDelSistema.Distrito;
                if (!string.IsNullOrEmpty(personaDelSistema.Barrio)) receptor.Ubicacion.Barrio = personaDelSistema.Barrio;
                receptor.Ubicacion.OtrasSenas = personaDelSistema.OtrasSennas;
            }
        }

        private void DefinirTelefono(ReceptorType receptor, Telefono telefonoSistema, bool esFax = false)
        {
            if (telefonoSistema != null)
            {
                var telefonoType = new TelefonoType()
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
