using System.Diagnostics.CodeAnalysis;

namespace Avanade.DIO.BookStore.Application.AutoMapperConfigs
{
    [ExcludeFromCodeCoverage]
    public static class Configs
    {
        public static AutoMapper.MapperConfiguration RegisterMappings() =>
          new AutoMapper.MapperConfiguration(cfg =>
          {
              cfg.AllowNullCollections = true;

              cfg.AddProfile(new Application.AutoMapperConfigs.Profiles.Book.BookProfile());
              cfg.AddProfile(new Application.AutoMapperConfigs.Profiles.BookPublisher.BookPublisherProfile());
          });
    }
}