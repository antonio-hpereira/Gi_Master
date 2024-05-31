using AutoMapper;
using GI_Master_FrontEnd.Models;
using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.Utils;
using GI_Master_FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace GI_Master_FrontEnd.Controllers
{
    public class EmpregadosController : Controller
    {
        private readonly IEmpregadosServices _empregadoService;
        private IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmpregadosController(IEmpregadosServices empregadoService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _empregadoService = empregadoService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        public async Task<IActionResult> EmpregadoList(int id)
        {
            
            var empregados = await _empregadoService.FindAllEmpregados("");  
            
            if(id == 1)
            ViewBag.Message = "Empregado adicionado com sucesso!";

            if (id == 2)
                ViewBag.Message = "Empregado atualizado com sucesso!";

            if (id == 3)
                ViewBag.Message = "Empregado excluído com sucesso!";

            return View(empregados);
        }


        [Authorize]
        public async Task<IActionResult> EmpregadosCreate()
        {
            return View();
        }
       

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EmpregadosCreate(Empregados v)
        {
            EmpregadoVM model = _mapper.Map<EmpregadoVM>(v);

            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");

                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath;

                string upload = webRootPath + WC.ImagenEmpregadoPath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                using(var fileStream = new FileStream(Path.Combine(upload,fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                model.Foto = fileName + extension;
               
                var response = await _empregadoService.CreateEmpregado(model, token);
                if (response != null)
                {                   
                    return RedirectToAction(nameof(EmpregadoList), new {id = 1});
                }                   
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EmpregadostUpdate(string id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _empregadoService.FindEmpregadoById(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EmpregadostUpdate(EmpregadoVM model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _empregadoService.UpdateEmpregado(model, token);
                if (response != null) return RedirectToAction(
                     nameof(EmpregadoList),new { id = 2 });
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> EmpregadostDetails(string id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _empregadoService.FindEmpregadoById(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        public async Task<IActionResult> EmpregadostDelete(string id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _empregadoService.FindEmpregadoById(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> EmpregadostDelete(EmpregadoVM model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _empregadoService.DeleteEmpregadoById(model.ID.ToString(), token);
            if (response) return RedirectToAction(
                    nameof(EmpregadoList),new {id = 3});
            return View(model);
        }
    }
}
