namespace KeyEventLogger;

/// <summary>Kayıt durumunu ve yakalanan olayları tutar. Yalnızca formun ilettiği olayları bilir.</summary>
public sealed class KeyEventLog
{
    private readonly List<KeyEventRecord> _records = new();

    public IReadOnlyList<KeyEventRecord> Records => _records;
    public bool IsRecording { get; private set; }

    /// <summary>Toplam tuş basışı. KeyUp sayılmaz, aksi halde her basış iki kez sayılırdı.</summary>
    public int PressCount => _records.Count(r => r.Kind == KeyEventKind.KeyDown);

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

    /// <summary>En sık basılan tuşlar; eşitlikte önce basılan önde gelir.</summary>
    public IReadOnlyList<(string Key, int Count)> TopKeys(int count) => _records
        .Where(r => r.Kind == KeyEventKind.KeyDown)
        .GroupBy(r => r.KeyName)
        .OrderByDescending(g => g.Count())
        .Take(count)
        .Select(g => (g.Key, g.Count()))
        .ToList();

    public void SaveToFile(string path)
    {
        using var writer = new StreamWriter(path);
        foreach (KeyEventRecord record in _records)
            writer.WriteLine(record);
    }
}
