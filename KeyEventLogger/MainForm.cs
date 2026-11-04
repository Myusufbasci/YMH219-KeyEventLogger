namespace KeyEventLogger;

public partial class MainForm : Form
{
    private const int TopKeyCount = 5;
    private static readonly Color StartColor = Color.FromArgb(46, 125, 50);
    private static readonly Color StopColor = Color.FromArgb(198, 40, 40);
    private static readonly Color InactiveColor = Color.FromArgb(69, 90, 100);
    private static readonly Color KeyUpTextColor = Color.FromArgb(120, 130, 135);

    private readonly KeyEventLog _log = new();

    public MainForm()
    {
        InitializeComponent();
        // Sütun genişlikleri ekran ölçeğiyle kendiliğinden büyümüyor.
        foreach (ColumnHeader column in lvEvents.Columns)
            column.Width = LogicalToDeviceUnits(column.Width);

        // Tab ve ok tuşları normalde odak değiştirir; kayıt sırasında KeyDown'a düşsünler.
        PreviewKeyDown += MarkAsInputWhileRecording;
        HookPreviewKeys(this);
        Activated += (_, _) => lblScope.Text = "Pencere odakta: tuşlar görülüyor.";
        Deactivate += (_, _) => lblScope.Text = "Pencere odakta değil: tuş yakalanmıyor.";
        UpdateRecordingState();
        UpdateStats();
    }

    private void HookPreviewKeys(Control parent)
    {
        foreach (Control control in parent.Controls)
        {
            control.PreviewKeyDown += MarkAsInputWhileRecording;
            HookPreviewKeys(control);
        }
    }

    private void MarkAsInputWhileRecording(object? sender, PreviewKeyDownEventArgs e)
    {
        if (_log.IsRecording && !e.Alt) e.IsInputKey = true;
    }

    private void MainForm_KeyDown(object? sender, KeyEventArgs e)
    {
        if (!RecordKey(KeyEventKind.KeyDown, e)) return;
        // Boşluk ve Enter odaktaki butona basmasın; Alt kısayolları (Alt+D gibi) çalışmaya devam etsin.
        if (!e.Alt) e.SuppressKeyPress = true;
    }

    private void MainForm_KeyUp(object? sender, KeyEventArgs e)
    {
        if (RecordKey(KeyEventKind.KeyUp, e) && !e.Alt) e.Handled = true;
    }

    private bool RecordKey(KeyEventKind kind, KeyEventArgs e)
    {
        KeyEventRecord? record = _log.Add(kind, e.KeyCode, e.Modifiers, DateTime.Now);
        if (record == null) return false;

        var item = new ListViewItem(new[]
        {
            record.Time.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            record.Kind.ToString(),
            record.KeyName,
            record.ModifierText,
        });
        if (kind == KeyEventKind.KeyUp) item.ForeColor = KeyUpTextColor;

        lvEvents.BeginUpdate();
        lvEvents.Items.Add(item);
        item.EnsureVisible();
        lvEvents.EndUpdate();

        if (kind == KeyEventKind.KeyDown)
        {
            lblLastKey.Text = record.DisplayText;
            UpdateStats();
        }
        return true;
    }

    private void BtnStart_Click(object? sender, EventArgs e)
    {
        _log.Start();
        UpdateRecordingState();
    }

    private void BtnStop_Click(object? sender, EventArgs e)
    {
        _log.Stop();
        UpdateRecordingState();
    }

    private void BtnClear_Click(object? sender, EventArgs e)
    {
        _log.Clear();
        lvEvents.Items.Clear();
        lblLastKey.Text = "-";
        UpdateStats();
        ShowMessage("Kayıtlar temizlendi.", isError: false);
    }

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        if (_log.Records.Count == 0)
        {
            ShowMessage("Kaydedilecek olay yok.", isError: true);
            return;
        }
        if (saveDialog.ShowDialog(this) == DialogResult.OK)
            SaveTo(saveDialog.FileName);
    }

    private void SaveTo(string path)
    {
        try
        {
            _log.SaveToFile(path);
            ShowMessage($"{_log.Records.Count} olay kaydedildi: {path}", isError: false);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException or ArgumentException or NotSupportedException)
        {
            ShowMessage($"Dosya kaydedilemedi: {ex.Message}", isError: true);
        }
    }

    private void UpdateStats()
    {
        lblCount.Text = $"Toplam basış: {_log.PressCount}";
        IReadOnlyList<(string Key, int Count)> top = _log.TopKeys(TopKeyCount);
        lblTop.Text = top.Count == 0
            ? "Henüz tuş yok"
            : string.Join(Environment.NewLine, top.Select(t => $"{t.Key}: {t.Count}"));
    }

    private void UpdateRecordingState()
    {
        bool recording = _log.IsRecording;
        lblIndicator.Text = recording ? "● KAYIT AÇIK" : "○ KAYIT KAPALI";
        lblIndicator.BackColor = recording ? StopColor : InactiveColor;
        btnStart.Enabled = !recording;
        btnStart.BackColor = recording ? InactiveColor : StartColor;
        btnStop.Enabled = recording;
        btnStop.BackColor = recording ? StopColor : InactiveColor;
    }

    private void ShowMessage(string text, bool isError)
    {
        lblMessage.Text = text;
        lblMessage.ForeColor = isError ? Color.Firebrick : SystemColors.ControlText;
    }
}
