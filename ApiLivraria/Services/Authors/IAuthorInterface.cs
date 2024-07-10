using ApiLivraria.DTO.Author;
using ApiLivraria.Models;

namespace ApiLivraria.Services.Authors
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId);
        Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId);
        Task<ResponseModel<List<AuthorModel>>> CreateNewAuthor(CreateAuthorDto author);
        Task<ResponseModel<List<AuthorModel>>> EditAuthor(EditAuthorDto authorDto);
        Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId);
    }
}
