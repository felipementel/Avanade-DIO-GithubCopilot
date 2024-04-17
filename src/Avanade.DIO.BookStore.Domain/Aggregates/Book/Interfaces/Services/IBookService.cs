using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Domain.Aggregates.Book.Interfaces.Services
{
    public interface IBookService
    {
        Task<Entities.Book> AddBookAsync(Entities.Book book);

        Task<Entities.Book> GetBookAsync(string id);

        Task<List<Entities.Book>> ListBookAsync();

        Task<Entities.Book> UpdateBookAsync(string id, Entities.Book book);

        Task<bool> DeleteBookAsync(string id);
    }
}