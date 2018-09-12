using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public class Exoneracion
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreInstitucion { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoImpuestoExon { get; set; }
        public decimal PorcentajeCompra { get; set; }
        public decimal MontoTotalLinea { get; set; }
    }
}
