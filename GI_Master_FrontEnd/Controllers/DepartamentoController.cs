using AutoMapper;
using GI_Master_FrontEnd.Models;
using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace GI_Master_FrontEnd.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IEmpresasServices _empresaservices;
        private readonly IDepartamentoServices _departamentoService;
        private IMapper _mapper;

        public DepartamentoController(IEmpresasServices empresaservices, IDepartamentoServices departamentoService, IMapper mapper)
        {
            _empresaservices = empresaservices;
            _departamentoService = departamentoService;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> DepartamentosList(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            if (id == 1)
                ViewBag.Message = "Departamento adicionado com sucesso!";

            if (id == 2)
                ViewBag.Message = "Departamento atualizado com sucesso!";

            if (id == 3)
                ViewBag.Message = "Departamento excluído com sucesso!";

            var departamento = await _departamentoService.FindAllDepartamentos(token);

            return View(departamento);

        }

        [Authorize]
        public async Task<IActionResult> DepartamentosCreate()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            IEnumerable<EmpresasVM> empresas = await _empresaservices.FindAllEmpresas(token);
            IEnumerable<SelectListItem> empresasDropDown = empresas.Select(i => new SelectListItem
            {
                Text = i.RazaoSocial,
                Value = i.ID.ToString()
            });

            ViewBag.empresaDropdow = empresasDropDown.ToList();

            IEnumerable<DepartamentosVM> departamentos = await _departamentoService.FindAllDepartamentos(token);
            IEnumerable<SelectListItem> departamentosDropDown = departamentos.Select(i => new SelectListItem
            {
                Text = i.Nome + " - " + i.Sigla,
                Value = i.Pai.ToString()
            });

            ViewBag.departamentosDropDown = departamentosDropDown.ToList();


            return View();
        }

              
        [HttpPost]
        public async Task<ActionResult<IEnumerable<dynamic>>> DepartamentoPorEmpresa(string idEmpresa)
        {

            var token = await HttpContext.GetTokenAsync("access_token");
            IEnumerable<DepartamentosVM> departamentos = await _departamentoService.FindAllDepartamentos(token);
           
           
            IEnumerable<SelectListItem> departamentosDropDown = departamentos.Select(i => new SelectListItem
            {
                Text = i.Nome + " - " + i.Sigla,
                Value = i.Pai.ToString()
            });

            ViewBag.departamentosDropDown = departamentosDropDown.ToList();


            return new JsonResult(Ok(departamentos));

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DepartamentosCreate(DepartamentosVM model)
        {
           // DepartamentosVM departamento = _mapper.Map<Departamentos>(model);

           
            
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _departamentoService.CreateDepartamentos(model, token);
                if (response != null)
                    return RedirectToAction(nameof(DepartamentosList), new { id = 1 });

          
            return View(model);

        }
    }
}
