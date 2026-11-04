namespace KeyEventLogger;

public enum KeyEventKind { KeyDown, KeyUp }

/// <summary>Formda yakalanan tek bir tuş olayı.</summary>
public sealed record KeyEventRecord(DateTime Time, KeyEventKind Kind, Keys Key, Keys Modifiers)
{
    /// <summary>Tuşun ekranda okunacak adı. Windows adları (ShiftKey, Menu, D1) kullanıcıya anlamsız gelir.</summary>
    public static string NameOf(Keys key) => key switch
    {
        Keys.ShiftKey => "Shift",
        Keys.ControlKey => "Ctrl",
        Keys.Menu => "Alt",
        >= Keys.D0 and <= Keys.D9 => ((int)(key - Keys.D0)).ToString(),
        _ => key.ToString(),
    };

    public string KeyName => NameOf(Key);

    public string ModifierText => Modifiers == Keys.None
        ? ""
        : Modifiers.ToString().Replace("Control", "Ctrl").Replace(", ", " + ");

    /// <summary>Son tuş alanındaki metin. Kendisi değiştirici olan tuşta değiştirici tekrar yazılmaz.</summary>
    public string DisplayText => Modifiers == Keys.None || Key is Keys.ShiftKey or Keys.ControlKey or Keys.Menu
        ? KeyName
        : $"{ModifierText} + {KeyName}";

    public override string ToString()
    {
        string line = $"{Time:yyyy-MM-dd HH:mm:ss.fff} | {Kind,-7} | {Key}";
        return Modifiers == Keys.None ? line : $"{line} | {Modifiers}";
    }
}
