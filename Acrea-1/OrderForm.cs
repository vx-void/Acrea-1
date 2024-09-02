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
                statusComboBox.SelectedValue = Model.GetStatusById(_order.Status);
                dateTimeStart.Value = _order.DateStart;
                dateTimeEnd.Value = _order.DateDeadline;
                deviceTextBox.Text = _order.Device;
                clientNameTextBox.Text = Model.GetClientNameById(_order.Client);    ////----------------------------------------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                clientPhoneTextBox.Text = Model.GetClientPhoneById(_order.Client);
                defectTextBox.Text = _order.Defect;
                priceTextBox.Text = (Convert.ToDouble(_order.Price) + componentsPrice).ToString();
            }
            else
            {
                idTextBox.Text = Model.GetNextOrderId().ToString();
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
            try
            {
                dataGridView1.DataSource = Model.GetComponentOrderDataTable(Convert.ToInt32(idTextBox.Text));
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row != null)
                    {
                        int componentId = await Model.GetComponentIdByName(row.Cells["Наименование"].Value.ToString());
                        Model.AddComponentToOrder(Convert.ToInt32(idTextBox.Text), Convert.ToInt32(componentId));
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
            priceTextBox.Text = (Convert.ToDouble(_order.Price) + componentsPrice).ToString();

        }

        private async void SetComponentOrder(Order? order)
        {

            if (actionButton.Text == "Создать")
            {

                SetParameters(order);
                Model.CreateOrder(order);
            }
            else if (actionButton.Text == "Редактировать")
            {
                SetParameters(order);
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

            if (change.ShowDialog() == DialogResult.OK)
            {
                clientNameTextBox.Text = change.ClientName;
                clientPhoneTextBox.Text = change.ClientPhone;
            }
        }

        private async void addComponentButton_Click(object sender, EventArgs e)
        {
            SelectComponentForm form = new SelectComponentForm(Convert.ToInt32(idTextBox.Text));

            if (form.ShowDialog() == DialogResult.OK)
            {
                selectedComponents.Add(form.SelectedComponent);
                componentsPrice += form.SelectedComponent.Price;
                priceTextBox.Text = (Convert.ToDouble(_order.Price) + componentsPrice).ToString();
                await Model.UpdateComponentCount(form.SelectedComponent.Id, 1, false);
                //-------------------------V----------------------------------------------
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("Наименование", typeof(string));

                foreach (var component in selectedComponents)
                {
                    dataTable.Rows.Add(component.Name);
                }
                dataGridView1.DataSource = dataTable;
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

            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DB.Component selectedComponent = selectedComponents[selectedIndex];

            dataTable.Rows.RemoveAt(selectedIndex);
            dataGridView1.DataSource = dataTable;

            selectedComponents.RemoveAt(selectedIndex);
            componentsPrice -= selectedComponent.Price;
            priceTextBox.Text = (Convert.ToDouble(_order.Price) + componentsPrice).ToString();

            Model.UpdateComponentCount(selectedComponent.Id, -1, false);
        }
    }
}
