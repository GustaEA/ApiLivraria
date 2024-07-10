using ApiLivraria.DTO.Author;
using ApiLivraria.Models;
using ApiLivraria.Services.Authors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface _authorInterface;

        public AuthorController(IAuthorInterface authorInterface)
        {
            this._authorInterface = authorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<List<AuthorModel>>> ListAuthors()
        {
            var authors = await _authorInterface.ListAuthors();
            return Ok(authors);
        }

        [HttpGet("BuscarAutorPorId/{AuthorId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int AuthorId)
        {
            var author = await _authorInterface.GetAuthorById(AuthorId);
            return Ok(author);
        }

        [HttpGet("BuscarAutorPorLivroId/{BookId}")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int BookId)
        {
            var author = await _authorInterface.GetAuthorByBookId(BookId);
            return Ok(author);
        }

        [HttpPost ("CriarAutor")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> CreateNewAuthor(CreateAuthorDto authorDto)
        {
            var author = await _authorInterface.CreateNewAuthor(authorDto);
            return Ok(author);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> EditAuthor(EditAuthorDto authorDto)
        {
            var author = await _authorInterface.EditAuthor(authorDto);
            return Ok(author);
        }

        [HttpDelete("DeletarAutor")]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> DeleteAuthor(int authorId)
        {
            var author = await _authorInterface.DeleteAuthor(authorId);
            return Ok(author);
        }
    }
}
