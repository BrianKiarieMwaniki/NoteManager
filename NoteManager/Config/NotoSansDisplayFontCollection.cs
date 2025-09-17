using Avalonia.Media.Fonts;
using System;

namespace NoteManager.Config;

public sealed class NotoSansDisplayFontCollection : EmbeddedFontCollection
{
    public NotoSansDisplayFontCollection() : base(
        new Uri("fonts:NotoSansDisplay", UriKind.Absolute),
        new Uri("avares://NoteManager/Assets/Fonts", UriKind.Absolute))
    {
            
    }
}
