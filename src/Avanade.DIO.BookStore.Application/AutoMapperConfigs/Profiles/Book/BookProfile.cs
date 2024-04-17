using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.DIO.BookStore.Application.AutoMapperConfigs.Profiles.Book
{
    [ExcludeFromCodeCoverage]
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Dtos.Book.BookDto, Domain.Aggregates.Book.Entities.Book>()
                    .ConstructUsing((ctor, res) =>
                    {
                        return new Domain.Aggregates.Book.Entities.Book(
                        ctor.Titulo,
                        ctor.Autor,
                        ctor.DataLancamento,
                        ctor.Ativo,
                        ctor.Valor,
                        BookPublisher: res.Mapper.Map<Domain.Aggregates.BookPublisher.Entities.BookPublisher>(ctor.Editora));
                    });


            CreateMap<Domain.Aggregates.Book.Entities.Book, Dtos.Book.BookDto>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => src.Author))
                .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.LauchDate))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Editora, opt => opt.MapFrom(src => src.BookPublisher))
                .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Erros));
        }
    }
}