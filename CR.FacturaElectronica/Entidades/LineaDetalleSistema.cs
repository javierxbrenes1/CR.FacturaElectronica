using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Entidades
{
   public class LineaDetalleSistema
    {
        public string Codigo { get; set; }
        public string TipoCodigo { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string Detalle { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoDescuento { get; set; }
        public string NaturalezaDescuento { get; set; }
        public decimal SubTotal { get; set; }
        public List<ImpuestoSistema> Impuesto { get; set; }
        public decimal MontoTotalLinea { get; set; }
    }
}
