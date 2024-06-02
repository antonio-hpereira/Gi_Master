using AutoMapper;
using GI_Master_FrontEnd.Models;
using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (id == 1)
                ViewBag.Message = "Departamento adicionado com sucesso!";

            if (id == 2)
                ViewBag.Message = "Departamento atualizado com sucesso!";

            if (id == 3)
                ViewBag.Message = "Departamento excluído com sucesso!";

            var emprsas = await _empresaservices.FindAllEmpresas("");

            return View(emprsas);

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
                Text = i.Sigla,
                Value = i.ID.ToString()
            });

            ViewBag.departamentosDropDown = departamentosDropDown.ToList();


            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DepartamentosCreate(Departamentos model)
        {
            EmpresasVM empresas = _mapper.Map<EmpresasVM>(model);

            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _empresaservices.CreateEmpresa(empresas, token);
                if (response != null)
                    return RedirectToAction(nameof(DepartamentosList), new { id = 1 });

            }
            return View(model);

        }
    }
}
