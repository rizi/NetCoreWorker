using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            UnityContainer container = new UnityContainer();

            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                                   {
                                       services.AddHostedService<Worker>();
                                   })
                .UseServiceProviderFactory<IUnityContainer>(new ServiceProviderFactory(container));
        }

        #endregion

        #region Private Methods

        private static void SetupUnity(IUnityContainer container)
        {
            container.RegisterType(typeof(ILogger<>), typeof(Logger<>));
        }

        #endregion
    }
}