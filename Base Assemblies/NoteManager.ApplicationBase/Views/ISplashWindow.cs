namespace NoteManager.ApplicationBase.Views;

public interface ISplashWindow
{
    #region Public Properties

    /// <summary>
    /// Flag indicating whether the Splash is visible
    /// </summary>
    bool IsVisible { get; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Close (hide) the splash window
    /// </summary>
    void Close();

    /// <summary>
    /// Show the splash window
    /// </summary>
    void Show();

    #endregion Public Methods
}
