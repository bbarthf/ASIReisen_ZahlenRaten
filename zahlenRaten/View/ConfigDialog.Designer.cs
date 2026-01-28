namespace zahlenRaten.View;

partial class ConfigDialog
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitle;
    private Label lblPlayerName;
    private TextBox txtPlayerName;
    private Label lblDifficulty;
    private ComboBox cboDifficulty;
    private Button btnOk;
    private Button btnCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblPlayerName = new Label();
        txtPlayerName = new TextBox();
        lblDifficulty = new Label();
        cboDifficulty = new ComboBox();
        btnOk = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.Location = new Point(24, 18);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(201, 32);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "welcome to the game";
        // 
        // lblPlayerName
        // 
        lblPlayerName.AutoSize = true;
        lblPlayerName.Location = new Point(24, 66);
        lblPlayerName.Name = "lblPlayerName";
        lblPlayerName.Size = new Size(108, 25);
        lblPlayerName.TabIndex = 1;
        lblPlayerName.Text = "Player name";
        // 
        // txtPlayerName
        // 
        txtPlayerName.Location = new Point(24, 94);
        txtPlayerName.Name = "txtPlayerName";
        txtPlayerName.Size = new Size(328, 31);
        txtPlayerName.TabIndex = 2;
        txtPlayerName.TextChanged += txtPlayerName_TextChanged;
        // 
        // lblDifficulty
        // 
        lblDifficulty.AutoSize = true;
        lblDifficulty.Location = new Point(24, 140);
        lblDifficulty.Name = "lblDifficulty";
        lblDifficulty.Size = new Size(82, 25);
        lblDifficulty.TabIndex = 3;
        lblDifficulty.Text = "Difficulty";
        // 
        // cboDifficulty
        // 
        cboDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
        cboDifficulty.FormattingEnabled = true;
        cboDifficulty.Location = new Point(24, 168);
        cboDifficulty.Name = "cboDifficulty";
        cboDifficulty.Size = new Size(328, 33);
        cboDifficulty.TabIndex = 4;
        // 
        // btnOk
        // 
        btnOk.Enabled = false;
        btnOk.Location = new Point(176, 222);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(85, 33);
        btnOk.TabIndex = 5;
        btnOk.Text = "OK";
        btnOk.UseVisualStyleBackColor = true;
        btnOk.Click += btnOk_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(267, 222);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(85, 33);
        btnCancel.TabIndex = 6;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // ConfigDialog
        // 
        AcceptButton = btnOk;
        CancelButton = btnCancel;
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(378, 281);
        Controls.Add(btnCancel);
        Controls.Add(btnOk);
        Controls.Add(cboDifficulty);
        Controls.Add(lblDifficulty);
        Controls.Add(txtPlayerName);
        Controls.Add(lblPlayerName);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ConfigDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "welcome to the game";
        ResumeLayout(false);
        PerformLayout();
    }
}
