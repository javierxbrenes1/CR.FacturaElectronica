using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class LineaDetalle
    {
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string NumeroLinea { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("Codigo")]
        public CodigoType[] Codigo { get; set; }

        public decimal Cantidad { get; set; }
        public UnidadMedidaType UnidadMedida { get; set; }
        public string UnidadMedidaComercial { get; set; }
        public string Detalle { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoDescuento { get; set; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MontoDescuentoSpecified { get; set; }

        public string NaturalezaDescuento { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NaturalezaDescuentoSpecified { get; set; }

        public decimal SubTotal { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("Impuesto")]
        public Impuesto[] Impuesto { get; set; }

        public decimal MontoTotalLinea { get; set; }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        public enum UnidadMedidaType
        {

            /// <comentarios/>
            Sp,

            /// <comentarios/>
            m,

            /// <comentarios/>
            kg,

            /// <comentarios/>
            s,

            /// <comentarios/>
            A,

            /// <comentarios/>
            K,

            /// <comentarios/>
            mol,

            /// <comentarios/>
            cd,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("m²")]
            m1,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("m³")]
            m2,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("m/s")]
            ms,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("m/s²")]
            ms1,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("1/m")]
            Item1m,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("kg/m³")]
            kgm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("A/m²")]
            Am,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("A/m")]
            Am1,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("mol/m³")]
            molm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("cd/m²")]
            cdm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("1")]
            Item1,

            /// <comentarios/>
            rad,

            /// <comentarios/>
            sr,

            /// <comentarios/>
            Hz,

            /// <comentarios/>
            N,

            /// <comentarios/>
            Pa,

            /// <comentarios/>
            J,

            /// <comentarios/>
            W,

            /// <comentarios/>
            C,

            /// <comentarios/>
            V,

            /// <comentarios/>
            F,

            /// <comentarios/>
            Ω,

            /// <comentarios/>
            S,

            /// <comentarios/>
            Wb,

            /// <comentarios/>
            T,

            /// <comentarios/>
            H,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("°C")]
            C1,

            /// <comentarios/>
            lm,

            /// <comentarios/>
            lx,

            /// <comentarios/>
            Bq,

            /// <comentarios/>
            Gy,

            /// <comentarios/>
            Sv,

            /// <comentarios/>
            kat,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("Pa·s")]
            Pas,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("N·m")]
            Nm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("N/m")]
            Nm1,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("rad/s")]
            rads,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("rad/s²")]
            rads1,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("W/m²")]
            Wm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("J/K")]
            JK,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("J/(kg·K)")]
            JkgK,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("J/kg")]
            Jkg,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("W/(m·K)")]
            WmK,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("J/m³")]
            Jm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("V/m")]
            Vm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("C/m³")]
            Cm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("C/m²")]
            Cm1,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("F/m")]
            Fm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("H/m")]
            Hm,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("J/mol")]
            Jmol,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("J/(mol·K)")]
            JmolK,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("C/kg")]
            Ckg,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("Gy/s")]
            Gys,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("W/sr")]
            Wsr,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("W/(m²·sr)")]
            Wmsr,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("kat/m³")]
            katm,

            /// <comentarios/>
            min,

            /// <comentarios/>
            h,

            /// <comentarios/>
            d,

            /// <comentarios/>
            º,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("´")]
            Item,

            /// <comentarios/>
            [System.Xml.Serialization.XmlEnumAttribute("´´")]
            Item2,

            /// <comentarios/>
            L,

            /// <comentarios/>
            t,

            /// <comentarios/>
            Np,

            /// <comentarios/>
            B,

            /// <comentarios/>
            eV,

            /// <comentarios/>
            u,

            /// <comentarios/>
            ua,

            /// <comentarios/>
            Unid,

            /// <comentarios/>
            Gal,

            /// <comentarios/>
            g,

            /// <comentarios/>
            Km,

            /// <comentarios/>
            ln,

            /// <comentarios/>
            cm,

            /// <comentarios/>
            mL,

            /// <comentarios/>
            mm,

            /// <comentarios/>
            Oz,

            /// <comentarios/>
            Otros,
        }

    }
}
