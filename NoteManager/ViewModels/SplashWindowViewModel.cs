using ReactiveUI;

namespace NoteManager.ViewModels;

public class SplashWindowViewModel : ReactiveObject
{
    #region Private Fields
    private int _progress = 0;
    #endregion Private Fields

    #region Public Properties
    public int Progress
    {
        get => _progress;
        set => this.RaiseAndSetIfChanged(ref _progress, value);
    }
    #endregion Public Properties

    #region Public Methods
    public void UpdateProgress(int value)
    {
        Progress = value;
    }
    #endregion Public Methods
}
