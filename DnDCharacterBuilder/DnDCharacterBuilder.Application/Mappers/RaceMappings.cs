using AutoMapper;
using DnDCharacterBuilder.Application.Models;
using DnDCharacterBuilder.Domain.Entities;

namespace DnDCharacterBuilder.Application.Mappers
{
    public class RaceMappings : Profile
    {
        public RaceMappings()
        {
            CreateMap<ApiRace, Race>()
                .ForMember(x => x.AgeInfo, y => y.MapFrom(x => x.Age))
                .ForMember(x => x.SizeInfo, y => y.MapFrom(x => x.Size_Description))
                .ForMember(x => x.AlignmentInfo, y => y.MapFrom(x => x.Alignment));
        }
    }
}
