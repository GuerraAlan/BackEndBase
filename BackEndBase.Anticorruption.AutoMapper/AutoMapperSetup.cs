using AutoMapper;

namespace BackEndBase.Anticorruption.AutoMapper
{
    public class AutoMapperSetup
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new(autoMapperConfig =>
            {
                autoMapperConfig.AddProfile(new ViewModelToCommandMappingProfile());
                autoMapperConfig.AddProfile(new CommandToDomainMappingProfile());
            });
        }
    }
}