using Avanade.DIO.BookStore.Application.Dtos.Base;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.DIO.BookStore.Application.Dtos.BookPublisher
{
    [ExcludeFromCodeCoverage]
    public class BookPublisherDto : BaseDto
    {
        public string Nome { get; set; }
    }
}