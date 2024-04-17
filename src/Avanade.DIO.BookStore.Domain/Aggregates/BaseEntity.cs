using FluentValidation.Results;
using System.Collections.Generic;

namespace Avanade.DIO.BookStore.Domain.Aggregates
{
    public record BaseEntity<Tid>
    {
        public Tid Id { get; set; }

        public List<string> Erros { get; set; }
    }
}