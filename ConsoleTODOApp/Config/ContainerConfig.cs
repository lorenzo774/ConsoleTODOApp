using Autofac;
using ConsoleTODOApp.Input;
using ConsoleTODOApp.Systems;
using ConsoleTODOApp.Systems.Commands;

namespace ConsoleTODOApp.Config;

public static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<Application>().As<IApplication>();
        builder.RegisterType<Message>().As<IMessage>();
        builder.RegisterType<InputReader>().As<IInputReader>();
        builder.RegisterType<CommandExtractor>().As<ICommandExtractor>();
        builder.RegisterType<ArgumentsExtractor>().As<IArgumentsExtractor>();
        builder.RegisterType<CommandManager>().As<ICommandManager>();
        builder.RegisterType<IOLists>().As<IIOLists>();
        builder.RegisterType<ListExplorer>().As<IListExplorer>();
        // Commands
        builder.RegisterType<GetListCommand>().As<IGetListCommand>();
        builder.RegisterType<HelpCommand>().As<IHelpCommand>();
        builder.RegisterType<NewListCommand>().As<INewListCommand>();
        builder.RegisterType<RemoveListCommand>().As<IRemoveListCommand>();

        return builder.Build();
    }
}