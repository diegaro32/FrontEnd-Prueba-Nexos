using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;
using Presentation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class BookController : Controller
    {

        private readonly IBook_Api _bookApi;
        private readonly IAutor_Api _autorApi;

        public BookController(IBook_Api bookApi, IAutor_Api autorApi)
        {
            _bookApi = bookApi;
            _autorApi = autorApi;
        }
        public async Task<IActionResult> Index()
        {
            List<Book> _bookList = await _bookApi.GetBooks();
            return View(_bookList);
        }

        public async Task<IActionResult> Book()
        {
            List<Autor> _autorList = await _autorApi.GetAutors();
            List<SelectListItem> items = _autorList.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Name,
                    Value = d.IdAutor.ToString(),
                    Selected = false
                };
            });

            ViewBag.Items = items;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book oBook)
        {
            bool _Iscorrect = false;
            if (oBook.IdBook == 0)
            {
                _Iscorrect = await _bookApi.CreateBook(oBook);
            }

            if (_Iscorrect)
                return RedirectToAction("Index");
            else
                return NoContent();
        }
    }
}
