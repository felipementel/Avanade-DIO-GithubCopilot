using MongoDB.Bson.Serialization;

namespace Avanade.DIO.BookStore.Infra.Database.Maps.Book
{
    public static class BookMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Domain.Aggregates.Book.Entities.Book>(map =>
            {
                map.AutoMap();

                map.SetIgnoreExtraElements(true);

                map
                .MapMember(er => er.Title)
                .SetElementName("bookTitle");
            });
        }
    }
}