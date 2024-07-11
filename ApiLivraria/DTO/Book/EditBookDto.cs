using ApiLivraria.DTO.Link;
using ApiLivraria.Models;

namespace ApiLivraria.DTO.Book
{
    public class EditBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorLinkDto Author { get; set; }
    }
}
