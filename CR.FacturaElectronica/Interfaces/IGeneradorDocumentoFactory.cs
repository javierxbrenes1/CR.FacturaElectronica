using CR.FacturaElectronica.Entidades;
using System;


namespace CR.FacturaElectronica.Interfaces
{
    internal interface IGeneradorDocumentoFactory
    {
        IGeneradorDocumento ResolverInstancia(DocumentoParametros.enmTipoDocumento tipoDoc);
    }
}
