using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ACREA
{
    public partial class Part : Form
    {
        private ComponentPart ComponentPart { get; set; }
        private Dictionary<int, string> partType;
        private ComponentPart oldPart;

        public Part(string actionButtonText, ComponentPart component) : this(actionButtonText)
        {
            this.ComponentPart = component;
        }

        public Part(string actionButtonText)
        {
            InitializeComponent();
            actionButton.Text = !string.IsNullOrWhiteSpace(actionButtonText)
                                ? actionButtonText
                                : string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Part_Load(object sender, EventArgs e)
        {
            
            //partType = Model.GetPartTypeDict(DB.DataBase.GetPartTypeList());
            //componentTypeComboBox.DataSource = new BindingSource(partType, null);
            //componentTypeComboBox.DisplayMember = "Value";
            //componentTypeComboBox.ValueMember = "Key";
            //componentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //if (ComponentPart != null)
            //{                
            //    componentTypeComboBox.Text = partType[ComponentPart.GetTypeID()];
            //    textBox1.Text = ComponentPart.GetName();
            //    textBox2.Text = ComponentPart.GetQuantity().ToString();
            //    textBox4.Text = ComponentPart.GetPrice().ToString();
            //    oldPart = GetOldComponentPart();
            //}
            
        }

        private void actionButton_Click(object sender, EventArgs e)
        {
            //if (!ValidateInputs(out int quantity, out double price))
            //    return;

            //var newPart = new ComponentPart
            //{
            //    Name = textBox1.Text,
            //    Quantity = quantity,
            //    Price = price,
            //    PType = DB.DataBase.GetPartType(componentTypeComboBox.Text)
            //};

            switch (actionButton.Text)
            {
                case "Добавить":
                    //DB.DataBase.InsertPart(newPart);
                    break;
                case "Редактировать":
                    //DB.DataBase.UpdatePart(oldPart, newPart);
                    break;
            }

            this.Close();
        }

        //private ComponentPart GetOldComponentPart()
        //{

        //    return new ComponentPart;
        //    ////{
        //    ////    Name = textBox1.Text,
        //    ////    Quantity = Convert.ToInt32(textBox2.Text),
        //    ////    Price = Convert.ToDouble(textBox4.Text),
        //    ////    PType = DB.DataBase.GetPartType(componentTypeComboBox.Text)
        //    //};
        //}

        private bool ValidateInputs(out int quantity, out double price)
        {
            if (!int.TryParse(textBox2.Text, out quantity))
            {
                price = 0;
                return false;
            }

            if (!double.TryParse(textBox4.Text, out price))
            {
                return false;
            }
            return true;
        }
    }
}