﻿namespace ACREA
{
    partial class OrderForm
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
            actionButton = new Button();
            button2 = new Button();
            deviceTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label8 = new Label();
            dateTimeStart = new DateTimePicker();
            dateTimeEnd = new DateTimePicker();
            label1 = new Label();
            idTextBox = new TextBox();
            label7 = new Label();
            statusComboBox = new ComboBox();
            dataGridView1 = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            clientNameTextBox = new TextBox();
            button3 = new Button();
            button4 = new Button();
            label9 = new Label();
            defectTextBox = new TextBox();
            clientPhoneTextBox = new TextBox();
            label6 = new Label();
            label10 = new Label();
            priceTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // actionButton
            // 
            actionButton.Location = new Point(19, 486);
            actionButton.Margin = new Padding(4, 3, 4, 3);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(118, 26);
            actionButton.TabIndex = 12;
            actionButton.Text = "Создать/Изменить";
            actionButton.UseVisualStyleBackColor = true;
            actionButton.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(406, 486);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(118, 26);
            button2.TabIndex = 13;
            button2.Text = "Закрыть";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // deviceTextBox
            // 
            deviceTextBox.Location = new Point(19, 123);
            deviceTextBox.Margin = new Padding(4, 3, 4, 3);
            deviceTextBox.Name = "deviceTextBox";
            deviceTextBox.Size = new Size(511, 23);
            deviceTextBox.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 44);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 24;
            label2.Text = "Дата создания заказа";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 105);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 25;
            label3.Text = "Устройство";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(280, 44);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 30;
            label8.Text = "Крайний срок";
            // 
            // dateTimeStart
            // 
            dateTimeStart.Location = new Point(19, 62);
            dateTimeStart.Margin = new Padding(4, 3, 4, 3);
            dateTimeStart.Name = "dateTimeStart";
            dateTimeStart.Size = new Size(166, 23);
            dateTimeStart.TabIndex = 34;
            // 
            // dateTimeEnd
            // 
            dateTimeEnd.Location = new Point(284, 62);
            dateTimeEnd.Margin = new Padding(4, 3, 4, 3);
            dateTimeEnd.Name = "dateTimeEnd";
            dateTimeEnd.Size = new Size(166, 23);
            dateTimeEnd.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 38;
            label1.Text = "№";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(42, 7);
            idTextBox.Margin = new Padding(4, 3, 4, 3);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(160, 23);
            idTextBox.TabIndex = 37;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(280, 10);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 39;
            label7.Text = "Статус";
            // 
            // statusComboBox
            // 
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(348, 7);
            statusComboBox.Margin = new Padding(4, 3, 4, 3);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(176, 23);
            statusComboBox.TabIndex = 40;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(318, 183);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(206, 229);
            dataGridView1.TabIndex = 41;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(315, 162);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(151, 15);
            label4.TabIndex = 42;
            label4.Text = "Заменяемые компоненты";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 162);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 44;
            label5.Text = "ФИО Клиента";
            // 
            // clientNameTextBox
            // 
            clientNameTextBox.Location = new Point(18, 180);
            clientNameTextBox.Margin = new Padding(4, 3, 4, 3);
            clientNameTextBox.Name = "clientNameTextBox";
            clientNameTextBox.Size = new Size(259, 23);
            clientNameTextBox.TabIndex = 43;
            // 
            // button3
            // 
            button3.Location = new Point(318, 418);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(85, 33);
            button3.TabIndex = 47;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(439, 418);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(85, 33);
            button4.TabIndex = 48;
            button4.Text = "Удалить";
            button4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 285);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(149, 15);
            label9.TabIndex = 50;
            label9.Text = "Описание неисправности";
            // 
            // defectTextBox
            // 
            defectTextBox.Location = new Point(19, 303);
            defectTextBox.Margin = new Padding(4, 3, 4, 3);
            defectTextBox.Multiline = true;
            defectTextBox.Name = "defectTextBox";
            defectTextBox.Size = new Size(258, 109);
            defectTextBox.TabIndex = 49;
            // 
            // clientPhoneTextBox
            // 
            clientPhoneTextBox.Location = new Point(18, 240);
            clientPhoneTextBox.Margin = new Padding(4, 3, 4, 3);
            clientPhoneTextBox.Name = "clientPhoneTextBox";
            clientPhoneTextBox.Size = new Size(259, 23);
            clientPhoneTextBox.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 222);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 46;
            label6.Text = "№ телефона";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(20, 418);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(67, 15);
            label10.TabIndex = 52;
            label10.Text = "Стоимость";
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(24, 436);
            priceTextBox.Margin = new Padding(4, 3, 4, 3);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(253, 23);
            priceTextBox.TabIndex = 51;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(545, 536);
            Controls.Add(label10);
            Controls.Add(priceTextBox);
            Controls.Add(label9);
            Controls.Add(defectTextBox);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label6);
            Controls.Add(clientPhoneTextBox);
            Controls.Add(label5);
            Controls.Add(clientNameTextBox);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(deviceTextBox);
            Controls.Add(idTextBox);
            Controls.Add(label7);
            Controls.Add(statusComboBox);
            Controls.Add(dateTimeEnd);
            Controls.Add(dateTimeStart);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(actionButton);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrderForm";
            Text = "Заказ";
            Load += Order_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox deviceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox clientNameTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox defectTextBox;
        private TextBox clientPhoneTextBox;
        private Label label6;
        private Label label10;
        private TextBox priceTextBox;
    }
}