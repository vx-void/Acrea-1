namespace ACREA
{
    partial class Main
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.izdelie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.neispravnost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createOrderButton = new System.Windows.Forms.Button();
            this.editOrderButton = new System.Windows.Forms.Button();
            this.deleteOrderButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.componentsButton = new System.Windows.Forms.Button();
            this.componentTypeButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clientButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Date,
            this.deadline,
            this.izdelie,
            this.neispravnost,
            this.Client,
            this.component,
            this.status});
            this.dataGridView1.Location = new System.Drawing.Point(1, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(844, 401);
            this.dataGridView1.TabIndex = 0;
            // 
            // Number
            // 
            this.Number.HeaderText = "№";
            this.Number.Name = "Number";
            // 
            // Date
            // 
            this.Date.HeaderText = "Дата";
            this.Date.Name = "Date";
            // 
            // deadline
            // 
            this.deadline.HeaderText = "Крайний срок";
            this.deadline.Name = "deadline";
            // 
            // izdelie
            // 
            this.izdelie.HeaderText = "Изделие";
            this.izdelie.Name = "izdelie";
            // 
            // neispravnost
            // 
            this.neispravnost.HeaderText = "Неисправность";
            this.neispravnost.Name = "neispravnost";
            // 
            // Client
            // 
            this.Client.HeaderText = "Заказчик";
            this.Client.Name = "Client";
            // 
            // component
            // 
            this.component.HeaderText = "Заменяемые компоненты";
            this.component.Name = "component";
            // 
            // status
            // 
            this.status.HeaderText = "Статус";
            this.status.Name = "status";
            // 
            // createOrderButton
            // 
            this.createOrderButton.Location = new System.Drawing.Point(6, 21);
            this.createOrderButton.Name = "createOrderButton";
            this.createOrderButton.Size = new System.Drawing.Size(97, 21);
            this.createOrderButton.TabIndex = 1;
            this.createOrderButton.Text = "Создать";
            this.createOrderButton.UseVisualStyleBackColor = true;
            // 
            // editOrderButton
            // 
            this.editOrderButton.Location = new System.Drawing.Point(6, 51);
            this.editOrderButton.Name = "editOrderButton";
            this.editOrderButton.Size = new System.Drawing.Size(97, 21);
            this.editOrderButton.TabIndex = 2;
            this.editOrderButton.Text = "Редактировать";
            this.editOrderButton.UseVisualStyleBackColor = true;
            // 
            // deleteOrderButton
            // 
            this.deleteOrderButton.Location = new System.Drawing.Point(6, 78);
            this.deleteOrderButton.Name = "deleteOrderButton";
            this.deleteOrderButton.Size = new System.Drawing.Size(97, 24);
            this.deleteOrderButton.TabIndex = 3;
            this.deleteOrderButton.Text = "Удалить";
            this.deleteOrderButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(635, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(97, 24);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Поиск";
            this.searchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(769, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(64, 24);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // componentsButton
            // 
            this.componentsButton.Location = new System.Drawing.Point(6, 51);
            this.componentsButton.Name = "componentsButton";
            this.componentsButton.Size = new System.Drawing.Size(117, 21);
            this.componentsButton.TabIndex = 6;
            this.componentsButton.Text = "Компоненты";
            this.componentsButton.UseVisualStyleBackColor = true;
            this.componentsButton.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // componentTypeButton
            // 
            this.componentTypeButton.Enabled = false;
            this.componentTypeButton.Location = new System.Drawing.Point(6, 78);
            this.componentTypeButton.Name = "componentTypeButton";
            this.componentTypeButton.Size = new System.Drawing.Size(117, 24);
            this.componentTypeButton.TabIndex = 7;
            this.componentTypeButton.Text = "Типы компонентов";
            this.componentTypeButton.UseVisualStyleBackColor = true;
            this.componentTypeButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editOrderButton);
            this.groupBox1.Controls.Add(this.createOrderButton);
            this.groupBox1.Controls.Add(this.deleteOrderButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 115);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заказ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.componentsButton);
            this.groupBox2.Controls.Add(this.componentTypeButton);
            this.groupBox2.Location = new System.Drawing.Point(135, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 115);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Компоненты / Запчасти";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clientButton);
            this.groupBox3.Location = new System.Drawing.Point(273, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(132, 115);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Заказчики";
            // 
            // clientButton
            // 
            this.clientButton.Location = new System.Drawing.Point(6, 78);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(117, 24);
            this.clientButton.TabIndex = 7;
            this.clientButton.Text = "список заказчиков";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 532);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "ACREA";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button createOrderButton;
        private System.Windows.Forms.Button editOrderButton;
        private System.Windows.Forms.Button deleteOrderButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button componentsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn deadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn izdelie;
        private System.Windows.Forms.DataGridViewTextBoxColumn neispravnost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn component;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button componentTypeButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clientButton;
    }
}