using DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ACREA
{
    public static partial class Model
    {
        public static DataTable GetOrderDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(string)).ColumnName = "# Заказа";
            dataTable.Columns.Add("Client", typeof(string)).ColumnName = "Клиент";
            dataTable.Columns.Add("Device", typeof(string)).ColumnName = "Устройство";
            dataTable.Columns.Add("Defect", typeof(string)).ColumnName = "Неисправность";
            dataTable.Columns.Add("DateStart", typeof(string)).ColumnName = "Дата приемки заказа";
            dataTable.Columns.Add("dateDeadline", typeof(string)).ColumnName = "Крайний срок сдачи заказа";
            dataTable.Columns.Add("Status", typeof(string)).ColumnName = "Статус";
            dataTable.Columns.Add("Price", typeof(string)).ColumnName = "Стоимость заказа";
            using (var context = new AcreaContext(DbConst.context))
            {
                var orders = context.Orders.ToList();
                
                foreach (var order in orders)
                {
                    Client client = context.Clients.FirstOrDefault(c => c.Id == order.Client);
                    DataRow row = dataTable.NewRow();
                    row["# Заказа"] = order.Id.ToString();
                    row["Клиент"] = client.Name; 
                    row["Устройство"] = order.Device;
                    row["Неисправность"] = order.Defect;
                    row["Дата приемки заказа"] = order.DateStart.ToShortDateString();
                    row["Крайний срок сдачи заказа"] = order.DateDeadline.ToShortDateString();
                    row["Статус"] = Model.GetStatusById(order.Status);
                    row["Стоимость заказа"] = order.Price?.ToString("F2");

                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }
        public static async void CreateOrder(Order order)
        {          
            using(var context = new AcreaContext(DbConst.context))
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
            }
        }

        public static async Task<int> GetNextOrderId()
        {
            int currentOrderCount = 0;
            using (var context = new AcreaContext(DbConst.context))
            {
                currentOrderCount = context.Orders.Count();
                currentOrderCount++;
            }
            return currentOrderCount;
        }

        public static void UpdateOrder(Order order)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var existOrder = context.Orders.Find(order.Id);
                if(existOrder != null)
                {
                    existOrder.Status = order.Status;
                    existOrder.Client = order.Client;
                    existOrder.DateStart = order.DateStart;
                    existOrder.DateDeadline = order.DateDeadline;
                    existOrder.Device = order.Device;
                    existOrder.Defect = order.Defect;
                    existOrder.Price = order.Price;
             //       context.Entry(existOrder).CurrentValues.SetValues(order);
                    context.SaveChanges();
                }

            }
        }

    }
}
