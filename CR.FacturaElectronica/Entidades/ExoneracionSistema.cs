using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public  class ExoneracionSistema
    {
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreInstitucion { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoImpuesto { get; set; }
        public string PorcentajeCompra { get; set; }
    }
}
