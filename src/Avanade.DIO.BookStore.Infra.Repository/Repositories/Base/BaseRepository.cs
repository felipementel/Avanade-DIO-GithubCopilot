using Avanade.DIO.BookStore.Domain.Aggregates;
using Avanade.DIO.BookStore.Domain.Base.Repository;
using Avanade.DIO.BookStore.Domain.Base.Repository.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.DIO.BookStore.Infra.Database.Repositories.Base
{
    public abstract class BaseRepository<TEntity, Tid>
        : IBaseRepository<TEntity, Tid> where TEntity : BaseEntity<Tid>
    {
        public readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(IMongoDBContext context, string collectionName)
        {
            _collection = context.GetCollection<TEntity>(collection: collectionName);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(id => id.Id, entity.Id);

            return _collection.ReplaceOneAsync(filter: filter, replacement: entity);
        }

        public virtual Task DeleteAsync(Tid id)
        {
            return _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq(x => x.Id, id));
        }

        public virtual async Task<TEntity> FindByIdAsync(Tid id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);

            var item = await _collection.FindAsync(filter: filter);

            return await item.FirstOrDefaultAsync();
        }

        public virtual async Task<List<TEntity>> FindAllAsync()
        {
            var all = await _collection.FindAsync(filter: new BsonDocument());

            return await all.ToListAsync();
        }
    }
}