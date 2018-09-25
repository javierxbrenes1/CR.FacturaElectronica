using System;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Shared;
using CR.FEL.Detalles;
namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorEmisor
    { 
        public Emisor CrearPersona(Persona personaDelSistema)
        {
            var emisor = new Emisor()
            {
                Nombre = personaDelSistema.Nombre,
                Identificacion = new Identificacion()
                {
                    Tipo = ModFunciones.ObtenerValorEnumerador(personaDelSistema.TipoIdentificacion, Identificacion.IdentificacionTipo.Item04),
                    Numero = personaDelSistema.NumeroIdentificacion
                },
                NombreComercial = personaDelSistema.NombreComercial,
                Ubicacion = new Ubicacion()
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

        private void DefinirTelefono(Emisor emisor, CR.FacturaElectronica.Entidades.Telefono telefonoSistema, bool esFax = false) 
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
                    emisor.Telefono = telefonoType;
                }
                else {
                    emisor.Fax = telefonoType;
                }
            }
        }
       
    }
}
