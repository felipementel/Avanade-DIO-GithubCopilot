using System.Threading.Tasks;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using Avanade.DIO.BookStore.Domain.Base.Repository.MongoDB;
using Avanade.DIO.BookStore.Infra.Database.Repositories.Base;
using MongoDB.Driver;

namespace Avanade.DIO.BookStore.Infra.Database.Repositories.BookPublisher
{
    public class BookPublisherRepository :
        BaseRepository<Domain.Aggregates.BookPublisher.Entities.BookPublisher, string>,
        IBookPublisherRepository
    {
        public BookPublisherRepository(IMongoDBContext mongoDBContext) : base(mongoDBContext, "BookPublisher")
        {
        }
    }
}