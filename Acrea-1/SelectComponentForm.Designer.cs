namespace ACREA
{
    partial class SelectComponentForm
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            componentActionButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 50);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.Size = new Size(379, 143);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(293, 12);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(73, 24);
            button1.TabIndex = 5;
            button1.Text = "Отмена";
            button1.UseVisualStyleBackColor = true;
            button1.Click += cancelButton_Click;
            // 
            // componentActionButton
            // 
            componentActionButton.Location = new Point(13, 12);
            componentActionButton.Margin = new Padding(4, 3, 4, 3);
            componentActionButton.Name = "componentActionButton";
            componentActionButton.Size = new Size(73, 24);
            componentActionButton.TabIndex = 4;
            componentActionButton.Text = "Выбрать";
            componentActionButton.UseVisualStyleBackColor = true;
            componentActionButton.Click += componentActionButton_Click;
            // 
            // SelectComponentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 193);
            Controls.Add(button1);
            Controls.Add(componentActionButton);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SelectComponentForm";
            Text = "Выбор компонентов";
            Load += SelectComponentForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button componentActionButton;
    }
}