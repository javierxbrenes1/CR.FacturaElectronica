using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Generadores.Interfaces;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorDocumentoReferencia 
    {
        private readonly IMapper mapper;

        public FacturaCreadorDocumentoReferencia()
        {
            var config = new MapperConfiguration(t => {
                t.CreateMap<DocumentoReferenciaSistema, CR.FEL.Detalles.InformacionReferencia>()
                .ForMember(m => m.Codigo, o => o.Ignore())
                .ForMember(m => m.TipoDoc, o => o.Ignore());
            });

            mapper = new Mapper(config);
        }
        public CR.FEL.Detalles.InformacionReferencia[] CrearArregloReferencias(DocumentoReferenciaSistema[] referenciasSistema)
        {
            if (referenciasSistema == null || referenciasSistema.Length <= 0) return null;
            var arregloFelDocsReferencias = new CR.FEL.Detalles.InformacionReferencia[referenciasSistema.Length];
            CR.FEL.Detalles.InformacionReferencia refAux;
            for (int i = 0; i < referenciasSistema.Length; i++)
            {
                refAux = mapper.Map<CR.FEL.Detalles.InformacionReferencia>(referenciasSistema[i]);
                refAux.Codigo = ModFunciones.ObtenerValorEnumerador(referenciasSistema[i].Codigo, CR.FEL.Detalles.InformacionReferencia.InformacionReferenciaCodigo.Item99);
                refAux.TipoDoc = ModFunciones.ObtenerValorEnumerador(referenciasSistema[i].TipoDoc, CR.FEL.Detalles.InformacionReferencia.TipoDocumento.Item99);
                arregloFelDocsReferencias[i] = refAux;
            }
            return arregloFelDocsReferencias;
        }

        
    }
}
