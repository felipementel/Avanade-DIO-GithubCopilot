using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Application.Interfaces.Book
{
    public interface IBookAppService
    {
        Task<Dtos.Book.BookDto> AddBookAsync(Dtos.Book.BookDto BookDto);

        Task<Dtos.Book.BookDto> GetBookAsync(string id);

        Task<List<Dtos.Book.BookDto>> ListBookAsync();

        Task<Dtos.Book.BookDto> UpdateBookAsync(string id, Application.Dtos.Book.BookDto BookDto);

        Task<bool> DeleteBookAsync(string id);
    }
}