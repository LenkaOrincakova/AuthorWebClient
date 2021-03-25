using AuthorWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorWebClient.Data
{
    public interface IAuthorsService
    {
        Task<IList<Author>> GetAuthorsAsync();
        Task AddAuthorAsync(Author author);
        Task<IList<Book>> GetBooksAsync();
        Task AddBookAsync(Book book);
        Task RemoveBookAsync(int isbn);

    }
}
