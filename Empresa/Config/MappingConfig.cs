using AutoMapper;
using GIMaster_Empresa.Data.ValueObjects;
using GIMaster_Empresa.Entidades;

namespace GIMaster_Empresa.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<EmpresaVO, Empresas>();
                config.CreateMap<Empresas, EmpresaVO>();
            });
            return mappingConfig;
        }
    }
}
