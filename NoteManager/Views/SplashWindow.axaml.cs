using Avalonia.Controls;
using NoteManager.ApplicationBase.Views;

namespace NoteManager.Views;

public partial class SplashWindow : Window, ISplashWindow
{
    private static ISplashWindow _instance = new SplashWindow();

    public SplashWindow()
    {
        InitializeComponent();
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
}