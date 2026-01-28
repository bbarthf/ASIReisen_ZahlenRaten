namespace zahlenRaten.View;

public partial class Game : Form
{
    private readonly Controller.GameController _controller;

    private readonly System.Windows.Forms.Timer _uiTimer;

    public Game()
    {
        InitializeComponent();

        _controller = new Controller.GameController(new Model.GameSettings
        {
            Difficulty = Model.DifficultyLevel.Easy
        });

        _uiTimer = new System.Windows.Forms.Timer { Interval = 200 };
        _uiTimer.Tick += (_, _) => UpdateStats();

        lblPlayerNameValue.Text = _controller.State.PlayerName;
        lblDifficultyValue.Text = _controller.Settings.Difficulty.ToString();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        if (!ShowConfigDialogAndApply())
        {
            Close();
            return;
        }

        StartNewGame();
    }

    private bool ShowConfigDialogAndApply()
    {
        using var dialog = new ConfigDialog();
        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return false;
        }

        _controller.SetPlayerName(dialog.PlayerName);
        _controller.SetDifficulty(dialog.Difficulty);

        lblPlayerNameValue.Text = _controller.State.PlayerName;
        lblDifficultyValue.Text = _controller.Settings.Difficulty.ToString();

        return true;
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

        _uiTimer.Start();
        UpdateStats();
    }

    private void UpdateStats()
    {
        lblAttempts.Text = $"Attempts: {_controller.State.Attempts}";

        var elapsed = _controller.State.Elapsed;
        lblTime.Text = elapsed is null ? "Time: 0.0s" : $"Time: {elapsed.Value.TotalSeconds:0.0}s";
    }

    private void UpdateGuessButtonEnabled()
    {
        btnGuess.Enabled =
            txtGuess.Enabled &&
            !string.IsNullOrWhiteSpace(txtGuess.Text) &&
            !string.IsNullOrWhiteSpace(_controller.State.PlayerName);
    }

    private void btnGuess_Click(object sender, EventArgs e)
    {
        var result = _controller.MakeGuess(txtGuess.Text ?? string.Empty);

        lblFeedback.Text = result.Message;
        lblFeedback.ForeColor = result.Outcome == Model.GuessOutcome.Correct ? Color.Green : Color.Red;

        UpdateStats();

        if (result.IsGameOver)
        {
            txtGuess.Enabled = false;
            btnGuess.Enabled = false;

            _uiTimer.Stop();
            UpdateStats();
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
        if (!ShowConfigDialogAndApply())
        {
            return;
        }

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
