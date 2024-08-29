using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ACREA
{
    public partial class Components : Form
    {
        public Components()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            //    ComponentPart componentPart = new ComponentPart()
            //    {
            //        Name = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString(),
            //        PType = DB.DataBase.GetPartType(dataGridView1.Rows[selectedRowIndex].Cells[1].Value.ToString()),
            //        Quantity = int.Parse(dataGridView1.Rows[selectedRowIndex].Cells[2].Value.ToString()),
            //        Price = double.Parse(dataGridView1.Rows[selectedRowIndex].Cells[3].Value.ToString())
                   
            //    };
            //    Part part = new Part("Редактировать", componentPart);
            //    part.ShowDialog();
            //    dataGridView1.DataSource = DB.DataBase.GetDataTable(DB.SqlQueries.selectPart);

            //}



        }

        private void button3_Click(object sender, EventArgs e)
        {
            Part part = new Part("Добавить");
            part.ShowDialog();
            //dataGridView1.DataSource = DB.DataBase.GetDataTable(DB.SqlQueries.selectPart);
        }

        private void Components_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = DB.DataBase.GetDataTable(DB.SqlQueries.selectPart);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
            //    ComponentPart componentPart = new ComponentPart ()
            //    {
            //        Name = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString(),
            //    };
            //    var result = MessageBox.Show("Удалить выбранный компонент?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (result == DialogResult.Yes)
            //    {
            //        DB.DataBase.DeletePart(componentPart.Name);
            //    }
            //    dataGridView1.DataSource = DB.DataBase.GetDataTable(DB.SqlQueries.selectPart);
            //}
        }
    }
}
