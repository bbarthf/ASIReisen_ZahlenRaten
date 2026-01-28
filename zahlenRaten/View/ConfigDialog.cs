using zahlenRaten.Model;

namespace zahlenRaten.View;

public partial class ConfigDialog : Form
{
    public ConfigDialog()
    {
        InitializeComponent();

        cboDifficulty.DataSource = Enum.GetValues<DifficultyLevel>();
        cboDifficulty.SelectedItem = DifficultyLevel.Easy;

        UpdateOkEnabled();
    }

    public string PlayerName => (txtPlayerName.Text ?? string.Empty).Trim();

    public DifficultyLevel Difficulty => cboDifficulty.SelectedItem is DifficultyLevel d ? d : DifficultyLevel.Easy;

    private void txtPlayerName_TextChanged(object sender, EventArgs e)
    {
        UpdateOkEnabled();
    }

    private void UpdateOkEnabled()
    {
        btnOk.Enabled = !string.IsNullOrWhiteSpace(PlayerName);
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
