using System;
using System.Windows.Forms;

public partial class ChangeStatusForm : Form
{
    private Task currentTask;

    public ChangeStatusForm(Task task)
    {
        InitializeComponent();
        currentTask = task;
        lblTaskName.Text = task.Name;
        cmbStatus.Items.AddRange(new string[] { "Не начато", "В процессе", "Завершено" });
        cmbStatus.SelectedItem = task.Status;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        currentTask.Status = cmbStatus.SelectedItem.ToString();
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
