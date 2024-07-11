using ApiLivraria.DTO.Book;
using ApiLivraria.Models;

namespace ApiLivraria.Services.Books
{
    public interface IBookInterface
    {
        Task<ResponseModel<List<BookModel>>> ListBooks();
        Task<ResponseModel<BookModel>> GetBookById(int bookId);
        Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId);
        Task<ResponseModel<List<BookModel>>> CreateNewBook(CreateBookDto bookDto);
        Task<ResponseModel<List<BookModel>>> EditBook(EditBookDto bookDto);
        Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId);
    }
}
