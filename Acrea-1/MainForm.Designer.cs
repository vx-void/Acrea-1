namespace ACREA
{
    partial class MainForm
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
            createOrderButton = new Button();
            editOrderButton = new Button();
            deleteOrderButton = new Button();
            searchButton = new Button();
            exitButton = new Button();
            componentsButton = new Button();
            componentTypeButton = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            clientButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 153);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(985, 463);
            dataGridView1.TabIndex = 0;
            // 
            // createOrderButton
            // 
            createOrderButton.Location = new Point(7, 24);
            createOrderButton.Margin = new Padding(4, 3, 4, 3);
            createOrderButton.Name = "createOrderButton";
            createOrderButton.Size = new Size(113, 24);
            createOrderButton.TabIndex = 1;
            createOrderButton.Text = "Создать";
            createOrderButton.UseVisualStyleBackColor = true;
            createOrderButton.Click += createOrderButton_Click;
            // 
            // editOrderButton
            // 
            editOrderButton.Location = new Point(7, 59);
            editOrderButton.Margin = new Padding(4, 3, 4, 3);
            editOrderButton.Name = "editOrderButton";
            editOrderButton.Size = new Size(113, 24);
            editOrderButton.TabIndex = 2;
            editOrderButton.Text = "Редактировать";
            editOrderButton.UseVisualStyleBackColor = true;
            editOrderButton.Click += editOrderButton_Click;
            // 
            // deleteOrderButton
            // 
            deleteOrderButton.Location = new Point(7, 90);
            deleteOrderButton.Margin = new Padding(4, 3, 4, 3);
            deleteOrderButton.Name = "deleteOrderButton";
            deleteOrderButton.Size = new Size(113, 28);
            deleteOrderButton.TabIndex = 3;
            deleteOrderButton.Text = "Удалить";
            deleteOrderButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            searchButton.Enabled = false;
            searchButton.Location = new Point(860, 104);
            searchButton.Margin = new Padding(4, 3, 4, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(113, 28);
            searchButton.TabIndex = 4;
            searchButton.Text = "Поиск";
            searchButton.TextImageRelation = TextImageRelation.TextAboveImage;
            searchButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(897, 14);
            exitButton.Margin = new Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 28);
            exitButton.TabIndex = 5;
            exitButton.Text = "Выход";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += button5_Click_1;
            // 
            // componentsButton
            // 
            componentsButton.Location = new Point(7, 59);
            componentsButton.Margin = new Padding(4, 3, 4, 3);
            componentsButton.Name = "componentsButton";
            componentsButton.Size = new Size(136, 24);
            componentsButton.TabIndex = 6;
            componentsButton.Text = "Компоненты";
            componentsButton.UseVisualStyleBackColor = true;
            componentsButton.Click += button6_Click_1;
            // 
            // componentTypeButton
            // 
            componentTypeButton.Enabled = false;
            componentTypeButton.Location = new Point(7, 90);
            componentTypeButton.Margin = new Padding(4, 3, 4, 3);
            componentTypeButton.Name = "componentTypeButton";
            componentTypeButton.Size = new Size(136, 28);
            componentTypeButton.TabIndex = 7;
            componentTypeButton.Text = "Типы компонентов";
            componentTypeButton.UseVisualStyleBackColor = true;
            componentTypeButton.Click += button7_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(editOrderButton);
            groupBox1.Controls.Add(createOrderButton);
            groupBox1.Controls.Add(deleteOrderButton);
            groupBox1.Location = new Point(4, 14);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(154, 133);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Заказ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(componentsButton);
            groupBox2.Controls.Add(componentTypeButton);
            groupBox2.Location = new Point(158, 14);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(154, 133);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Компоненты / Запчасти";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(clientButton);
            groupBox3.Location = new Point(318, 14);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(154, 133);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Заказчики";
            // 
            // clientButton
            // 
            clientButton.Location = new Point(7, 90);
            clientButton.Margin = new Padding(4, 3, 4, 3);
            clientButton.Name = "clientButton";
            clientButton.Size = new Size(136, 28);
            clientButton.TabIndex = 7;
            clientButton.Text = "список заказчиков";
            clientButton.UseVisualStyleBackColor = true;
            clientButton.Click += clientButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(986, 614);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(exitButton);
            Controls.Add(searchButton);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            Text = "ACREA";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button editOrderButton;
        private System.Windows.Forms.Button deleteOrderButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button componentsButton;
        private System.Windows.Forms.Button componentTypeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clientButton;
    }
}