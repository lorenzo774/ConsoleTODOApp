using Autofac;
using ConsoleTODOApp.Config;

namespace ConsoleTODOApp;

public static class Program
{
    private static void Main(string[] args)
    {
        /*
         * CONFIGURE CONSOLE AND AUTOFAC CONTAINER FOR DI
         */
        ConsoleConfig.Configure();
        var container = ContainerConfig.Configure();
        using (var scope = container.BeginLifetimeScope())
        {
            var app = scope.Resolve<IApplication>();
            app.Run();
        }
    }
}