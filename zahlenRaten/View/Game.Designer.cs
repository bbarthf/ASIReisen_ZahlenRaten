namespace zahlenRaten.View;

partial class Game
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtGuess = new TextBox();
        btnGuess = new Button();
        btnRestart = new Button();
        lblFeedback = new Label();
        lblPrompt = new Label();
        lblDifficultyValue = new Label();
        lblDifficulty = new Label();
        lblAttempts = new Label();
        lblTime = new Label();
        lblPlayerName = new Label();
        lblPlayerNameValue = new Label();
        SuspendLayout();
        // 
        // txtGuess
        // 
        txtGuess.Location = new Point(235, 294);
        txtGuess.Name = "txtGuess";
        txtGuess.Size = new Size(120, 31);
        txtGuess.TabIndex = 1;
        txtGuess.TextChanged += txtGuess_TextChanged;
        txtGuess.KeyDown += txtGuess_KeyDown;
        // 
        // btnGuess
        // 
        btnGuess.Enabled = false;
        btnGuess.Location = new Point(177, 438);
        btnGuess.Name = "btnGuess";
        btnGuess.Size = new Size(98, 31);
        btnGuess.TabIndex = 2;
        btnGuess.Text = "Guess";
        btnGuess.UseVisualStyleBackColor = true;
        btnGuess.Click += btnGuess_Click;
        // 
        // btnRestart
        // 
        btnRestart.Location = new Point(322, 438);
        btnRestart.Name = "btnRestart";
        btnRestart.Size = new Size(106, 31);
        btnRestart.TabIndex = 3;
        btnRestart.Text = "Restart";
        btnRestart.UseVisualStyleBackColor = true;
        btnRestart.Click += btnRestart_Click;
        // 
        // lblFeedback
        // 
        lblFeedback.AutoSize = true;
        lblFeedback.Location = new Point(177, 347);
        lblFeedback.Name = "lblFeedback";
        lblFeedback.Size = new Size(0, 25);
        lblFeedback.TabIndex = 4;
        // 
        // lblPrompt
        // 
        lblPrompt.AutoSize = true;
        lblPrompt.Location = new Point(152, 207);
        lblPrompt.Name = "lblPrompt";
        lblPrompt.Size = new Size(310, 25);
        lblPrompt.TabIndex = 0;
        lblPrompt.Text = "Enter a number (1-10) and click Guess";
        // 
        // lblDifficultyValue
        // 
        lblDifficultyValue.BorderStyle = BorderStyle.FixedSingle;
        lblDifficultyValue.Location = new Point(266, 151);
        lblDifficultyValue.Name = "lblDifficultyValue";
        lblDifficultyValue.Size = new Size(168, 33);
        lblDifficultyValue.TabIndex = 7;
        lblDifficultyValue.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblDifficulty
        // 
        lblDifficulty.AutoSize = true;
        lblDifficulty.Location = new Point(152, 154);
        lblDifficulty.Name = "lblDifficulty";
        lblDifficulty.Size = new Size(82, 25);
        lblDifficulty.TabIndex = 6;
        lblDifficulty.Text = "Difficulty";
        // 
        // lblAttempts
        // 
        lblAttempts.AutoSize = true;
        lblAttempts.Location = new Point(177, 410);
        lblAttempts.Name = "lblAttempts";
        lblAttempts.Size = new Size(105, 25);
        lblAttempts.TabIndex = 8;
        lblAttempts.Text = "Attempts: 0";
        // 
        // lblTime
        // 
        lblTime.AutoSize = true;
        lblTime.Location = new Point(322, 410);
        lblTime.Name = "lblTime";
        lblTime.Size = new Size(91, 25);
        lblTime.TabIndex = 9;
        lblTime.Text = "Time: 0.0s";
        // 
        // lblPlayerNameValue
        // 
        lblPlayerNameValue.BorderStyle = BorderStyle.FixedSingle;
        lblPlayerNameValue.Location = new Point(266, 86);
        lblPlayerNameValue.Name = "lblPlayerNameValue";
        lblPlayerNameValue.Size = new Size(180, 31);
        lblPlayerNameValue.TabIndex = 11;
        lblPlayerNameValue.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblPlayerName
        // 
        lblPlayerName.AutoSize = true;
        lblPlayerName.Location = new Point(152, 86);
        lblPlayerName.Name = "lblPlayerName";
        lblPlayerName.Size = new Size(108, 25);
        lblPlayerName.TabIndex = 10;
        lblPlayerName.Text = "Player name";
        // 
        // Game
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(772, 647);
        Controls.Add(lblPlayerNameValue);
        Controls.Add(lblPlayerName);
        Controls.Add(lblDifficultyValue);
        Controls.Add(lblDifficulty);
        Controls.Add(lblTime);
        Controls.Add(lblAttempts);
        Controls.Add(lblFeedback);
        Controls.Add(btnRestart);
        Controls.Add(btnGuess);
        Controls.Add(txtGuess);
        Controls.Add(lblPrompt);
        Name = "Game";
        Text = "Zahlen raten";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtGuess;
    private Button btnGuess;
    private Button btnRestart;
    private Label lblFeedback;
    private Label lblPrompt;
    private Label lblDifficultyValue;
    private Label lblDifficulty;
    private Label lblAttempts;
    private Label lblTime;
    private Label lblPlayerName;
    private Label lblPlayerNameValue;
}
