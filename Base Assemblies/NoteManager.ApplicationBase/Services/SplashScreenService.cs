using NoteManager.ApplicationBase.Views;

namespace NoteManager.ApplicationBase.Services;

public class SplashScreenService : ISplashScreenService
{
    #region Private Fields
    private readonly ISplashWindow _splashWindow;
    #endregion Private Fields

    public SplashScreenService(ISplashWindow splashWindow)
    {
        _splashWindow = splashWindow;
    }

    public event Action OnSplashClosed = default!;

    public async Task ShowSplashAsync()
    {
        _splashWindow.Show();

        for (int i = 0; i <= 100; i += 20)
        {
            _splashWindow.UpdateProgress(i);
            await Task.Delay(300); // simulate work
        }

        _splashWindow.Close();

        // Notify subscribers
        OnSplashClosed?.Invoke();
    }
}
