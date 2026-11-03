namespace KeyEventLogger;

public enum KeyEventKind { KeyDown, KeyUp }

/// <summary>Formda yakalanan tek bir tuş olayı.</summary>
public sealed record KeyEventRecord(DateTime Time, KeyEventKind Kind, Keys Key, Keys Modifiers)
{
    public override string ToString()
    {
        string line = $"{Time:yyyy-MM-dd HH:mm:ss.fff} | {Kind,-7} | {Key}";
        return Modifiers == Keys.None ? line : $"{line} | {Modifiers}";
    }
}
