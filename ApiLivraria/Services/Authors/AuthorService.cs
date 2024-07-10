using ApiLivraria.Data;
using ApiLivraria.DTO.Author;
using ApiLivraria.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLivraria.Services.Authors
{
    public class AuthorService : IAuthorInterface
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorById(int authorId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == authorId);
                if (author == null)
                {
                    response.Message = "Autor não encontrado!";
                    response.Status = false;
                    return response;
                }

                response.Data = author;
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<AuthorModel>> GetAuthorByBookId(int bookId)
        {
            ResponseModel<AuthorModel> response = new ResponseModel<AuthorModel>();
            try
            {
                var book = await _context.Books.Include(a => a.Author).FirstOrDefaultAsync(b => b.Id == bookId);
                if (book == null)
                {
                    response.Message = "Autor não encontrado!";
                    response.Status = false;
                    return response;
                }

                response.Data = book.Author;
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> ListAuthors()
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var authors = await _context.Authors.ToListAsync();
                response.Data = authors;
                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> CreateNewAuthor(CreateAuthorDto authorDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = new AuthorModel()
                {
                    Name = authorDto.Name,
                    LastName = authorDto.LastName
                };
                _context.Add(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor criado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> EditAuthor(EditAuthorDto authorDto)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();
            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == authorDto.Id);
                if (author == null)
                {
                    response.Message = "Autor não encontrado!";
                    response.Status = false;
                    return response;
                }

                author.Name = authorDto.Name;
                author.LastName = authorDto.LastName;
                _context.Update(author);
                await _context.SaveChangesAsync();

                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor editado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AuthorModel>>> DeleteAuthor(int authorId)
        {
            ResponseModel<List<AuthorModel>> response = new ResponseModel<List<AuthorModel>>();

            try
            {
                var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == authorId);
                if (author == null)
                {
                    response.Message = "Autor não encontrado!";
                    response.Status = false;
                    return response;
                }
                _context.Remove(author);
                await _context.SaveChangesAsync();
                response.Data = await _context.Authors.ToListAsync();
                response.Message = "Autor removido!";
                return  response;
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
