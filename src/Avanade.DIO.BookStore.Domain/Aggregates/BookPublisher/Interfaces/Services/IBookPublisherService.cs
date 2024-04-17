using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Services
{
    public interface IBookPublisherService
    {
        Task<Entities.BookPublisher> AddBookPublisherAsync(Entities.BookPublisher BookPublisher);

        Task<Entities.BookPublisher> GetBookPublisherAsync(string id);

        Task<List<Entities.BookPublisher>> ListBookPublisherAsync();

        Task<Entities.BookPublisher> UpdateBookPublisherAsync(string id, Entities.BookPublisher BookPublisher);

        Task<bool> DeleteBookPublisherAsync(string id);
    }
}