partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ListBox lstTasks;
    private System.Windows.Forms.Button btnAddTask;
    private System.Windows.Forms.Button btnChangeStatus;
    private System.Windows.Forms.TextBox txtResponsibleFilter;
    private System.Windows.Forms.Button btnFilterByResponsible;
    private System.Windows.Forms.Button btnResetFilter;

    private void InitializeComponent()
    {
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.txtResponsibleFilter = new System.Windows.Forms.TextBox();
            this.btnFilterByResponsible = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.ItemHeight = 20;
            this.lstTasks.Location = new System.Drawing.Point(12, 12);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(400, 184);
            this.lstTasks.TabIndex = 0;
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(12, 202);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(83, 41);
            this.btnAddTask.TabIndex = 1;
            this.btnAddTask.Text = "Добавить задачу";
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(130, 202);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(79, 41);
            this.btnChangeStatus.TabIndex = 2;
            this.btnChangeStatus.Text = "Изменить статус";
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // txtResponsibleFilter
            // 
            this.txtResponsibleFilter.Location = new System.Drawing.Point(12, 260);
            this.txtResponsibleFilter.Name = "txtResponsibleFilter";
            this.txtResponsibleFilter.Size = new System.Drawing.Size(150, 26);
            this.txtResponsibleFilter.TabIndex = 3;
            // 
            // btnFilterByResponsible
            // 
            this.btnFilterByResponsible.Location = new System.Drawing.Point(170, 260);
            this.btnFilterByResponsible.Name = "btnFilterByResponsible";
            this.btnFilterByResponsible.Size = new System.Drawing.Size(86, 26);
            this.btnFilterByResponsible.TabIndex = 4;
            this.btnFilterByResponsible.Text = "Фильтр по экологу";
            this.btnFilterByResponsible.Click += new System.EventHandler(this.btnFilterByResponsible_Click);
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(300, 260);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(99, 26);
            this.btnResetFilter.TabIndex = 5;
            this.btnResetFilter.Text = "Сбросить фильтр";
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(427, 319);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.txtResponsibleFilter);
            this.Controls.Add(this.btnFilterByResponsible);
            this.Controls.Add(this.btnResetFilter);
            this.MaximumSize = new System.Drawing.Size(449, 375);
            this.MinimumSize = new System.Drawing.Size(449, 375);
            this.Name = "MainForm";
            this.Text = "Учет задач отдела экологии";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
