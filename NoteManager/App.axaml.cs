using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using NoteManager.ApplicationBase.Services;
using NoteManager.ApplicationBase.Views;
using NoteManager.ViewModels;
using NoteManager.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System.Threading.Tasks;

namespace NoteManager;

public partial class App : PrismApplication
{
    #region Private Fields
    private ISplashWindow _splashWindow = default!;
    #endregion Private Fields

    #region Public Methods
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        base.Initialize();
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            await ShowSplashAsync();

            desktop.MainWindow = new MainWindow
            {
                DataContext = Container.Resolve<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    #endregion Public Methods

    #region Protected Methods   
    protected override AvaloniaObject CreateShell()
    {
        var mainWindow = Container.Resolve<MainWindow>();

        return mainWindow;
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // View - Generic
        containerRegistry.Register<MainWindow>();
        containerRegistry.Register<MainWindowViewModel>();

        containerRegistry.Register<ISplashWindow, SplashWindow>();
        containerRegistry.RegisterSingleton<ISplashScreenService, SplashScreenService>();
    }


    #endregion Protected Methods   

    #region Private Methods
    private async Task ShowSplashAsync()
    {
        var splashScreenService = Container.Resolve<ISplashScreenService>();

        await splashScreenService.ShowSplashAsync();
    }

    #endregion Private Methods   
    
}