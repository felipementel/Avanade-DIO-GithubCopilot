using System.Threading.Tasks;
using Avanade.DIO.BookStore.Domain.Base.Repository;

namespace Avanade.DIO.BookStore.Domain.Aggregates.Book.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Entities.Book, string>
    {
        Task<bool> GetByTitleAsync(string title);
    }
}