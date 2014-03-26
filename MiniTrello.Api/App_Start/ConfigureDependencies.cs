using Autofac;
using AutoMapper;
using MiniTrello.Win8Phone.Controllers.AccountControllerHelpers;
using MiniTrello.Win8Phone.Models;
using MiniTrello.Data;
using MiniTrello.Domain.Services;
using MiniTrello.Infrastructure;

namespace MiniTrello.Win8Phone
{
    public class ConfigureDependencies : IBootstrapperTask
    {
        readonly ContainerBuilder _containerBuilder;

        public ConfigureDependencies(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;
        }

        public void Run()
        {
            _containerBuilder.Register(c => Mapper.Engine).As<IMappingEngine>();
            _containerBuilder.RegisterType<ReadOnlyRepository>().As<IReadOnlyRepository>();
            _containerBuilder.RegisterType<WriteOnlyRepository>().As<IWriteOnlyRepository>();
            _containerBuilder.RegisterType<RegisterValidator>().As<IRegisterValidator<AccountRegisterModel>>();
        }
    }
}