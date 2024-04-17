using System;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.DIO.BookStore.Domain.Aggregates.Book.Entities
{
    [ExcludeFromCodeCoverage]
    public record Book : BaseEntity<string>
    {
        public Book(
            string title,
            string author,
            DateTime lauchDate,
            bool active,
            decimal value,
            BookPublisher.Entities.BookPublisher BookPublisher)
        {
            Title = title;
            Author = author;
            LauchDate = lauchDate;
            Active = active;
            Value = value;
            BookPublisher = BookPublisher;
        }

        public string Title { get; init; }

        public string Author { get; init; }

        public DateTime LauchDate { get; init; }

        public bool Active { get; init; }

        public decimal Value { get; init; }

        public BookPublisher.Entities.BookPublisher BookPublisher { get; init; }
    }
}