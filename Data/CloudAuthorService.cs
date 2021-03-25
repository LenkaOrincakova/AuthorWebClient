using AuthorWebClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthorWebClient.Data
{
    public class CloudAuthorService : IAuthorsService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudAuthorService()
        {
            client = new HttpClient();
        }


        public async Task AddAuthorAsync(Author author)
        {
            string authorAsJson = JsonSerializer.Serialize(author);
            HttpContent content = new StringContent(authorAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/authors", content);
        }

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/authors");
            string message = await stringAsync;
            List<Author> result = JsonSerializer.Deserialize<List<Author>>(message);
            return result;
        }

        public async Task<IList<Book>> GetBooksAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/books");
            string message = await stringAsync;
            List<Book> result = JsonSerializer.Deserialize<List<Book>>(message);
            return result;
        }

        public async Task AddBookAsync(Book book)
        {
            string bookAsJson = JsonSerializer.Serialize(book);
            HttpContent content = new StringContent(bookAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/books", content);
        }

        public async Task RemoveBookAsync(int isbn)
        {
            await client.DeleteAsync($"{uri}/books/{isbn}");
        }
    }
}
