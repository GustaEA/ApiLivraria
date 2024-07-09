using ApiLivraria.Models;

namespace ApiLivraria.Services.Authors
{
    public interface IAuthorInterface
    {
        Task<ResponseModel<List<AuthorModel>>> ListAuthors();
        Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId);
        Task<ResponseModel<AuthorModel>> GetAuthroByBookId(int bookId);
    }
}
