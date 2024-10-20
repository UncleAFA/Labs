using Lab4;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class MainForm : Form
{
    private List<Task> tasks = new List<Task>();

    public MainForm()
    {
        InitializeComponent();
        UpdateTaskList();
    }

    private void btnAddTask_Click(object sender, EventArgs e)
    {
        // Открытие формы для добавления новой задачи
        var addTaskForm = new AddTaskForm();
        if (addTaskForm.ShowDialog() == DialogResult.OK)
        {
            tasks.Add(addTaskForm.NewTask);
            UpdateTaskList();
        }
    }

    private void btnChangeStatus_Click(object sender, EventArgs e)
    {
        // Изменение статуса выбранной задачи
        if (lstTasks.SelectedItem is Task selectedTask)
        {
            var changeStatusForm = new ChangeStatusForm(selectedTask);
            if (changeStatusForm.ShowDialog() == DialogResult.OK)
            {
                UpdateTaskList();
            }
        }
        else
        {
            MessageBox.Show("Выберите задачу для изменения статуса.");
        }
    }

    private void btnFilterByResponsible_Click(object sender, EventArgs e)
    {
        // Фильтрация задач по экологу
        string responsible = txtResponsibleFilter.Text;
        var filteredTasks = tasks.FindAll(t => t.Responsible == responsible);
        lstTasks.DataSource = filteredTasks;
    }

    private void btnResetFilter_Click(object sender, EventArgs e)
    {
        // Сброс фильтрации
        UpdateTaskList();
    }

    private void UpdateTaskList()
    {
        lstTasks.DataSource = null;
        lstTasks.DataSource = tasks;
    }
}
