using ApiLivraria.DTO.Link;
using ApiLivraria.Models;

namespace ApiLivraria.DTO.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public AuthorLinkDto Author { get; set; }
    }
}
