using Avanade.DIO.BookStore.Application.Interfaces.Book;
using Avanade.DIO.BookStore.Application.Interfaces.BookPublisher;
using Avanade.DIO.BookStore.Application.Services.Book;
using Avanade.DIO.BookStore.Application.Services.BookPublisher;
using Avanade.DIO.BookStore.Domain.Aggregates.Book.Entities;
using Avanade.DIO.BookStore.Domain.Aggregates.Book.Interfaces.Repositories;
using Avanade.DIO.BookStore.Domain.Aggregates.Book.Interfaces.Services;
using Avanade.DIO.BookStore.Domain.Aggregates.Book.Services;
using Avanade.DIO.BookStore.Domain.Aggregates.Book.Validators;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Entities;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Services;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Services;
using Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Validators;
using Avanade.DIO.BookStore.Domain.Base.Repository.MongoDB;
using Avanade.DIO.BookStore.Infra.Database.Repositories.Base.MongoDB;
using Avanade.DIO.BookStore.Infra.Database.Repositories.Book;
using Avanade.DIO.BookStore.Infra.Database.Repositories.BookPublisher;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.DIO.BookStore.Infra.CrossCutting
{
    public static class DependencyInjection
    {
        public static void AddRegisterDependencyInjections(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(Application.AutoMapperConfigs.Configs));

            serviceCollection.AddSingleton<IMongoDBContext, MongoDBContext>();

            serviceCollection.AddScoped<IBookPublisherAppService, BookPublisherAppService>();

            serviceCollection.AddScoped<IBookPublisherService, BookPublisherService>();

            serviceCollection.AddTransient<IValidator<BookPublisher>, BookPublisherValidator>();

            serviceCollection.AddScoped<IBookPublisherRepository, BookPublisherRepository>();

            serviceCollection.AddScoped<IBookAppService, BookAppService>();

            serviceCollection.AddScoped<IBookService, BookService>();

            serviceCollection.AddTransient<IValidator<Book>, BookValidator>();

            serviceCollection.AddScoped<IBookRepository, BookRepository>();
        }
    }
}