using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACREA
{
    public partial class ChangeClientForm : Form
    {
        public string ClientName { get; private set; }
        public string ClientPhone { get; private set; }
        public ChangeClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientActionButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                ClientName = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ClientPhone = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ChangeClientForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataModel.GetClientDataTable();
        }
    }
}
