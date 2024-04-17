using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Avanade.DIO.BookStore.Infra.Database.Maps.BookPublisher
{
    public static class BookPublisherMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Domain.Aggregates.BookPublisher.Entities.BookPublisher>(map =>
            {
                map.AutoMap();

                map.SetIgnoreExtraElements(true);

                map
                .MapMember(er => er.Name)
                .SetElementName("BookPublisherName")
                .SetSerializer(new StringSerializer(MongoDB.Bson.BsonType.String));
            });
        }
    }
}