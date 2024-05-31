using AutoMapper;
using GIMaster_Empregados.Data.ValueObjects;
using GIMaster_Empregados.Entidades;

namespace GIMaster_Empregados.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<EmpregadoVO, Empregados>();
                config.CreateMap<Empregados, EmpregadoVO>();
            });
            return mappingConfig;
        }
    }
}
