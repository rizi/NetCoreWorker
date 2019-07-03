using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Unity;
using Unity.Microsoft.DependencyInjection;

namespace CoreWorker
{
    public class Program
    {
        #region Public Methods

        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IUnityContainer container = SetupUnity();

            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                                   {
                                       services.AddHostedService<Worker>();
                                   })
                .UseServiceProviderFactory<IUnityContainer>(new ServiceProviderFactory(container));
        }

        #endregion

        #region Private Methods

        private static IUnityContainer SetupUnity()
        {
            IUnityContainer container = new UnityContainer();

            //todo add registrations here

            return container;
        }

        #endregion
    }
}