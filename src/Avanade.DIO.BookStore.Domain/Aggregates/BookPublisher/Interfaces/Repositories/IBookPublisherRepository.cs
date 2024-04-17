using System.Threading.Tasks;
using Avanade.DIO.BookStore.Domain.Base.Repository;

namespace Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories
{
    public interface IBookPublisherRepository : IBaseRepository<BookPublisher.Entities.BookPublisher, string>
    {

    }
}