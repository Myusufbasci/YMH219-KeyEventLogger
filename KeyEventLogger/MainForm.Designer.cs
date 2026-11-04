namespace KeyEventLogger;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlHeader;
    private Label lblIndicator;
    private Button btnStart;
    private Button btnStop;
    private Button btnClear;
    private Button btnSave;
    private ListView lvEvents;
    private ColumnHeader colTime;
    private ColumnHeader colKind;
    private ColumnHeader colKey;
    private ColumnHeader colModifiers;
    private Panel pnlStats;
    private Label lblLastKeyTitle;
    private Label lblLastKey;
    private Label lblCount;
    private Label lblTopTitle;
    private Label lblTop;
    private Panel pnlTyped;
    private Label lblTypedTitle;
    private Label lblTyped;
    private Panel pnlFooter;
    private Label lblMessage;
    private Label lblScope;
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
        pnlHeader = new Panel();
        lblIndicator = new Label();
        btnStart = new Button();
        btnStop = new Button();
        btnClear = new Button();
        btnSave = new Button();
        lvEvents = new ListView();
        colTime = new ColumnHeader();
        colKind = new ColumnHeader();
        colKey = new ColumnHeader();
        colModifiers = new ColumnHeader();
        pnlStats = new Panel();
        lblLastKeyTitle = new Label();
        lblLastKey = new Label();
        lblCount = new Label();
        lblTopTitle = new Label();
        lblTop = new Label();
        pnlTyped = new Panel();
        lblTypedTitle = new Label();
        lblTyped = new Label();
        pnlFooter = new Panel();
        lblMessage = new Label();
        lblScope = new Label();
        saveDialog = new SaveFileDialog();
        pnlHeader.SuspendLayout();
        pnlStats.SuspendLayout();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        //
        // pnlHeader
        //
        pnlHeader.BackColor = Color.FromArgb(38, 50, 56);
        pnlHeader.Controls.Add(lblIndicator);
        pnlHeader.Controls.Add(btnStart);
        pnlHeader.Controls.Add(btnStop);
        pnlHeader.Controls.Add(btnClear);
        pnlHeader.Controls.Add(btnSave);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(780, 60);
        //
        // lblIndicator
        //
        lblIndicator.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblIndicator.ForeColor = Color.White;
        lblIndicator.Location = new Point(12, 12);
        lblIndicator.Name = "lblIndicator";
        lblIndicator.Size = new Size(170, 36);
        lblIndicator.TextAlign = ContentAlignment.MiddleCenter;
        //
        // btnStart
        //
        btnStart.FlatAppearance.BorderSize = 0;
        btnStart.FlatStyle = FlatStyle.Flat;
        btnStart.ForeColor = Color.White;
        btnStart.Location = new Point(196, 12);
        btnStart.Name = "btnStart";
        btnStart.Size = new Size(90, 36);
        btnStart.Text = "&Başlat";
        btnStart.UseVisualStyleBackColor = false;
        btnStart.Click += BtnStart_Click;
        //
        // btnStop
        //
        btnStop.FlatAppearance.BorderSize = 0;
        btnStop.FlatStyle = FlatStyle.Flat;
        btnStop.ForeColor = Color.White;
        btnStop.Location = new Point(292, 12);
        btnStop.Name = "btnStop";
        btnStop.Size = new Size(90, 36);
        btnStop.Text = "&Durdur";
        btnStop.UseVisualStyleBackColor = false;
        btnStop.Click += BtnStop_Click;
        //
        // btnClear
        //
        btnClear.BackColor = Color.FromArgb(69, 90, 100);
        btnClear.FlatAppearance.BorderSize = 0;
        btnClear.FlatStyle = FlatStyle.Flat;
        btnClear.ForeColor = Color.White;
        btnClear.Location = new Point(388, 12);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(90, 36);
        btnClear.Text = "&Temizle";
        btnClear.UseVisualStyleBackColor = false;
        btnClear.Click += BtnClear_Click;
        //
        // btnSave
        //
        btnSave.BackColor = Color.FromArgb(69, 90, 100);
        btnSave.FlatAppearance.BorderSize = 0;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(484, 12);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(130, 36);
        btnSave.Text = "Dosyaya &Kaydet";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += BtnSave_Click;
        //
        // lvEvents
        //
        lvEvents.BorderStyle = BorderStyle.None;
        lvEvents.Columns.AddRange(new ColumnHeader[] { colTime, colKind, colKey, colModifiers });
        lvEvents.Dock = DockStyle.Fill;
        lvEvents.FullRowSelect = true;
        lvEvents.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        lvEvents.Location = new Point(0, 60);
        lvEvents.MultiSelect = false;
        lvEvents.Name = "lvEvents";
        lvEvents.Size = new Size(560, 390);
        lvEvents.View = View.Details;
        //
        // colTime
        //
        colTime.Text = "Tarih ve saat";
        colTime.Width = 180;
        //
        // colKind
        //
        colKind.Text = "Olay";
        colKind.Width = 80;
        //
        // colKey
        //
        colKey.Text = "Tuş";
        colKey.Width = 130;
        //
        // colModifiers
        //
        colModifiers.Text = "Birlikte basılan";
        colModifiers.Width = 145;
        //
        // pnlStats
        //
        pnlStats.BackColor = Color.FromArgb(236, 239, 241);
        pnlStats.Controls.Add(lblLastKeyTitle);
        pnlStats.Controls.Add(lblLastKey);
        pnlStats.Controls.Add(lblCount);
        pnlStats.Controls.Add(lblTopTitle);
        pnlStats.Controls.Add(lblTop);
        pnlStats.Dock = DockStyle.Right;
        pnlStats.Location = new Point(560, 60);
        pnlStats.Name = "pnlStats";
        pnlStats.Size = new Size(220, 390);
        //
        // lblLastKeyTitle
        //
        lblLastKeyTitle.AutoSize = true;
        lblLastKeyTitle.Location = new Point(14, 14);
        lblLastKeyTitle.Name = "lblLastKeyTitle";
        lblLastKeyTitle.Text = "Son tuş";
        //
        // lblLastKey
        //
        lblLastKey.AutoEllipsis = true;
        lblLastKey.BackColor = Color.White;
        lblLastKey.BorderStyle = BorderStyle.FixedSingle;
        lblLastKey.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblLastKey.Location = new Point(14, 38);
        lblLastKey.Name = "lblLastKey";
        lblLastKey.Size = new Size(192, 72);
        lblLastKey.Text = "-";
        lblLastKey.TextAlign = ContentAlignment.MiddleCenter;
        //
        // lblCount
        //
        lblCount.AutoSize = true;
        lblCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCount.Location = new Point(14, 122);
        lblCount.Name = "lblCount";
        //
        // lblTopTitle
        //
        lblTopTitle.AutoSize = true;
        lblTopTitle.Location = new Point(14, 156);
        lblTopTitle.Name = "lblTopTitle";
        lblTopTitle.Text = "En sık basılanlar";
        //
        // lblTop
        //
        lblTop.Font = new Font("Segoe UI", 10F);
        lblTop.Location = new Point(14, 178);
        lblTop.Name = "lblTop";
        lblTop.Size = new Size(192, 130);
        //
        // pnlTyped
        //
        pnlTyped.BackColor = Color.FromArgb(245, 247, 248);
        pnlTyped.Controls.Add(lblTyped);
        pnlTyped.Controls.Add(lblTypedTitle);
        pnlTyped.Dock = DockStyle.Bottom;
        pnlTyped.Name = "pnlTyped";
        pnlTyped.Padding = new Padding(10, 6, 10, 6);
        pnlTyped.Size = new Size(560, 96);
        //
        // lblTypedTitle
        //
        lblTypedTitle.Dock = DockStyle.Top;
        lblTypedTitle.ForeColor = Color.FromArgb(84, 96, 102);
        lblTypedTitle.Name = "lblTypedTitle";
        lblTypedTitle.Size = new Size(540, 20);
        lblTypedTitle.Text = "Yazılan metin";
        //
        // lblTyped
        //
        lblTyped.AutoEllipsis = true;
        lblTyped.Dock = DockStyle.Fill;
        lblTyped.Font = new Font("Segoe UI", 11F);
        lblTyped.Name = "lblTyped";
        //
        // pnlFooter
        //
        pnlFooter.BackColor = Color.FromArgb(236, 239, 241);
        pnlFooter.Controls.Add(lblMessage);
        pnlFooter.Controls.Add(lblScope);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 450);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Padding = new Padding(10, 0, 10, 0);
        pnlFooter.Size = new Size(780, 30);
        //
        // lblMessage
        //
        lblMessage.AutoEllipsis = true;
        lblMessage.Dock = DockStyle.Fill;
        lblMessage.Name = "lblMessage";
        lblMessage.TextAlign = ContentAlignment.MiddleLeft;
        //
        // lblScope
        //
        lblScope.Dock = DockStyle.Right;
        lblScope.ForeColor = Color.FromArgb(84, 96, 102);
        lblScope.Name = "lblScope";
        lblScope.Size = new Size(280, 30);
        lblScope.Text = "Yalnızca bu pencere odaktayken tuş görülür.";
        lblScope.TextAlign = ContentAlignment.MiddleRight;
        //
        // saveDialog
        //
        saveDialog.DefaultExt = "txt";
        saveDialog.FileName = "tus-kayitlari.txt";
        saveDialog.Filter = "Metin dosyası (*.txt)|*.txt";
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.White;
        ClientSize = new Size(780, 520);
        Controls.Add(lvEvents);
        Controls.Add(pnlTyped);
        Controls.Add(pnlStats);
        Controls.Add(pnlFooter);
        Controls.Add(pnlHeader);
        KeyPreview = true;
        MinimumSize = new Size(760, 400);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Key Event Logger - YMH219";
        KeyDown += MainForm_KeyDown;
        KeyPress += MainForm_KeyPress;
        KeyUp += MainForm_KeyUp;
        pnlHeader.ResumeLayout(false);
        pnlStats.ResumeLayout(false);
        pnlStats.PerformLayout();
        pnlTyped.ResumeLayout(false);
        pnlFooter.ResumeLayout(false);
        ResumeLayout(false);
    }
}
