using Avanade.DIO.BookStore.Application.Dtos.Base;
using Avanade.DIO.BookStore.Application.Dtos.BookPublisher;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.DIO.BookStore.Application.Dtos.Book
{
    [ExcludeFromCodeCoverage]
    public class BookDto : BaseDto
    {
        public string Titulo { get; set; }

        public string Autor { get; set; }

        public DateTime DataLancamento { get; set; }

        public bool Ativo { get; set; }

        public decimal Valor { get; set; }

        public BookPublisherDto Editora { get; set; }
    }
}