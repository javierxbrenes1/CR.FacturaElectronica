using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
    public class ImpuestoSistema
    {
        public string Codigo { get; set; }
        public decimal Tarifa { get; set; }
        public decimal Monto { get; set; }
        public ExoneracionSistema Exoneracion { get; set; }
    }
}
