using CR.FacturaElectronica.Entidades;

namespace CR.FacturaElectronica.Generadores.Interfaces
{
    interface ICreadorDocumentoReferencia<T>
    {
        T[] CrearArregloReferencias(DocumentoReferencia[] referenciasSistema);
    }
}
