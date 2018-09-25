using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Tiquete
{
    internal class TiqueteCreadorResumen : ICreadorResumen<TiqueteElectronicoResumenFactura>
    {
        public TiqueteElectronicoResumenFactura CrearResumen(Resumen resumenSistema)
        {
            var resumenFel = mapper.Map<TiqueteElectronicoResumenFactura>(resumenSistema);
            try
            {
                resumenFel.CodigoMoneda = (TiqueteElectronicoResumenFacturaCodigoMoneda)Enum.Parse(typeof(TiqueteElectronicoResumenFacturaCodigoMoneda), resumenSistema.Moneda);
            }
            catch (Exception)
            {
                resumenFel.CodigoMoneda = TiqueteElectronicoResumenFacturaCodigoMoneda.CRC;
            }
            AsignarTrueABanderasDeDespliegue(resumenFel);
            return resumenFel;
        }

        private readonly IMapper mapper;

        public TiqueteCreadorResumen()
        {
            var config = new MapperConfiguration(t =>
            {
                t.CreateMap<Resumen, TiqueteElectronicoResumenFactura>()
                .ForMember(m => m.CodigoMoneda, i => i.Ignore());
            });

            mapper = new Mapper(config);
        }

       

        private void AsignarTrueABanderasDeDespliegue(TiqueteElectronicoResumenFactura resumenFel)
        {
            resumenFel.CodigoMonedaSpecified = true;
            resumenFel.TipoCambioSpecified = true;
            resumenFel.TotalDescuentosSpecified = true;
            resumenFel.TotalExentoSpecified = true;
            resumenFel.TotalGravadoSpecified = true;
            resumenFel.TotalImpuestoSpecified = true;
            resumenFel.TotalMercanciasExentasSpecified = true;
            resumenFel.TotalMercanciasGravadasSpecified = true;
            resumenFel.TotalServExentosSpecified = true;
            resumenFel.TotalServGravadosSpecified = true;
        }
    }
}
