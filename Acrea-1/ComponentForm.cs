using DB;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ACREA
{
    public partial class ComponentForm : Form
    {
        private string Name { get; set; }
        private int Type { get; set; }
        private int Count { get; set; }
        private double Price { get; set; }
        
        private Dictionary<int, string> ComponentType { get; set; }
       
        public ComponentForm(string actionButtonText, string? name, int? type, int? count, double? price)
        {
            InitializeComponent();
            actionButton.Text = !string.IsNullOrWhiteSpace(actionButtonText)
                                ? actionButtonText
                                : string.Empty;
            this.Name = !string.IsNullOrEmpty(name) ? name : "";
            this.Type = !string.IsNullOrEmpty(type.ToString()) ? (int)type : 0;
            this.Count = !string.IsNullOrEmpty(count.ToString()) ? (int)count : 0;
            this.Price = !string.IsNullOrEmpty(price.ToString()) ? (double)price : 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Part_Load(object sender, EventArgs e)
        {
            ComponentType = await DataModel.GetComponentTypeFromDB();


            //partType = Model.GetPartTypeDict(DB.DataBase.GetPartTypeList());
            componentTypeComboBox.DataSource = new BindingSource(ComponentType, null);
            componentTypeComboBox.DisplayMember = "Value";
            componentTypeComboBox.ValueMember = "Key";
            componentTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            if (this.Name != "" && Type != 0 && Count != 0 && Price !=0)
            {                         
                componentNameTextBox.Text = this.Name;
                componentTypeComboBox.Text = await DataModel.GetComponentTypeName(this.Type);
                componentCountTextBox.Text = this.Count.ToString();
                componentPriceTextBox.Text = this.Price.ToString();
            }

        }

        private async void actionButton_Click(object sender, EventArgs e)
        {
            int componentID;
            int componentType = await DataModel.GetComponentTypeID(componentTypeComboBox.Text.ToString());
            switch (actionButton.Text)
            {
                
                case "Добавить":
                    componentID = await DataModel.SetComponentId() + 1;
                    await DataModel.InsertComponent(componentID, componentNameTextBox.Text.ToString(), componentType, int.Parse(componentCountTextBox.Text), double.Parse(componentPriceTextBox.Text));
                    break;
                case "Редактировать":
                    componentID = await DataModel.GetComponentIdByName(this.Name);
                    await DataModel.UpdateComponent(componentID, this.Name, componentType, 
                        int.Parse(componentCountTextBox.Text), 
                        double.Parse(componentPriceTextBox.Text));

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