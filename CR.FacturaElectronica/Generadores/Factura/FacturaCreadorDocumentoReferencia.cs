using AutoMapper;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Factura;
using CR.FacturaElectronica.Generadores.Interfaces;
using CR.FacturaElectronica.Shared;

namespace CR.FacturaElectronica.Factura
{
    internal class FacturaCreadorDocumentoReferencia : ICreadorDocumentoReferencia<FacturaElectronicaInformacionReferencia>
    {
        private readonly IMapper mapper;

        public FacturaCreadorDocumentoReferencia()
        {
            var config = new MapperConfiguration(t => {
                t.CreateMap<DocumentoReferencia, FacturaElectronicaInformacionReferencia>()
                .ForMember(m => m.Codigo, o => o.Ignore())
                .ForMember(m => m.TipoDoc, o => o.Ignore());
            });

            mapper = new Mapper(config);
        }
        public FacturaElectronicaInformacionReferencia[] CrearArregloReferencias(DocumentoReferencia[] referenciasSistema)
        {
            if (referenciasSistema == null || referenciasSistema.Length <= 0) return null;
            var arregloFelDocsReferencias = new FacturaElectronicaInformacionReferencia[referenciasSistema.Length];
            FacturaElectronicaInformacionReferencia refAux;
            for (int i = 0; i < referenciasSistema.Length; i++)
            {
                refAux = mapper.Map<FacturaElectronicaInformacionReferencia>(referenciasSistema[i]);
                refAux.Codigo = ModFunciones.ObtenerValorEnumerador(referenciasSistema[i].Codigo, FacturaElectronicaInformacionReferenciaCodigo.Item99);
                refAux.TipoDoc = ModFunciones.ObtenerValorEnumerador(referenciasSistema[i].TipoDoc, FacturaElectronicaInformacionReferenciaTipoDoc.Item99);
                arregloFelDocsReferencias[i] = refAux;
            }
            return arregloFelDocsReferencias;
        }

        
    }
}
