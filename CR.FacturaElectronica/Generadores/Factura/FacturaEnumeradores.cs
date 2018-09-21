using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaEnumeradores
    {
        internal static FacturaElectronicaCondicionVenta ObtenerCondicionVenta(string vlcCondicionVenta)
        {
            FacturaElectronicaCondicionVenta vloValor;
            switch (vlcCondicionVenta)
            {
                case "01":
                    vloValor = FacturaElectronicaCondicionVenta.Item01;
                    break;
                case "02":
                    vloValor = FacturaElectronicaCondicionVenta.Item02;
                    break;
                case "03":
                    vloValor = FacturaElectronicaCondicionVenta.Item03;
                    break;
                case "04":
                    vloValor = FacturaElectronicaCondicionVenta.Item04;
                    break;
                case "05":
                    vloValor = FacturaElectronicaCondicionVenta.Item05;
                    break;
                case "06":
                    vloValor = FacturaElectronicaCondicionVenta.Item06;
                    break;
                default:
                    vloValor = FacturaElectronicaCondicionVenta.Item99;
                    break;
            }
            return vloValor;
        }

        internal static FacturaElectronicaMedioPago ObtenerMedioPago(string vlcMedioPago)
        {
            FacturaElectronicaMedioPago vloValor;
            switch (vlcMedioPago)
            {
                case "01":
                    vloValor = FacturaElectronicaMedioPago.Item01;
                    break;
                case "02":
                    vloValor = FacturaElectronicaMedioPago.Item02;
                    break;
                case "03":
                    vloValor = FacturaElectronicaMedioPago.Item03;
                    break;
                case "04":
                    vloValor = FacturaElectronicaMedioPago.Item04;
                    break;
                case "05":
                    vloValor = FacturaElectronicaMedioPago.Item05;
                    break;
                default:
                    vloValor = FacturaElectronicaMedioPago.Item99;
                    break;

            }
            return vloValor;
        }

        internal static FacturaElectronicaInformacionReferenciaTipoDoc DefinirReferenciaTipoDoc(string pvcTipoDocRef)
        {
            FacturaElectronicaInformacionReferenciaTipoDoc vloRes;

            switch (pvcTipoDocRef)
            {
                /// <comentarios/>
                case "01":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item01;
                    break;
                case "02":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item02;
                    break;
                case "03":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item03;
                    break;
                case "04":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item04;
                    break;
                case "05":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item05;
                    break;
                case "06":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item06;
                    break;
                case "07":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item07;
                    break;
                case "08":
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item08;
                    break;
                default:
                    vloRes = FacturaElectronicaInformacionReferenciaTipoDoc.Item99;
                    break;
            }
            return vloRes;
        }

        internal static FacturaElectronicaInformacionReferenciaCodigo DefinirCodigoReferencia(string pvcCodigo)
        {
            FacturaElectronicaInformacionReferenciaCodigo vloRes;

            switch (pvcCodigo)
            {
                case "01":
                    vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item01;
                    break;
                case "02":
                    vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item02;
                    break;
                case "03":
                    vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item03;
                    break;
                case "04":
                    vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item04;
                    break;
                case "05":
                    vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item05;
                    break;
                default:
                    vloRes = FacturaElectronicaInformacionReferenciaCodigo.Item99;
                    break;
            }
            return vloRes;
        }

        internal static IdentificacionTypeTipo ObtenertipoIdentificacion(string vlcTipoIdentificacionReceptor)
        {
            IdentificacionTypeTipo vloRespuesta;
            switch (vlcTipoIdentificacionReceptor)
            {
                case "01":
                    vloRespuesta = IdentificacionTypeTipo.Item01;
                    break;
                case "02":
                    vloRespuesta = IdentificacionTypeTipo.Item02;
                    break;
                case "03":
                    vloRespuesta = IdentificacionTypeTipo.Item03;
                    break;
                default:
                    vloRespuesta = IdentificacionTypeTipo.Item04;
                    break;
            }
            return vloRespuesta;
        }

        internal static ExoneracionTypeTipoDocumento ObtenerTipoDocumento(string pvcTipoDoc)
        {
            ExoneracionTypeTipoDocumento vloValor;
            try
            {
                switch (pvcTipoDoc)
                {
                    case "01":
                        vloValor = ExoneracionTypeTipoDocumento.Item01;
                        break;
                    case "02":
                        vloValor = ExoneracionTypeTipoDocumento.Item02;
                        break;
                    case "03":
                        vloValor = ExoneracionTypeTipoDocumento.Item03;
                        break;
                    case "04":
                        vloValor = ExoneracionTypeTipoDocumento.Item04;
                        break;
                    case "05":
                        vloValor = ExoneracionTypeTipoDocumento.Item05;
                        break;
                    default:
                        vloValor = ExoneracionTypeTipoDocumento.Item99;
                        break;
                }
                return vloValor;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        internal static UnidadMedidaType getUnidadDeMedida(string unidMedidaSistema)
        {
            try
            {
                return (UnidadMedidaType)Enum.Parse(typeof(UnidadMedidaType), unidMedidaSistema);
            }
            catch (Exception)
            {
                return UnidadMedidaType.Unid;
            }
        }

        internal static CodigoTypeTipo ObtenerTipoCodigoDetalle(string pvcTipocodigo)
        {
            CodigoTypeTipo vloValor;

            switch (pvcTipocodigo)
            {
                case "01":
                    vloValor = CodigoTypeTipo.Item01;
                    break;
                case "02":
                    vloValor = CodigoTypeTipo.Item02;
                    break;
                case "03":
                    vloValor = CodigoTypeTipo.Item03;
                    break;
                case "04":
                    vloValor = CodigoTypeTipo.Item04;
                    break;
                default:
                    vloValor = CodigoTypeTipo.Item99;
                    break;

            }
            return vloValor;

        }

        internal static ImpuestoTypeCodigo ObtenerCodigoImpuesto(string pvcCodigo)
        {
            ImpuestoTypeCodigo vloValor;
            try
            {
                switch (pvcCodigo)
                {
                    case "01":
                        vloValor = ImpuestoTypeCodigo.Item01;
                        break;
                    case "02":
                        vloValor = ImpuestoTypeCodigo.Item02;
                        break;
                    case "03":
                        vloValor = ImpuestoTypeCodigo.Item03;
                        break;
                    case "04":
                        vloValor = ImpuestoTypeCodigo.Item04;
                        break;
                    case "05":
                        vloValor = ImpuestoTypeCodigo.Item05;
                        break;
                    case "06":
                        vloValor = ImpuestoTypeCodigo.Item06;
                        break;
                    case "07":
                        vloValor = ImpuestoTypeCodigo.Item07;
                        break;
                    case "08":
                        vloValor = ImpuestoTypeCodigo.Item08;
                        break;
                    case "09":
                        vloValor = ImpuestoTypeCodigo.Item09;
                        break;
                    case "10":
                        vloValor = ImpuestoTypeCodigo.Item10;
                        break;
                    case "11":
                        vloValor = ImpuestoTypeCodigo.Item11;
                        break;
                    default:
                        vloValor = ImpuestoTypeCodigo.Item99;
                        break;
                }
                return vloValor;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
