using DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ACREA
{
    public partial class ComponentForm : Form
    {
        private ComponentPart ComponentPart { get; set; }
        private Dictionary<int, string> ComponentType { get; set; }
        private ComponentPart oldPart;

        public ComponentForm(string actionButtonText, ComponentPart component) : this(actionButtonText)
        {
            this.ComponentPart = component;
        }

        public ComponentForm(string actionButtonText)
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

        private async void Part_Load(object sender, EventArgs e)
        {
            ComponentType = await Model.GetComponentTypeFromDB();


            //partType = Model.GetPartTypeDict(DB.DataBase.GetPartTypeList());
            componentTypeComboBox.DataSource = new BindingSource(ComponentType, null);
            componentTypeComboBox.DisplayMember = "Value";
            componentTypeComboBox.ValueMember = "Key";
            componentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            //if (ComponentPart != null)
            //{                
            //    componentTypeComboBox.Text = partType[ComponentPart.GetTypeID()];
            //    textBox1.Text = ComponentPart.GetName();
            //    textBox2.Text = ComponentPart.GetQuantity().ToString();
            //    textBox4.Text = ComponentPart.GetPrice().ToString();
            //    oldPart = GetOldComponentPart();
            //}

        }

        private async void actionButton_Click(object sender, EventArgs e)
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
                    int componentID = await Model.SetComponentId() + 1;
                    int componentType = await Model.GetComponentTypeID(componentTypeComboBox.Text.ToString());
                    await Model.InsertComponent(componentID, componentNameTextBox.Text.ToString(), componentType, int.Parse(componentCountTextBox.Text), double.Parse(componentPriceTextBox.Text));
                    break;
                case "Редактировать":
                    //TO DO 

                    /*
                     
                    Вывести список запчастей
                    +добавить запчасти
                    удалить запчасти

                     
                     */


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
            if (!int.TryParse(componentCountTextBox.Text, out quantity))
            {
                price = 0;
                return false;
            }

            if (!double.TryParse(componentPriceTextBox.Text, out price))
            {
                return false;
            }
            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}