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
    public partial class ClientAMD : Form
    {
        private string ClientName { get; set; }
        private string Phone { get; set; }

        public ClientAMD()
        {
            InitializeComponent();
        }

        public ClientAMD(string actionButtonText, string name = "", string phone = "")
        {
            InitializeComponent();
            this.clientActionButton.Text = actionButtonText;
            if(name != "" && phone != "")
            {
                this.ClientName = name;
                this.Phone = phone;
                nameTextBox.Text = ClientName.ToString();
                phoneTextBox.Text = Phone.ToString();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientActionButton_Click(object sender, EventArgs e)
        {
            switch (clientActionButton.Text)
            {
                case "Создать":
                    this.ClientName = nameTextBox.Text.ToString();
                    this.Phone = phoneTextBox.Text.ToString();
                    //DB.DataBase.InsertClient(ClientName, Phone);
                    break;
                case "Редактировать":
                    var result = MessageBox.Show("Редактировать информацию о клиенте?", "Информация о клиенте", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //    DB.DataBase.UpdateClient(nameTextBox.Text.ToString(), phoneTextBox.Text.ToString(), ClientName.ToString(), Phone.ToString());
                    break;

            }
            this.Close();
        }
    }
}
