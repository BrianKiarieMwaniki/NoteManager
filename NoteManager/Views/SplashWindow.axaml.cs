using Avalonia.Controls;
using NoteManager.ApplicationBase.Views;
using NoteManager.ViewModels;

namespace NoteManager.Views;

public partial class SplashWindow : Window, ISplashWindow
{
    #region Private Fields
    private static ISplashWindow _instance = new SplashWindow();
    private readonly SplashWindowViewModel _splashWindowViewModel;
    #endregion Private Fields

    public SplashWindow()
    {
        InitializeComponent();

        _splashWindowViewModel = new SplashWindowViewModel();
        DataContext = _splashWindowViewModel;
    }

    #region Public Properties

    public static ISplashWindow Instance
    {
        get
        {
            return _instance;
        }
    }

    #endregion Public Properties

    #region Public Methods
    public void UpdateProgress(int  progress)
    {
        _splashWindowViewModel.UpdateProgress(progress);
    }

    #endregion Public Methods
}