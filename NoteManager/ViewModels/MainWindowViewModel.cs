using ReactiveUI;

namespace NoteManager.ViewModels;

public class MainWindowViewModel : ReactiveObject
{
    private string _title = "Note Manager";
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

}
