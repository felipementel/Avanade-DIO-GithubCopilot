using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Application.Interfaces.BookPublisher
{
    public interface IBookPublisherAppService
    {
        Task<Dtos.BookPublisher.BookPublisherDto> AddBookPublisherAsync(Application.Dtos.BookPublisher.BookPublisherDto BookPublisherDto);

        Task<Dtos.BookPublisher.BookPublisherDto> GetBookPublisherAsync(string id);

        Task<List<Dtos.BookPublisher.BookPublisherDto>> ListBookPublisherAsync();

        Task<Dtos.BookPublisher.BookPublisherDto> UpdateBookPublisherAsync(string id, Application.Dtos.BookPublisher.BookPublisherDto BookPublisherDto);

        Task<bool> DeleteBookPublisherAsync(string id);
    }
}