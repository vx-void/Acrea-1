using DB;
using Microsoft.EntityFrameworkCore.Metadata;
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
        private DataTable dataTable; // Declare this at the class level
        private List<DB.Component> selectedComponents = new List<DB.Component>();
        private double componentsPrice = 0;

        public OrderForm(string buttonText, Order? order = null)
        {
            InitializeComponent();
            actionButton.Text = buttonText;
            if (order != null)
            {
                this._order = order;
                idTextBox.Text = _order.Id.ToString();
                statusComboBox.SelectedValue = DataModel.GetStatusById(_order.Status);
                dateTimeStart.Value = _order.DateStart;
                dateTimeEnd.Value = _order.DateDeadline;
                deviceTextBox.Text = _order.Device;
                clientNameTextBox.Text = DataModel.GetClientNameById(_order.Client);    ////----------------------------------------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                clientPhoneTextBox.Text = DataModel.GetClientPhoneById(_order.Client);
                defectTextBox.Text = _order.Defect;
                priceTextBox.Text = (Convert.ToDouble(_order.Price) + componentsPrice).ToString();
            }
            else
            {
                idTextBox.Text = DataModel.GetNextOrderId().ToString();
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
          
            //    dataTable = new DataTable();
            //    dataTable.Columns.Add("Наименование", typeof(string));
            //    dataTable.Columns.Add("Количество", typeof(string));
            //    dataTable = DataModel.GetComponentOrderDataTable(Convert.ToInt32(idTextBox.Text));
            //if (dataTable != null)
            //{ dataGridView1.DataSource = dataTable; }
            

                
            
           
        }
        private async void button1_Click(object sender, EventArgs e)
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
            if (dataGridView1.Rows != null)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row != null)
                        {
                            int componentId = await DataModel.GetComponentIdByName(row.Cells["Наименование"].Value.ToString());
                            DataModel.AddComponentToOrder(Convert.ToInt32(idTextBox.Text), Convert.ToInt32(componentId));
                        }
                    }
                }
            }
        }

        private void SetParameters(Order? order)
        {
            order.Id = int.Parse(idTextBox.Text);
            order.DateStart = dateTimeStart.Value;
            order.DateDeadline = dateTimeEnd.Value;
            order.Device = deviceTextBox.Text;
            order.Defect = defectTextBox.Text;
            order.OClient = new DB.Client(clientNameTextBox.Text, clientPhoneTextBox.Text);
            order.Status = statusComboBox.SelectedIndex + 1;
            priceTextBox.Text = (Convert.ToDouble(order.Price) + componentsPrice).ToString();

        }

        private async void SetComponentOrder(Order? order)
        {

            if (actionButton.Text == "Создать")
            {

                SetParameters(order);
                DataModel.CreateOrder(order);
            }
            else if (actionButton.Text == "Редактировать")
            {
                SetParameters(order);
                DataModel.UpdateOrder(order);
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

            if (change.ShowDialog() == DialogResult.OK)
            {
                clientNameTextBox.Text = change.ClientName;
                clientPhoneTextBox.Text = change.ClientPhone;
            }
        }

        private async void addComponentButton_Click(object sender, EventArgs e)
        {

            if (dataTable == null) 
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("Наименование", typeof(string));
                dataTable.Columns.Add("Количество", typeof(string));
                //dataGridView1.DataSource = dataTable; 
            }
            SelectComponentForm form = new SelectComponentForm(Convert.ToInt32(idTextBox.Text));
            if (form.ShowDialog() == DialogResult.OK)
            {
              
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        selectedComponents.Add(form.SelectedComponent);
                        componentsPrice += form.SelectedComponent.Price;
                        int id = Convert.ToInt32(form.SelectedComponent.Id);
                        priceTextBox.Text = (Convert.ToDouble(_order.Price) + componentsPrice).ToString();
                        await DataModel.UpdateComponentCount(id, 1, false);
                        dataTable.Rows.Add(form.SelectedComponent.Name, form.SelectedComponent.Count);
                    }
                
            }
        }

        private void deleteComponentButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || dataGridView1.SelectedRows.ToString() == null)
            {
                MessageBox.Show("Select a component to remove");
                return;
            }

            int selectedIndex = dataGridView1.SelectedRows[0].Index;

            dataTable = (DataTable)dataGridView1.DataSource;
            DB.Component selectedComponent = selectedComponents[selectedIndex];

            dataTable.Rows.RemoveAt(selectedIndex);
            dataGridView1.DataSource = dataTable;

            selectedComponents.RemoveAt(selectedIndex);
            componentsPrice -= selectedComponent.Price;
            priceTextBox.Text = (Convert.ToDouble(_order.Price) + componentsPrice).ToString();

            DataModel.UpdateComponentCount(selectedComponent.Id, -1, false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
