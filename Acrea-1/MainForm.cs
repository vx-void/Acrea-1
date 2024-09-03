namespace ACREA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataModel.GetOrderDataTable();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Components components = new Components();
            //components.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ComponentsListForm components = new ComponentsListForm();
            components.ShowDialog();
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            ClientFrom clientForm = new ClientFrom();
            clientForm.ShowDialog();
        }

        private void createOrderButton_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm("Создать");
            orderForm.ShowDialog();
            dataGridView1.DataSource = DataModel.GetOrderDataTable();
        }

        private void editOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.SelectedRows[0].Index;

                var order = new DB.Order()
                {
                    Id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value),
                    Client = DataModel.GetClientIdByName(dataGridView1.Rows[index].Cells[1].Value.ToString()),
                    Device = dataGridView1.Rows[index].Cells[2].Value.ToString(),
                    Defect = dataGridView1.Rows[index].Cells[3].Value.ToString(),
                    DateStart = DateTime.Parse(dataGridView1.Rows[index].Cells[4].Value.ToString()),
                    DateDeadline = DateTime.Parse(dataGridView1.Rows[index].Cells[5].Value.ToString()),
                    Status = DataModel.GetStatusByName(dataGridView1.Rows[index].Cells[6].Value.ToString()),
                    Price = Convert.ToDouble(dataGridView1.Rows[index].Cells[7].Value.ToString())
                };
                OrderForm orderForm = new OrderForm("Редактировать", order);
                orderForm.ShowDialog();
                dataGridView1.DataSource = DataModel.GetOrderDataTable();
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Строка заказа не выбрана или отсутсвует");
            }
        }
    }
}
