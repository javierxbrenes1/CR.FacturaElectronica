using System;


namespace CR.FacturaElectronica.Entidades
{
    public class Encabezado
    {
        internal string Clave { get; set; }
        internal string NumeroConsecutivo { get; set; }
        internal DateTime FechaEmision { get; set; }
        public Persona Emisor { get; set; }
        public Persona Receptor { get; set; }
        public string[] MediosPago { get; set; }
        public string CondicionVenta { get; set; }
        public string PlazoCredito { get; set; }
        internal string NormativaNombre { get; set; }
        internal string NormativaFecha { get; set; }
        //public int TotalLineasDetalle { get; set; }
        public int TotalDecimales { get; set; }
        public string CodigoMoneda { get; set; }

    }
}
