using FluentValidation.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Avanade.DIO.BookStore.Application.Dtos.Base
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseDto
    {
        public string Identificador { get; set; }

        [JsonIgnore]
        public List<string> Errors { get; set; } = new List<string>();
    }
}