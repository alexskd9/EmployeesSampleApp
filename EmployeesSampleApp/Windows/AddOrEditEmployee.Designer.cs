
namespace EmployeesSampleApp.Windows
{
    partial class AddOrEditEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MobileNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Salary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.CheckBox();
            this.Execute = new System.Windows.Forms.Button();
            this.Rank = new System.Windows.Forms.ComboBox();
            this.Edit = new System.Windows.Forms.Button();
            this.EmployeeId = new System.Windows.Forms.TextBox();
            this.DeleteEmployee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "სახელი";
            // 
            // FirstName
            // 
            this.FirstName.Location = new System.Drawing.Point(118, 13);
            this.FirstName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(179, 23);
            this.FirstName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "გვარი";
            // 
            // LastName
            // 
            this.LastName.Location = new System.Drawing.Point(118, 44);
            this.LastName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(179, 23);
            this.LastName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "ტელ. ნომერი";
            // 
            // MobileNumber
            // 
            this.MobileNumber.Location = new System.Drawing.Point(118, 75);
            this.MobileNumber.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MobileNumber.Name = "MobileNumber";
            this.MobileNumber.Size = new System.Drawing.Size(179, 23);
            this.MobileNumber.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "როლი";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "ხელფასი";
            // 
            // Salary
            // 
            this.Salary.Location = new System.Drawing.Point(118, 137);
            this.Salary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Salary.Name = "Salary";
            this.Salary.Size = new System.Drawing.Size(179, 23);
            this.Salary.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(14, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "სტატუსი";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(118, 171);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(15, 14);
            this.Status.TabIndex = 5;
            this.Status.UseVisualStyleBackColor = true;
            // 
            // Execute
            // 
            this.Execute.Location = new System.Drawing.Point(199, 246);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(98, 23);
            this.Execute.TabIndex = 6;
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // Rank
            // 
            this.Rank.FormattingEnabled = true;
            this.Rank.Location = new System.Drawing.Point(118, 105);
            this.Rank.Name = "Rank";
            this.Rank.Size = new System.Drawing.Size(179, 24);
            this.Rank.TabIndex = 3;
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(199, 246);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(98, 23);
            this.Edit.TabIndex = 6;
            this.Edit.Text = "რედაქტირება";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Visible = false;
            this.Edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // EmployeeId
            // 
            this.EmployeeId.Location = new System.Drawing.Point(0, 259);
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.Size = new System.Drawing.Size(28, 23);
            this.EmployeeId.TabIndex = 7;
            this.EmployeeId.Visible = false;
            // 
            // DeleteEmployee
            // 
            this.DeleteEmployee.Location = new System.Drawing.Point(118, 246);
            this.DeleteEmployee.Name = "DeleteEmployee";
            this.DeleteEmployee.Size = new System.Drawing.Size(75, 23);
            this.DeleteEmployee.TabIndex = 8;
            this.DeleteEmployee.Text = "წაშლა";
            this.DeleteEmployee.UseVisualStyleBackColor = true;
            this.DeleteEmployee.Visible = false;
            this.DeleteEmployee.Click += new System.EventHandler(this.DeleteEmployee_Click);
            // 
            // AddOrEditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 281);
            this.Controls.Add(this.DeleteEmployee);
            this.Controls.Add(this.EmployeeId);
            this.Controls.Add(this.Rank);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Execute);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Salary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MobileNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(325, 320);
            this.MinimumSize = new System.Drawing.Size(325, 320);
            this.Name = "AddOrEditEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddOrEditEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button Execute;
        public System.Windows.Forms.TextBox FirstName;
        public System.Windows.Forms.TextBox LastName;
        public System.Windows.Forms.TextBox MobileNumber;
        public System.Windows.Forms.TextBox Salary;
        public System.Windows.Forms.CheckBox Status;
        public System.Windows.Forms.ComboBox Rank;
        public System.Windows.Forms.Button Edit;
        public System.Windows.Forms.TextBox EmployeeId;
        public System.Windows.Forms.Button DeleteEmployee;
    }
}