using DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACREA
{
    public static partial class Model
    {
        //Entity:Client
        public static string GetPhoneNumberFormat(string number)
        {
            number = new string(number.Where(char.IsDigit).ToArray());

            if (number.Length != 11)
                return "phone format error";

            // x(xxx) xxx-xxxx
            return $"{number[0]}({number.Substring(1, 3)}) {number.Substring(4, 3)}-{number.Substring(7)}";
        }
        public static async Task InsertClient(int id, string name, string phone)
        {
            var client = new DB.Client(id, name, phone);           
            using (var context = new AcreaContext(DbConst.context))
            {
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();
            }

        }
        public static int SetClientId()
        {
            using (var context = new AcreaContext(DbConst.context))
                return context.Clients.Count() + 1;
        }
        public static async Task UpdateClient(int id, string name, string phone)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var client = await context.Clients.FindAsync(id);
                if (client != null)
                {
                    client.Name = name;
                    client.Id = id;
                    client.Phone = phone;

                    context.Clients.Update(client);
                    await context.SaveChangesAsync();
                }
            }
        }
        public static async Task DeleteClient(int id)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var client = await context.Clients.FindAsync(id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    await context.SaveChangesAsync();
                }
            }
        }
        public static async Task<int> GetClientIdByPhone(string phone)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                return await context.Clients.Where(c => c.Phone == phone)
                     .Select(c => c.Id)
                     .FirstOrDefaultAsync();
            }
        }
        public static async Task<string> GetClientNameById(int id)
        {
            string name = "";
            using (var context = new AcreaContext(DbConst.context))
            {
                name = await context.Clients.Where(c => c.Id == id)
                     .Select(c => c.Name)
                     .FirstOrDefaultAsync();
            }
            return name;
        }
        public static int GetClientIdByName(string name)
        {
            using(var context = new AcreaContext(DbConst.context))
            {
                return context.Clients.Where(c => c.Name == name)
                    .Select(c => c.Id)
                    .FirstOrDefault();
            }
        }
        public static DataTable GetClientDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string)).ColumnName = "ФИО";
            dataTable.Columns.Add("Phone", typeof(string)).ColumnName = "Телефон";
            using (var context = new AcreaContext(DbConst.context))
            {
                var clients = context.Clients.ToList();
                foreach (var client in clients)
                {
                    DataRow row = dataTable.NewRow();
                    row["ФИО"] = client.Name;
                    row["Телефон"] = client.Phone;
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }
    }
}
