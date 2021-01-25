using BankPortifolio.Application.Interfaces;
using BankPortifolio.Application.Services;
using BankPortifolio.Domain.Interfaces.Repository;
using BankPortifolio.Domain.Interfaces.Services;
using BankPortifolio.Domain.Services;
using BankPortifolio.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankPortifolio.Infra.IoC
{
    public class DependencyInjector
    {
        public static void Register(IServiceCollection svcCollection)
        {
            //Aplication
            svcCollection.AddScoped(typeof(IAppBase<,>), typeof(ServiceAppBase<,>));
            svcCollection.AddScoped<ITradeApp, TradeApp>();

            //Domain
            svcCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            svcCollection.AddScoped<ITradeService, TradeService>();

            //Repository
            svcCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            svcCollection.AddScoped<ITradeRepository, TradeRepository>();
        }
    }
}
