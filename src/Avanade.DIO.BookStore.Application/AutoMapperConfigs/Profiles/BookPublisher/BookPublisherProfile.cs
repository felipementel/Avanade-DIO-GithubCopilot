using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace Avanade.DIO.BookStore.Application.AutoMapperConfigs.Profiles.BookPublisher
{
    [ExcludeFromCodeCoverage]
    public class BookPublisherProfile : Profile
    {
        public BookPublisherProfile()
        {
            CreateMap<Dtos.BookPublisher.BookPublisherDto, Domain.Aggregates.BookPublisher.Entities.BookPublisher>()
            .ConstructUsing((ctor, res) =>
             {
                 return new Domain.Aggregates.BookPublisher.Entities.BookPublisher(
                 ctor.Nome);
             });

            CreateMap<Domain.Aggregates.BookPublisher.Entities.BookPublisher, Dtos.BookPublisher.BookPublisherDto>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Errors, opt => opt.MapFrom(src => src.Erros));
        }
    }
}