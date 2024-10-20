partial class AddTaskForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Label lblResponsible;
    private System.Windows.Forms.TextBox txtResponsible;
    private System.Windows.Forms.Label lblDueDate;
    private System.Windows.Forms.DateTimePicker dtpDueDate;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;

    private void InitializeComponent()
    {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblResponsible = new System.Windows.Forms.Label();
            this.txtResponsible = new System.Windows.Forms.TextBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название задачи:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 26);
            this.txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 45);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 20);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Описание задачи:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 42);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // lblResponsible
            // 
            this.lblResponsible.Location = new System.Drawing.Point(12, 115);
            this.lblResponsible.Name = "lblResponsible";
            this.lblResponsible.Size = new System.Drawing.Size(132, 23);
            this.lblResponsible.TabIndex = 4;
            this.lblResponsible.Text = "Ответственный эколог:";
            // 
            // txtResponsible
            // 
            this.txtResponsible.Location = new System.Drawing.Point(150, 112);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Size = new System.Drawing.Size(200, 26);
            this.txtResponsible.TabIndex = 5;
            // 
            // lblDueDate
            // 
            this.lblDueDate.Location = new System.Drawing.Point(12, 145);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(120, 20);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "Срок выполнения:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(150, 142);
            this.dtpDueDate.MaximumSize = new System.Drawing.Size(200, 26);
            this.dtpDueDate.MinimumSize = new System.Drawing.Size(200, 26);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 26);
            this.dtpDueDate.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(150, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 180);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddTaskForm
            // 
            this.ClientSize = new System.Drawing.Size(441, 232);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblResponsible);
            this.Controls.Add(this.txtResponsible);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddTaskForm";
            this.Text = "Добавить задачу";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
}
