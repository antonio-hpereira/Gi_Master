using AutoMapper;
using GI_Master_FrontEnd.Models;
using GI_Master_FrontEnd.ViewModels;

namespace GI_Master_FrontEnd.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<EmpregadoVM, Empregados>();
                config.CreateMap<Empregados, EmpregadoVM>();
                config.CreateMap<EmpresasVM, Empresas>();
                config.CreateMap<Empresas, EmpresasVM>();
                config.CreateMap<DepartamentosVM, Departamentos>();
                config.CreateMap<Departamentos, DepartamentosVM>();
            });
            return mappingConfig;
        }
    }
}
