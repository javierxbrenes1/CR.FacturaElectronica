using CR.FacturaElectronica.Entidades;


namespace CR.FacturaElectronica.Generadores.Interfaces
{
    internal interface ICreadorResumen<T>
    {
        T CrearResumen(Resumen resumenSistema);
    }
}
