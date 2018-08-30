using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Nota_Credito;
using CR.FacturaElectronica.Nota_Debito;
using CR.FacturaElectronica.Tiquete;
using System;


namespace CR.FacturaElectronica
{
    internal class GeneradorDocumentoFactory : IGeneradorDocumentoFactory
    {
        public IGeneradorDocumento ResolverInstancia(DocumentoParametros.enmTipoDocumento tipoDoc)
        {
            IGeneradorDocumento generadorDocumento;
            switch (tipoDoc)
            {
                case DocumentoParametros.enmTipoDocumento.Factura:
                    generadorDocumento = new FacturaElectronicaProcesador();
                    break;
                case DocumentoParametros.enmTipoDocumento.Tiquete:
                    generadorDocumento = new TiqueteProcesador();
                    break;
                case DocumentoParametros.enmTipoDocumento.NotaDebito:
                    generadorDocumento = new NotaDebitoProcesador();
                    break;
                case DocumentoParametros.enmTipoDocumento.NotaCredito:
                    generadorDocumento = new NotaCreditoProcesador();
                    break;
                default:
                    throw new NotGeneradorFoundException("Generador de documentos no definido");
            }
            return generadorDocumento;
        }
    }
}
