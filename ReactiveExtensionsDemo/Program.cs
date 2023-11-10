namespace ReactiveExtensionsDemo
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using static System.Formats.Asn1.AsnWriter;

    internal class Program
    {
        static void Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddSingleton<TemperatureService>();

            IHost host = builder.Build();


            using var scope = host.Services.CreateScope();
            var tempService = scope.ServiceProvider.GetRequiredService<TemperatureService>();

            tempService.TemperatureObservable.Subscribe(x =>
            {
                Console.WriteLine($"The Temperature Is Now {x}C");
            });

            host.Run();
        }
    }
}