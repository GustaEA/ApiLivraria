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
    }
}
