using ApiLivraria.Data;
using ApiLivraria.DTO.Book;
using ApiLivraria.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLivraria.Services.Books
{
    public class BookService : IBookInterface
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<ResponseModel<List<BookModel>>> CreateNewBook(CreateBookDto bookDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == bookDto.Author.Id);
                if (author == null) 
                {
                    response.Message = "Nenhum autor encontrado!";
                    response.Status = false;
                    return response;
                }

                var book = new BookModel()
                {
                    Title = bookDto.Title,
                    Author = author
                };

                _context.Add(book);
                await _context.SaveChangesAsync();
                
                response.Data = await _context.Books.Include(x => x.Author).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> DeleteBook(int bookId)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(x => x.Id == bookId);
                if(book == null)
                {
                    response.Message = "Livro não localizado!";
                    response.Status = false;
                    return response;
                }

                _context.Remove(book);
                await _context.SaveChangesAsync();

                response.Data = await _context.Books.ToListAsync();
                response.Message = "Livro removido com sucesso!";

                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> EditBook(EditBookDto bookDto)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(x => x.Id == bookDto.Id);
                var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == bookDto.Author.Id);

                if(book == null)
                {
                    response.Message = "Livro não localizado!";
                    response.Status = false;
                    return response;
                }

                if (author == null)
                {
                    response.Message = "Autor não encontrado!";
                    response.Status = false;
                    return response;
                }

                book.Title = bookDto.Title;
                book.Author = author;

                _context.Update(book);
                await _context.SaveChangesAsync();
                response.Data = await _context.Books.ToListAsync();
                return response;


            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<BookModel>> GetBookById(int bookId)
        {
            ResponseModel<BookModel> response = new ResponseModel<BookModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(x => x.Id == bookId);
                if (book == null)
                {
                    response.Message = "Livro não localizado!";
                    response.Status = false;
                    return response;
                }

                response.Data = book;
                response.Message = "Livro localizado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> GetBooksByAuthorId(int authorId)
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).Where(x => x.Author.Id == authorId).ToListAsync();
                if (book == null)
                {
                    response.Message = "Nenhum registro encontrado!";
                    response.Status= false;
                    return response;
                }
                response.Data = book;
                response.Message = "Livros encontrados!";
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<BookModel>>> ListBooks()
        {
            ResponseModel<List<BookModel>> response = new ResponseModel<List<BookModel>>();
            try
            {
                var books = await _context.Books.Include(a => a.Author).ToListAsync();
                if(books == null)
                {
                    response.Message = "Nenhum registro encontrado!";
                    response.Status = false;
                    return response;
                }

                response.Data = books;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
