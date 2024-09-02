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
    public partial class ClientFrom : Form
    {
        private string Name { get; set; }
        private string Phone { get; set; }

        public ClientFrom()
        {
            InitializeComponent();
            dataGridView1.DataSource = Model.GetClientDataTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientAMD form = new ClientAMD(button1.Text);
            form.ShowDialog();
            //dataGridView1.DataSource = DB.DataBase.GetDataTable(DB.SqlQueries.selectClient);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SetClientNameAndPhone();
                ClientAMD form = new ClientAMD(button2.Text, Name, Phone);
                form.ShowDialog();
                dataGridView1.DataSource = Model.GetClientDataTable(); 
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void ClientFrom_Load(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SetClientNameAndPhone();
                int id = await Model.GetClientIdByPhone(Phone);
                var result = MessageBox.Show("Вы хотите удалить клиента?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                    await Model.DeleteClient(id);
                dataGridView1.DataSource = dataGridView1.DataSource = Model.GetClientDataTable();
            }
        }

        private void SetClientNameAndPhone()
        {
            try
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                this.Name = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();
                this.Phone = dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString();
            }
            catch(System.NullReferenceException)
            {
                MessageBox.Show("Клиент не выбран или таблица пустая.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
