namespace KeyEventLogger;

public partial class MainForm : Form
{
    private readonly KeyEventLog _log = new();

    public MainForm()
    {
        InitializeComponent();
        // Tab ve ok tuşları normalde odak değiştirir; kayıt sırasında KeyDown'a düşsünler.
        PreviewKeyDown += MarkAsInputWhileRecording;
        foreach (Control control in Controls)
            control.PreviewKeyDown += MarkAsInputWhileRecording;
        UpdateRecordingState();
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
        lstEvents.Items.Add(record);
        lstEvents.TopIndex = lstEvents.Items.Count - 1;
        lblCount.Text = $"Olay sayısı: {_log.Records.Count}";
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
        lstEvents.Items.Clear();
        lblCount.Text = "Olay sayısı: 0";
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

    private void UpdateRecordingState()
    {
        bool recording = _log.IsRecording;
        lblIndicator.Text = recording ? "● KAYIT AÇIK" : "○ KAYIT KAPALI";
        lblIndicator.BackColor = recording ? Color.Firebrick : Color.DimGray;
        btnStart.Enabled = !recording;
        btnStop.Enabled = recording;
    }

    private void ShowMessage(string text, bool isError)
    {
        lblMessage.Text = text;
        lblMessage.ForeColor = isError ? Color.Firebrick : SystemColors.ControlText;
    }
}
