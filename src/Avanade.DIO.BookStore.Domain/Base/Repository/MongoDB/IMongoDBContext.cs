using MongoDB.Driver;

namespace Avanade.DIO.BookStore.Domain.Base.Repository.MongoDB
{
    public interface IMongoDBContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string collection);
    }
}