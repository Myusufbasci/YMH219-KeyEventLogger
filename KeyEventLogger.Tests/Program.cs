// Kayıt mantığının küçük öz denetimi: dotnet run --project KeyEventLogger.Tests
using KeyEventLogger;

static void Check(bool condition, string name)
{
    Console.WriteLine((condition ? "ok   " : "FAIL ") + name);
    if (!condition) Environment.Exit(1);
}

var time = new DateTime(2026, 11, 3, 21, 50, 1, 123);
var log = new KeyEventLog();

Check(log.Add(KeyEventKind.KeyDown, Keys.A, Keys.None, time) == null && log.Records.Count == 0, "kayıt kapalıyken olay eklenmez");

log.Start();
log.Add(KeyEventKind.KeyDown, Keys.A, Keys.Shift, time);
log.Add(KeyEventKind.KeyUp, Keys.A, Keys.None, time);
Check(log.Records.Count == 2, "kayıt açıkken olaylar eklenir");
Check(log.Records[0].ToString() == "2026-11-03 21:50:01.123 | KeyDown | A | Shift", "satır biçimi: " + log.Records[0]);
Check(log.Records[1].ToString() == "2026-11-03 21:50:01.123 | KeyUp   | A", "satır biçimi: " + log.Records[1]);

log.Stop();
log.Add(KeyEventKind.KeyDown, Keys.B, Keys.None, time);
Check(log.Records.Count == 2, "durdurulunca olay eklenmez");

string path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + ".txt");
try
{
    log.SaveToFile(path);
    string[] lines = File.ReadAllLines(path);
    Check(lines.Length == 2 && lines[0] == log.Records[0].ToString(), "kayıtlar dosyaya yazılır");
}
finally
{
    File.Delete(path);
}

log.Clear();
Check(log.Records.Count == 0, "temizle kayıtları siler");
