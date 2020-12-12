using AutoMapper;
using BackEndBase.Domain.Commands;
using BackEndBase.Domain.Entities;

namespace BackEndBase.Anticorruption.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}