using AutoMapper;
using BackEndBase.Application.ViewModel.Request.User;
using BackEndBase.Domain.Commands;

namespace BackEndBase.Anticorruption.AutoMapper
{
    public class ViewModelToCommandMappingProfile : Profile
    {
        public ViewModelToCommandMappingProfile()
        {
            CreateMap<RegisterUserViewModel, AddUserCommand>();
        }
    }
}