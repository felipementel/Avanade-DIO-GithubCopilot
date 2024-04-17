using System.Diagnostics.CodeAnalysis;
using Avanade.DIO.BookStore.Infra.Database.Maps.Base;

namespace Avanade.DIO.BookStore.Infra.Database.Maps.Setup
{
    [ExcludeFromCodeCoverage]
    public static class SetupMap
    {
        public static void ConfigureMaps()
        {
            BaseEntityMap.Configure();
            BookPublisher.BookPublisherMap.Configure();
            Book.BookMap.Configure();
        }
    }
}