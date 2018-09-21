using CR.FacturaElectronica.Entidades;

namespace CR.FacturaElectronica.Factura
{
    internal interface ICreadorPersona<T>
    {
        T CrearPersona(Persona personaDelSistema);
    }
}
