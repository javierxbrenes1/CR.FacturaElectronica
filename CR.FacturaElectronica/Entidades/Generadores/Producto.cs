using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CR.FacturaElectronica.Entidades
{
    public class LineaDetalle
    {
        /*Informacion general del producto*/
        public string Codigo { get; set; }
        public string tipoCodigo { get; set; }
        public string UnidadMedidaOriginal { get; set; }
        public string Detalle { get; set; }
        public string NaturalezaDescuento { get; set; }
        public string ModificadorPrecio { get; set; }
        public decimal Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal SubTotal { get; set; }
        /*Los siguientes campos se incluyen pero deben ser verificados*/
        /*EStos campos son para articulos exonerados o para factura exonerada ?*/
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string NombreInstitucion { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal MontoImpuestoExon { get; set; }
        public decimal PorcentajeCompra { get; set; }
        public decimal MontoTotalLinea { get; set; }
        /* BANDERAS INFORMATIVAS */
        public bool Exento { get; set; }
        public bool Exonerado { get; set; }
        public bool Pesable { get; set; }
        public bool Servicio { get; set; }
        public bool MostrarDescuento { get; set; }
        //Lista de impuestos 
        public List<Impuesto> Impuestos { get; set; }
        //Constructor
        public LineaDetalle() { }

        public void ActualizarMontoTotal()
        {
            //Actualiza el monto total 
            try
            {
                //modifica el monto total
                this.MontoTotal = this.Cantidad * this.PrecioUnitario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Actualiza el monto de subtototal
        public void ActualizarMontoSubtotal()
        {
            try
            {
                //Define el valor del subtotal
                this.SubTotal = this.MontoTotal - this.MontoDescuento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
