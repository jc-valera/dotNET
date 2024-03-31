using DependencyInjectionWFA.BLL;
using DependencyInjectionWFA.Services;
using DependencyInjectionWFA.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DependencyInjectionWFA
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Main());

            /***************/
            
            ApplicationConfiguration.Initialize();
            
            var host = CreateHostBuilder().Build();
            var serviceProvider = host.Services;
            var main = serviceProvider.GetRequiredService<Main>();
            
            main.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(main);
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                //services.AddTransient<IBlobStorageService, BlobStorageService>();
                //services.AddTransient<IErrorMessageLog, ErrorMessageLog>();
                //services.AddTransient<IFileMigrationService, FileMigrationService>();
                //services.AddTransient<IAttachmentDataAccess, AttachmentDataAccess>();
                services.AddTransient<IMessageServiceBLL, MessageServiceBLL>();

                services.AddTransient<Main>();
            });

        }
    }
}