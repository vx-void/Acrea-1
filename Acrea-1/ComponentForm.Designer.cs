namespace ACREA
{
    partial class ComponentForm
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
            closeButton = new Button();
            label1 = new Label();
            componentNameTextBox = new TextBox();
            componentCountTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            componentPriceTextBox = new TextBox();
            label4 = new Label();
            componentTypeComboBox = new ComboBox();
            SuspendLayout();
            // 
            // actionButton
            // 
            actionButton.Location = new Point(18, 193);
            actionButton.Margin = new Padding(4, 3, 4, 3);
            actionButton.Name = "actionButton";
            actionButton.Size = new Size(138, 27);
            actionButton.TabIndex = 0;
            actionButton.UseVisualStyleBackColor = true;
            actionButton.Click += actionButton_Click;
            // 
            // closeButton
            // 
            closeButton.Location = new Point(301, 193);
            closeButton.Margin = new Padding(4, 3, 4, 3);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(128, 27);
            closeButton.TabIndex = 1;
            closeButton.Text = "Закрыть";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 2;
            label1.Text = "Маркировка";
            // 
            // componentNameTextBox
            // 
            componentNameTextBox.Location = new Point(103, 30);
            componentNameTextBox.Margin = new Padding(4, 3, 4, 3);
            componentNameTextBox.Name = "componentNameTextBox";
            componentNameTextBox.Size = new Size(326, 23);
            componentNameTextBox.TabIndex = 3;
            // 
            // componentCountTextBox
            // 
            componentCountTextBox.Location = new Point(103, 128);
            componentCountTextBox.Margin = new Padding(4, 3, 4, 3);
            componentCountTextBox.Name = "componentCountTextBox";
            componentCountTextBox.Size = new Size(107, 23);
            componentCountTextBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 132);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 4;
            label2.Text = "Количество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 82);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 6;
            label3.Text = "Тип";
            // 
            // componentPriceTextBox
            // 
            componentPriceTextBox.Location = new Point(313, 128);
            componentPriceTextBox.Margin = new Padding(4, 3, 4, 3);
            componentPriceTextBox.Name = "componentPriceTextBox";
            componentPriceTextBox.Size = new Size(116, 23);
            componentPriceTextBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(267, 132);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 8;
            label4.Text = "Цена";
            // 
            // componentTypeComboBox
            // 
            componentTypeComboBox.FormattingEnabled = true;
            componentTypeComboBox.Location = new Point(103, 73);
            componentTypeComboBox.Margin = new Padding(4, 3, 4, 3);
            componentTypeComboBox.Name = "componentTypeComboBox";
            componentTypeComboBox.Size = new Size(326, 23);
            componentTypeComboBox.TabIndex = 10;
            // 
            // ComponentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 233);
            Controls.Add(componentTypeComboBox);
            Controls.Add(componentPriceTextBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(componentCountTextBox);
            Controls.Add(label2);
            Controls.Add(componentNameTextBox);
            Controls.Add(label1);
            Controls.Add(closeButton);
            Controls.Add(actionButton);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ComponentForm";
            Text = "Компонент";
            Load += Part_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox componentNameTextBox;
        private System.Windows.Forms.TextBox componentCountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox componentPriceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox componentTypeComboBox;
    }
}