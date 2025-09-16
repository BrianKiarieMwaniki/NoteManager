using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace NoteManager.UI.Controls;

public partial class TitleBar : UserControl
{
    #region Private Fields
    private readonly Button? _closeButton;
    private readonly Button? _maximizeButton;
    private readonly Button? _minimizeButton;
    #endregion Private Fields

    #region Constructors
    public TitleBar()
    {
        InitializeComponent();

        _closeButton = this.FindControl<Button>("CloseBtn");
        _maximizeButton = this.FindControl<Button>("MaximizeBtn");
        _minimizeButton = this.FindControl<Button>("MinimizeBtn");

        if (_closeButton != null)
            _closeButton.Click += HandleCloseBtnClick;

        if (_maximizeButton != null)
            _maximizeButton.Click += HandleMaximizeBtnClick;
        
        if (_minimizeButton != null)
            _minimizeButton.Click += HandleMinimizeBtnClick;
    }
   
    #endregion Constructors

    #region Public Fields

    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<TitleBar, string>(nameof(Title));

    #endregion Public Fields        

    #region Public Properties
    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion Public Properties

    #region Private Methods
    private void HandleCloseBtnClick(object? sender, RoutedEventArgs e)
    {
        if (this.VisualRoot == null)
            return;

        Window hostWindow = (Window)this.VisualRoot;
        hostWindow.Close();
    }

    private void HandleMaximizeBtnClick(object? sender, RoutedEventArgs e)
    {
        if (this.VisualRoot == null)
            return;

        Window hostWindow = (Window)this.VisualRoot;

        if (hostWindow.WindowState == WindowState.Normal)
        {
            hostWindow.WindowState = WindowState.Maximized;
        }
        else
        {
            hostWindow.WindowState = WindowState.Normal;
        }
    }

    private void HandleMinimizeBtnClick(object? sender, RoutedEventArgs e)
    {
        if (this.VisualRoot == null)
            return;

        Window hostWindow = (Window)this.VisualRoot;
        hostWindow.WindowState = WindowState.Minimized;
    }

    private void TitleStr_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            // Find the parent window
            var window = this.VisualRoot as Window;
            window?.BeginMoveDrag(e);
        }
    }

    #endregion Private Methods
}