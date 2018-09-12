using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Nota_Credito;
using CR.FacturaElectronica.Nota_Debito;
using CR.FacturaElectronica.Shared;
using CR.FacturaElectronica.Tiquete;



namespace CR.FacturaElectronica
{
    public class DocumentoProcesadorFactory : IDocumentoProcesadorFactory
    {
        public  IDocumentoProcesador ResolverInstancia(EnumeradoresFEL.enmTipoDocumento tipoDoc)
        {
            IDocumentoProcesador generadorDocumento;
            switch (tipoDoc)
            {
                case EnumeradoresFEL.enmTipoDocumento.Factura:
                    generadorDocumento = new FacturaElectronicaProcesador();
                    break;
                case EnumeradoresFEL.enmTipoDocumento.Tiquete:
                    generadorDocumento = new TiqueteProcesador();
                    break;
                case EnumeradoresFEL.enmTipoDocumento.NotaDebito:
                    generadorDocumento = new NotaDebitoProcesador();
                    break;
                case EnumeradoresFEL.enmTipoDocumento.NotaCredito:
                    generadorDocumento = new NotaCreditoProcesador();
                    break;
                default:
                    throw new NotGeneradorFoundException("Generador de documentos no definido");
            }
            return generadorDocumento;
        }
    }
}
