using Avalonia;
using NoteManager.Config;

namespace NoteManager;

public static class NoteManagerExtensions
{
    public static AppBuilder WithNotoSansDisplayFont(this AppBuilder app)
    {
        app.ConfigureFonts(fontManager => 
        {
            fontManager.AddFontCollection(new NotoSansDisplayFontCollection());
        });

        return app;
    }
}
