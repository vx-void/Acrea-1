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
        private string Name { get; set; }
        private string Phone { get; set; }

        public ClientAMD()
        {
            InitializeComponent();
        }

        public ClientAMD(string actionButtonText, string name = "", string phone = "")
        {
            InitializeComponent();
            this.clientActionButton.Text = actionButtonText;
            if (name != "" && phone != "")
            {
                this.Name = name;
                this.Phone = Model.GetPhoneNumberFormat(phone);
                nameTextBox.Text = Name.ToString();
                phoneTextBox.Text = Phone.ToString();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void clientActionButton_Click(object sender, EventArgs e)
        {
            switch (clientActionButton.Text)
            {
                case "Создать":
                    this.Name = nameTextBox.Text.ToString();
                    this.Phone = phoneTextBox.Text.ToString();
                    var id = await Model.SetClientId();
                    await Model.InsertClient(id, Name, Phone);
                    break;
                case "Редактировать":
                    var result = MessageBox.Show("Редактировать информацию о клиенте?", "Информация о клиенте", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (result == DialogResult.Yes)
                    //    DB.DataBase.UpdateClient(nameTextBox.Text.ToString(), phoneTextBox.Text.ToString(), ClientName.ToString(), Phone.ToString());
                    break;

            }
            this.Close();
        }

        private void ClientAMD_Load(object sender, EventArgs e)
        {

        }
    }
}
