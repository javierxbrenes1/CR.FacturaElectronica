using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Shared
{
    internal class ModFunciones
    {
        internal static String RemplazarCaracteresHTML(String pvoTexto)
        {
            try
            {
                if (!String.IsNullOrEmpty(pvoTexto))
                {
                    return pvoTexto.Replace("á", "&aacute;").Replace("é", "&eacute;").Replace("í", "&iacute;").Replace("ó", "&oacute;").Replace("ú", "&uacute;").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
