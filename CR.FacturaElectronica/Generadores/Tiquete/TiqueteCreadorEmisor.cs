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
    internal class TiqueteCreadorEmisor : ICreadorPersona<EmisorType>
    {
        public EmisorType CrearPersona(Persona personaDelSistema)
        {
            var emisor = new EmisorType()
            {
                Nombre = personaDelSistema.Nombre,
                Identificacion = new IdentificacionType()
                {
                    Tipo = ModFunciones.ObtenerValorEnumerador(personaDelSistema.TipoIdentificacion, IdentificacionTypeTipo.Item04),
                    Numero = personaDelSistema.NumeroIdentificacion
                },
                NombreComercial = personaDelSistema.NombreComercial,
                Ubicacion = new UbicacionType()
                {
                    Provincia = personaDelSistema.Provincia,
                    Canton = personaDelSistema.Canton,
                    Distrito = personaDelSistema.Distrito,
                    Barrio = personaDelSistema.Barrio,
                    OtrasSenas = personaDelSistema.OtrasSennas
                },
                CorreoElectronico = personaDelSistema.Correo,

            };
            DefinirTelefono(emisor, personaDelSistema.Telefono);
            DefinirTelefono(emisor, personaDelSistema.Fax, true);
            return emisor;
        }

        private void DefinirTelefono(EmisorType emisor, Telefono telefonoSistema, bool esFax = false)
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
                    emisor.Telefono = telefonoType;
                }
                else
                {
                    emisor.Fax = telefonoType;
                }
            }
        }

    }
}
