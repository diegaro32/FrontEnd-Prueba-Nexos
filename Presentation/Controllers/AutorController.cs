using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using Presentation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutor_Api _autorApi;

        public AutorController(IAutor_Api autorApi)
        {
            _autorApi = autorApi;
        }
        public async Task<IActionResult> Index()
        {
            List<Autor> _autorList = await _autorApi.GetAutors();
            return View(_autorList);
        }

        public IActionResult Autor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(Autor oAutor)
        {
            bool _Iscorrect = false;
            if (oAutor.IdAutor == 0)
            {
                _Iscorrect = await _autorApi.CreateAutor(oAutor);
            }

            if (_Iscorrect)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
    }
}
