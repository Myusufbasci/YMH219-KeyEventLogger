namespace KeyEventLogger;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Label lblIndicator;
    private Button btnStart;
    private Button btnStop;
    private Button btnClear;
    private Button btnSave;
    private ListBox lstEvents;
    private Label lblCount;
    private Label lblScope;
    private Label lblMessage;
    private SaveFileDialog saveDialog;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblIndicator = new Label();
        btnStart = new Button();
        btnStop = new Button();
        btnClear = new Button();
        btnSave = new Button();
        lstEvents = new ListBox();
        lblCount = new Label();
        lblScope = new Label();
        lblMessage = new Label();
        saveDialog = new SaveFileDialog();
        SuspendLayout();
        //
        // lblIndicator
        //
        lblIndicator.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblIndicator.ForeColor = Color.White;
        lblIndicator.Location = new Point(12, 12);
        lblIndicator.Name = "lblIndicator";
        lblIndicator.Size = new Size(160, 32);
        lblIndicator.TextAlign = ContentAlignment.MiddleCenter;
        //
        // btnStart
        //
        btnStart.Location = new Point(184, 12);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(85, 32);
        btnStart.Text = "&Başlat";
        btnStart.Click += BtnStart_Click;
        //
        // btnStop
        //
        btnStop.Location = new Point(275, 12);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(85, 32);
        btnStop.Text = "&Durdur";
        btnStop.Click += BtnStop_Click;
        //
        // btnClear
        //
        btnClear.Location = new Point(366, 12);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(85, 32);
        btnClear.Text = "&Temizle";
        btnClear.Click += BtnClear_Click;
        //
        // btnSave
        //
        btnSave.Location = new Point(457, 12);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(115, 32);
        btnSave.Text = "Dosyaya &Kaydet";
        btnSave.Click += BtnSave_Click;
        //
        // lstEvents
        //
        lstEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstEvents.Font = new Font("Consolas", 10F);
        lstEvents.IntegralHeight = false;
        lstEvents.ItemHeight = 15;
        lstEvents.Location = new Point(12, 54);
        lstEvents.Name = "lstEvents";
        lstEvents.Size = new Size(560, 300);
        //
        // lblCount
        //
        lblCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblCount.AutoSize = true;
        lblCount.Location = new Point(12, 362);
        lblCount.Name = "lblCount";
        lblCount.Text = "Olay sayısı: 0";
        //
        // lblScope
        //
        lblScope.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblScope.AutoSize = true;
        lblScope.ForeColor = SystemColors.GrayText;
        lblScope.Location = new Point(150, 362);
        lblScope.Name = "lblScope";
        lblScope.Text = "Yalnızca bu pencere odaktayken basılan tuşlar görülür.";
        //
        // lblMessage
        //
        lblMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lblMessage.AutoEllipsis = true;
        lblMessage.Location = new Point(12, 386);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(560, 20);
        //
        // saveDialog
        //
        saveDialog.DefaultExt = "txt";
        saveDialog.FileName = "tus-kayitlari.txt";
        saveDialog.Filter = "Metin dosyası (*.txt)|*.txt";
        //
        // MainForm
        //
        AutoScaleMode = AutoScaleMode.None;
        ClientSize = new Size(584, 414);
        Controls.Add(lblIndicator);
        Controls.Add(btnStart);
        Controls.Add(btnStop);
        Controls.Add(btnClear);
        Controls.Add(btnSave);
        Controls.Add(lstEvents);
        Controls.Add(lblCount);
        Controls.Add(lblScope);
        Controls.Add(lblMessage);
        KeyPreview = true;
        MinimumSize = new Size(600, 300);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Key Event Logger - YMH219";
        KeyDown += MainForm_KeyDown;
        KeyUp += MainForm_KeyUp;
        ResumeLayout(false);
        PerformLayout();
    }
}
