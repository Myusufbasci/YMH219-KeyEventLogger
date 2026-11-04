namespace KeyEventLogger;

public enum KeyEventKind { KeyDown, KeyUp }

/// <summary>Formda yakalanan tek bir tuş olayı.</summary>
public sealed record KeyEventRecord(DateTime Time, KeyEventKind Kind, Keys Key, Keys Modifiers, char? Character = null)
{
    /// <summary>Boşluk ve kontrol karakterleri (Ctrl+A gibi) yazı değildir; onlarda tuş adı gösterilir.</summary>
    public bool HasVisibleCharacter => Character is char c && !char.IsControl(c) && !char.IsWhiteSpace(c);

    /// <summary>Tuşun ekranda okunacak adı. Windows adları (ShiftKey, Menu, D1) kullanıcıya anlamsız gelir.</summary>
    public static string NameOf(Keys key) => key switch
    {
        Keys.ShiftKey => "Shift",
        Keys.ControlKey => "Ctrl",
        Keys.Menu => "Alt",
        >= Keys.D0 and <= Keys.D9 => ((int)(key - Keys.D0)).ToString(),
        _ => key.ToString(),
    };

    public string KeyName => HasVisibleCharacter ? Character.ToString()! : NameOf(Key);

    public string ModifierText => Modifiers == Keys.None
        ? ""
        : Modifiers.ToString().Replace("Control", "Ctrl").Replace(", ", " + ");

    /// <summary>Son tuş alanındaki metin. Kendisi değiştirici olan tuşta değiştirici tekrar yazılmaz.</summary>
    public string DisplayText => HasVisibleCharacter || Modifiers == Keys.None || Key is Keys.ShiftKey or Keys.ControlKey or Keys.Menu
        ? KeyName
        : $"{ModifierText} + {KeyName}";

    public override string ToString()
    {
        string line = $"{Time:yyyy-MM-dd HH:mm:ss.fff} | {Kind,-7} | {Key}";
        if (Modifiers != Keys.None) line += $" | {Modifiers}";
        return HasVisibleCharacter ? $"{line} | '{Character}'" : line;
    }
}
