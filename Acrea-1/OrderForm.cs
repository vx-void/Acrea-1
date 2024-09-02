using DB;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ACREA
{
    public partial class OrderForm : Form
    {
        private Order? _order { get; set; }

        public OrderForm(string buttonText, Order? order = null)
        {
            InitializeComponent();
            actionButton.Text = buttonText;
            if (order != null)
            {
                this._order = order;
                idTextBox.Text = _order.Id.ToString();
                statusComboBox.SelectedValue = Model.GetStatusById(_order.Status);
                dateTimeStart.Value = _order.DateStart;
                dateTimeEnd.Value = _order.DateDeadline;
                deviceTextBox.Text = _order.Device;
                clientNameTextBox.Text = Model.GetClientNameById(_order.Client);    ////----------------------------------------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                clientPhoneTextBox.Text = Model.GetClientPhoneById(_order.Client);
                defectTextBox.Text = _order.Defect;
                priceTextBox.Text = _order.Price.ToString();
            }
        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        private void Order_Load(object sender, EventArgs e)
        {


            statusComboBox.DataSource = new BindingSource(DbConst.statusDict, null);
            statusComboBox.DisplayMember = "Value";
            statusComboBox.ValueMember = "Key";
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var order = new DB.Order();

            switch (actionButton.Text)
            {
                case "Создать":
                    SetComponentOrder(order);
                    break;
                case "Редактировать":
                    SetComponentOrder(_order);
                    break;
            }
        }

        private async void SetComponentOrder(Order? order)
        {

            if (actionButton.Text == "Создать")
            {

                order.Id = await Model.GetNextOrderId(); //<<----------------------------------------------------------------------
                order.DateStart = dateTimeStart.Value;
                order.DateDeadline = dateTimeEnd.Value;
                order.Device = deviceTextBox.Text;
                order.Defect = defectTextBox.Text;
                order.OClient = new DB.Client(clientNameTextBox.Text, clientPhoneTextBox.Text);
                order.Status = statusComboBox.SelectedIndex + 1;
                order.Price = double.Parse(priceTextBox.Text);
                Model.CreateOrder(order);
            }
            else if (actionButton.Text == "Редактировать")
            {
                order.Id = int.Parse(idTextBox.Text); //<<----------------------------------------------------------------------
                order.DateStart = dateTimeStart.Value;
                order.DateDeadline = dateTimeEnd.Value;
                order.Device = deviceTextBox.Text;
                order.Defect = defectTextBox.Text;
                order.OClient = new DB.Client(clientNameTextBox.Text, clientPhoneTextBox.Text);
                order.Status = statusComboBox.SelectedIndex + 1;
                order.Price = double.Parse(priceTextBox.Text);

                Model.UpdateOrder(order);
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            ChangeClientForm change = new ChangeClientForm();
            //change.ShowDialog();
            if(change.ShowDialog() == DialogResult.OK)
            {
                clientNameTextBox.Text = change.ClientName;
                clientPhoneTextBox.Text = change.ClientPhone;
            }
        }
    }
}
