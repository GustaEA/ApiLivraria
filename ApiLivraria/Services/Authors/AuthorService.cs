using ApiLivraria.Data;
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

        public Task<ResponseModel<AuthorModel>> GetAuthroByBookId(int bookId)
        {
            throw new NotImplementedException();
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
    }
}
