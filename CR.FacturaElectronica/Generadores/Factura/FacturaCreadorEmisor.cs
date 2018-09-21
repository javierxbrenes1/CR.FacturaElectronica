using System;
using CR.FacturaElectronica.Entidades;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorEmisor : ICreadorPersona<EmisorType>
    {
        public EmisorType CrearPersona(Persona personaDelSistema)
        {
            var emisor = new EmisorType()
            {
                Nombre = personaDelSistema.Nombre,
                Identificacion = new IdentificacionType()
                {
                    Tipo = FacturaEnumeradores.ObtenertipoIdentificacion(personaDelSistema.TipoIdentificacion),
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
                else {
                    emisor.Fax = telefonoType;
                }
            }
        }
       
    }
}
