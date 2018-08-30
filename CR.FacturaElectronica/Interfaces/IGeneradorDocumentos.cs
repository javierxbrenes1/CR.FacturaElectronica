using CR.FacturaElectronica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Interfaces
{
   public interface IGeneradorDocumentos
    {
        RespuestaCreacionDoc GenerarDocumentoXML(DocumentoParametros documentoParametros);
    }
}
 