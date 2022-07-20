using AutoMapper;
using IAMCandidateTestModels_MarkSeno;

namespace IAMCandidateTestAPI_MarkSeno
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Animal, Animal>();
            CreateMap<Vegetable, Vegetable>();
            CreateMap<Mineral, Mineral>();            
        }
    }
}
