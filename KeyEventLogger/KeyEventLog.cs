namespace KeyEventLogger;

/// <summary>Kayıt durumunu ve yakalanan olayları tutar. Yalnızca formun ilettiği olayları bilir.</summary>
public sealed class KeyEventLog
{
    private readonly List<KeyEventRecord> _records = new();

    public IReadOnlyList<KeyEventRecord> Records => _records;
    public bool IsRecording { get; private set; }

    public void Start() => IsRecording = true;

    public void Stop() => IsRecording = false;

    public void Clear() => _records.Clear();

    /// <summary>Kayıt açıksa olayı ekler ve döndürür, kapalıysa null döndürür.</summary>
    public KeyEventRecord? Add(KeyEventKind kind, Keys key, Keys modifiers, DateTime time)
    {
        if (!IsRecording) return null;
        var record = new KeyEventRecord(time, kind, key, modifiers);
        _records.Add(record);
        return record;
    }

    public void SaveToFile(string path)
    {
        using var writer = new StreamWriter(path);
        foreach (KeyEventRecord record in _records)
            writer.WriteLine(record);
    }
}
