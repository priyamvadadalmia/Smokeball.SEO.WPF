using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmokeBall.SEO.Business;
using SmokeBall.SEO.Service;
using System.Windows;

namespace Smokeball.SEO.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Microsoft.Extensions.DependencyInjection provides inbuilt DI
        private readonly ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>()
                       .AddLogging(configure => configure.AddConsole())//Used for Logging 
                       .AddScoped<ISEResult, SEResult>() //Business Layer service
                       .AddScoped<IHttpWebClient, HttpWebClient>();//Service Layer to get data from external url
        }
        /// <summary>
        /// On Application start we load the Main Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
