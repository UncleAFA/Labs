using System;
using System.Windows.Forms;
using System.Xml.Linq;

public partial class AddTaskForm : Form
{
    public Task NewTask { get; private set; }

    public AddTaskForm()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // Считывание данных с формы
        string name = txtName.Text;
        string description = txtDescription.Text;
        string responsible = txtResponsible.Text;
        DateTime dueDate = dtpDueDate.Value;

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(responsible))
        {
            MessageBox.Show("Название задачи и ответственный должны быть заполнены.");
            return;
        }

        NewTask = new Task(name, description, responsible, dueDate);
        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

}
