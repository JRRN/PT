using AutoMapper;

namespace Domain.Logic.Configuration
{
    public class AutomapperDomainProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Repository.Model.Polices, Model.Polices>();
            CreateMap<Model.Polices, Repository.Model.Polices>();

            CreateMap<Repository.Model.Clients, Model.Client>();
            CreateMap<Model.Client, Repository.Model.Clients>();
        }
    }
}