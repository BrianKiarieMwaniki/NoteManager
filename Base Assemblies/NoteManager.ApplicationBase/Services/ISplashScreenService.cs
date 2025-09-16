
namespace NoteManager.ApplicationBase.Services;

public interface ISplashScreenService
{
    event Action OnSplashClosed;

    Task ShowSplashAsync();
}