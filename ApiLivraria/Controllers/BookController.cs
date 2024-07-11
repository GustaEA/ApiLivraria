using ApiLivraria.DTO.Book;
using ApiLivraria.Models;
using ApiLivraria.Services.Books;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;

        public BookController(IBookInterface bookInterface)
        {
            this._bookInterface = bookInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> ListBooks()
        {
            var books = await _bookInterface.ListBooks();
            return Ok(books);
        }

        [HttpGet("BuscarLivrosPorId/{bookId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById(int bookId)
        {
            var book = await _bookInterface.GetBookById(bookId);
            return Ok(book);
        }

        [HttpGet("BuscarLivrosPorAutorId/{authorId}")]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookByAuthorId(int authorId)
        {
            var books = await _bookInterface.GetBooksByAuthorId(authorId);
            return Ok(books);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> CreateNewBook(CreateBookDto bookDto)
        {
            var book = await _bookInterface.CreateNewBook(bookDto);
            return Ok(book);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> EditBook(EditBookDto bookDto)
        {
            var book = await _bookInterface.EditBook(bookDto);
            return Ok(book);
        }

        [HttpDelete("DeletarLivro")]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> DeleteBook(int bookId)
        {
            var book = await _bookInterface.DeleteBook(bookId);
            return Ok(book);
        }
    }
}
