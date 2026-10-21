using Microsoft.AspNetCore.Mvc;

using LibraryManagement.Servisec.Base;

namespace LibraryManagement.API.Controllers

{

    [ApiController]

    [Route("api/books")]

    public class BooksController : ControllerBase

    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)

        {

            _bookService = bookService;

        }

        [HttpGet]

        public IActionResult GetAll()

        {

            return Ok(_bookService.GetAllBooks());

        }

    }

}