
using System.Collections.Generic;


namespace CR.FacturaElectronica.Entidades
{
    public class Resumen
    {
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal TotalServGravados { get; set; }
        public decimal TotalServExentos { get; set; }
        public decimal TotalMercanciasGravadas { get; set; }
        public decimal TotalMercanciasExentas { get; set; }
        public decimal TotalGravado { get; set; }
        public decimal TotalExento { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal TotalDescuentos { get; set; }
        public decimal TotalVentaNeta { get; set; }
        public List<Impuesto> Impuestos { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal TotalComprobante { get; set; }
    }
}
