using AutoMapper;
using GiMaster_Empregado.Data.ValueObjects;
using GiMaster_Empregado.Entidades;

namespace GiMaster_Empregado.Config
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
