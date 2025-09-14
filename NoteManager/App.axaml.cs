using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using NoteManager.ApplicationBase.Views;
using NoteManager.ViewModels;
using NoteManager.Views;
using Prism.DryIoc;
using Prism.Ioc;
using System;
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

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    #endregion Public Methods

    #region Protected Methods   
    protected override AvaloniaObject CreateShell()
    {
        _splashWindow = SplashWindow.Instance;

        Dispatcher.UIThread.Invoke(new Action(() => { _splashWindow.Show(); }));

        var t = Task.Run(async delegate
        {
            await Task.Delay(2000);

            return;
        });
        t.Wait();

        _splashWindow.Close();

        var mainWindow = Container.Resolve<MainWindow>();
        return mainWindow;
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // View - Generic
        containerRegistry.Register<MainWindow>();
    }
    #endregion Protected Methods   
}