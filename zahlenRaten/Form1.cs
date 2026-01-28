namespace zahlenRaten
{
    public partial class Form1 : Form
    {
        private readonly Controller.GameController _controller;

        public Form1()
        {
            InitializeComponent();

            _controller = new Controller.GameController(new Model.GameSettings
            {
                Min = 1,
                Max = 10
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            _controller.StartNewGame();

            lblPrompt.Text = $"Enter a number ({_controller.Settings.Min}-{_controller.Settings.Max}) and click Guess";
            lblFeedback.Text = string.Empty;
            lblFeedback.ForeColor = SystemColors.ControlText;
            txtGuess.Text = string.Empty;
            txtGuess.Enabled = true;
            UpdateGuessButtonEnabled();
            txtGuess.Focus();
        }

        private void UpdateGuessButtonEnabled()
        {
            btnGuess.Enabled = txtGuess.Enabled && !string.IsNullOrWhiteSpace(txtGuess.Text);
        }

        private void btnGuess_Click(object sender, EventArgs e)
        {
            var result = _controller.MakeGuess(txtGuess.Text ?? string.Empty);

            lblFeedback.Text = result.Message;
            lblFeedback.ForeColor = result.Outcome == Model.GuessOutcome.Correct ? Color.Green : Color.Red;

            if (result.IsGameOver)
            {
                txtGuess.Enabled = false;
                btnGuess.Enabled = false;
            }
            else
            {
                txtGuess.SelectAll();
                txtGuess.Focus();
                UpdateGuessButtonEnabled();
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void txtGuess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;
            btnGuess.PerformClick();
        }

        private void txtGuess_TextChanged(object sender, EventArgs e)
        {
            UpdateGuessButtonEnabled();
        }
    }
}
