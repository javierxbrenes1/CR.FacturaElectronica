using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades.Generadores
{
    public class DocumentoRespuestaParametros
    {
        public string Clave { get; set; }
        public string Mensaje { get; set; }
        public string ConsecutivoSistema { get; set; }
        public string CedulaEmisor { get; set; }
        public string CedulaReceptor { get; set; }
        public decimal TotalMonto { get; set; }
        public decimal TotalImpuesto { get; set; }
        public DateTime FechaEmision { get; set; }
    }
}
 