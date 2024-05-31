using AutoMapper;
using GI_Master_FrontEnd.Models;
using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.Utils;
using GI_Master_FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace GI_Master_FrontEnd.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IEmpresasServices _empresaservices;
        private IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmpresasController(IEmpresasServices empresaservices, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _empresaservices = empresaservices;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        public async Task<IActionResult> EmpresasCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EmpresasCreate(Empresas model)
        {
           EmpresasVM empresas = _mapper.Map<EmpresasVM>(model);

            if(ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                string upload = webRootPath + WC.ImagenEmpresasSedePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                empresas.foto = fileName + extension;

                var response = await _empresaservices.CreateEmpresa(empresas, token);
                if(response != null)
                    return RedirectToAction(nameof(EmpresaList), new {id = 1});
              
            }
            return View(model);

        }

        [Authorize]
        public async Task<IActionResult> EmpresaList(int id)
        {
            if (id == 1)
                ViewBag.Message = "Empresa adicionada com sucesso!";

            if (id == 2)
                ViewBag.Message = "Empresa atualizada com sucesso!";

            if (id == 3)
                ViewBag.Message = "Empresa excluída com sucesso!";

            var emprsas = await _empresaservices.FindAllEmpresas("");

            return View(emprsas);

        }

        [Authorize]
        public async Task<IActionResult> EmpresaUpdate(string id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _empresaservices.FindEmpresasByID(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EmpresaUpdate(EmpresasVM model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;
                string upload = webRootPath + WC.ImagenEmpresasSedePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                model.foto = fileName + extension;
                var response = await _empresaservices.UpdateEmpresa(model, token);
                if (response != null) return RedirectToAction(
                     nameof(EmpresaList), new { id = 2 });
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EmpresaDelete(string id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _empresaservices.FindEmpresasByID(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> EmpresaDelete(EmpresasVM model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _empresaservices.DeleteEmpresaById(model.ID.ToString(), token);
            if (response) return RedirectToAction(nameof(EmpresaList), new { id = 3 });
            return View(model);
        }

    }
}
