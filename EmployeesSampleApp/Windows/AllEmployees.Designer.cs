
namespace EmployeesSampleApp.Windows
{
    partial class AllEmployees
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
            this.GridView = new System.Windows.Forms.DataGridView();
            this.AddNew = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentPage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalPages = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TotalRecords = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PageLimit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // GridView
            // 
            this.GridView.AllowUserToAddRows = false;
            this.GridView.AllowUserToDeleteRows = false;
            this.GridView.AllowUserToResizeRows = false;
            this.GridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView.Location = new System.Drawing.Point(14, 55);
            this.GridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GridView.MultiSelect = false;
            this.GridView.Name = "GridView";
            this.GridView.ReadOnly = true;
            this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView.Size = new System.Drawing.Size(905, 440);
            this.GridView.TabIndex = 0;
            this.GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView_CellClick);
            this.GridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_CellMouseDoubleClick);
            // 
            // AddNew
            // 
            this.AddNew.Location = new System.Drawing.Point(14, 12);
            this.AddNew.Name = "AddNew";
            this.AddNew.Size = new System.Drawing.Size(75, 23);
            this.AddNew.TabIndex = 1;
            this.AddNew.Text = "შექმნა";
            this.AddNew.UseVisualStyleBackColor = true;
            this.AddNew.Click += new System.EventHandler(this.AddNew_Click);
            // 
            // Previous
            // 
            this.Previous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Previous.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Previous.Location = new System.Drawing.Point(14, 519);
            this.Previous.Name = "Previous";
            this.Previous.Size = new System.Drawing.Size(28, 23);
            this.Previous.TabIndex = 2;
            this.Previous.Text = "<";
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Next
            // 
            this.Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Next.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Next.Location = new System.Drawing.Point(233, 519);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(28, 23);
            this.Next.TabIndex = 2;
            this.Next.Text = ">";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(52, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "გვერდი:";
            // 
            // CurrentPage
            // 
            this.CurrentPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CurrentPage.Enabled = false;
            this.CurrentPage.Location = new System.Drawing.Point(107, 519);
            this.CurrentPage.Name = "CurrentPage";
            this.CurrentPage.Size = new System.Drawing.Size(36, 23);
            this.CurrentPage.TabIndex = 4;
            this.CurrentPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Font = new System.Drawing.Font("Sylfaen", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(149, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "/";
            // 
            // TotalPages
            // 
            this.TotalPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TotalPages.Enabled = false;
            this.TotalPages.Location = new System.Drawing.Point(171, 519);
            this.TotalPages.Name = "TotalPages";
            this.TotalPages.Size = new System.Drawing.Size(36, 23);
            this.TotalPages.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(751, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "სულ";
            // 
            // TotalRecords
            // 
            this.TotalRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalRecords.Enabled = false;
            this.TotalRecords.Location = new System.Drawing.Point(793, 520);
            this.TotalRecords.Name = "TotalRecords";
            this.TotalRecords.Size = new System.Drawing.Size(53, 23);
            this.TotalRecords.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(852, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "ჩანაწერი";
            // 
            // PageLimit
            // 
            this.PageLimit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PageLimit.Location = new System.Drawing.Point(555, 519);
            this.PageLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PageLimit.Name = "PageLimit";
            this.PageLimit.Size = new System.Drawing.Size(43, 23);
            this.PageLimit.TabIndex = 9;
            this.PageLimit.TabStop = false;
            this.PageLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PageLimit.ValueChanged += new System.EventHandler(this.PageLimit_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label5.Location = new System.Drawing.Point(433, 521);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "ჩანაწერი გვერდზე:";
            // 
            // AllEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.PageLimit);
            this.Controls.Add(this.TotalRecords);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TotalPages);
            this.Controls.Add(this.CurrentPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.AddNew);
            this.Controls.Add(this.GridView);
            this.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AllEmployees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ყველა თანამშრომელი";
            this.Load += new System.EventHandler(this.AllEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.Button AddNew;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CurrentPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TotalPages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TotalRecords;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown PageLimit;
        private System.Windows.Forms.Label label5;
    }
}