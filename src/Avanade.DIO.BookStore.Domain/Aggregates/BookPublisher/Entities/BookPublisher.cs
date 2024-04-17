using System.Diagnostics.CodeAnalysis;

namespace Avanade.DIO.BookStore.Domain.Aggregates.BookPublisher.Entities
{
    [ExcludeFromCodeCoverage]
    public record BookPublisher : BaseEntity<string>
    {
        internal BookPublisher()
        {
        }

        public BookPublisher(string name)
        {
            Name = name;
        }

        public string Name { get; init; }
    }
}