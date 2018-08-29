

namespace CR.FacturaElectronica.Entidades
{
    public class Impuesto
    {
        /*Informacion de impuestos*/
        public string CodigoImpuesto { get; set; }
        public decimal Tarifa { get; set; }
        public decimal MontoImpuesto { get; set; }
    }
}
