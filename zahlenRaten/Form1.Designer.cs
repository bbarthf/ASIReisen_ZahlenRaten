namespace zahlenRaten
{
    partial class Form1
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
            lblWelcome = new Label();
            SuspendLayout();
            // 
            // txtGuess
            // 
            txtGuess.Location = new Point(169, 131);
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(120, 31);
            txtGuess.TabIndex = 1;
            txtGuess.TextChanged += txtGuess_TextChanged;
            txtGuess.KeyDown += txtGuess_KeyDown;
            // 
            // btnGuess
            // 
            btnGuess.Enabled = false;
            btnGuess.Location = new Point(103, 246);
            btnGuess.Name = "btnGuess";
            btnGuess.Size = new Size(98, 31);
            btnGuess.TabIndex = 2;
            btnGuess.Text = "Guess";
            btnGuess.UseVisualStyleBackColor = true;
            btnGuess.Click += btnGuess_Click;
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(248, 246);
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
            lblFeedback.Location = new Point(129, 176);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(0, 25);
            lblFeedback.TabIndex = 4;
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(103, 83);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(310, 25);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "Enter a number (1-10) and click Guess";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(148, 28);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(184, 25);
            lblWelcome.TabIndex = 5;
            lblWelcome.Text = "welcome to the game";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 305);
            Controls.Add(lblWelcome);
            Controls.Add(lblFeedback);
            Controls.Add(btnRestart);
            Controls.Add(btnGuess);
            Controls.Add(txtGuess);
            Controls.Add(lblPrompt);
            Name = "Form1";
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
        private Label lblWelcome;
    }
}
