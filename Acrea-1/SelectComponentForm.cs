using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DB;

namespace ACREA
{
    public partial class SelectComponentForm : Form
    {
        public DB.Component SelectedComponent { get; private set; }
        public int? OrderID { get; set; }
        public SelectComponentForm(int? orderId)
        {
            InitializeComponent();
            dataGridView1.DataSource = Model.GetComponentsToDataTable();
            if (orderId != null)
                this.OrderID = orderId;
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void componentActionButton_Click(object sender, EventArgs e)
        {
            
            int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            SelectedComponent = await Model.GetComponentByName(dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString());
            DialogResult = DialogResult.OK;
            this.Close();
 
        }  

        private void SelectComponentForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Model.GetComponentsToDataTable();
        }
    }
} 
