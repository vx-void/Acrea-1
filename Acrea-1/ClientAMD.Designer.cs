namespace ACREA
{
    partial class ClientAMD
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
            clientActionButton = new Button();
            closeButton = new Button();
            nameTextBox = new TextBox();
            phoneTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // clientActionButton
            // 
            clientActionButton.Location = new Point(14, 159);
            clientActionButton.Margin = new Padding(4, 3, 4, 3);
            clientActionButton.Name = "clientActionButton";
            clientActionButton.Size = new Size(138, 27);
            clientActionButton.TabIndex = 0;
            clientActionButton.Text = "clientActionButton";
            clientActionButton.UseVisualStyleBackColor = true;
            clientActionButton.Click += clientActionButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(300, 159);
            closeButton.Margin = new Padding(4, 3, 4, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(138, 27);
            closeButton.TabIndex = 1;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(75, 37);
            nameTextBox.Margin = new Padding(4, 3, 4, 3);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(347, 23);
            nameTextBox.TabIndex = 2;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(164, 87);
            phoneTextBox.Margin = new Padding(4, 3, 4, 3);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(257, 23);
            phoneTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 37);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 4;
            label1.Text = "ФИО";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 90);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 5;
            label2.Text = "Контактный телефон";
            // 
            // ClientAMD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 200);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(phoneTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(closeButton);
            Controls.Add(clientActionButton);
            Margin = new Padding(4, 3, 4, 3);
            base.Name = "ClientAMD";
            Text = "Информация о клиенте / заказчике";
            Load += ClientAMD_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button clientActionButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}