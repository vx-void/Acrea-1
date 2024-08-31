using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Xml.Linq;

namespace ACREA
{
    public static class Model
    {

        //public static async void InsertStatuses() => await DataBaseContext.InsertStatuses(GetStatusDict()); 
        public static async void DbIsExist()
        {
            if (!File.Exists(DbConst.db))
                await CreateDB();
        }
        private static async Task CreateDB()
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                await context.Database.EnsureCreatedAsync();
                foreach (var item in DbConst.statusDict)
                {
                    var status = new Status(item.Key, item.Value);
                    context.Status.Add(status);
                    context.SaveChanges();
                }
                foreach (var item in DbConst.componentTypeDict)
                {
                    var componentType = new ComponentType(item.Key, item.Value);
                    context.ComponentTypes.Add(componentType);
                    context.SaveChanges();
                }

            }

        }

        //Entity: Component
        public static DataTable GetComponentsToDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string)).ColumnName = "Наименование";
            dataTable.Columns.Add("Type", typeof(string)).ColumnName = "Тип";
            dataTable.Columns.Add("Count", typeof(int)).ColumnName = "Количество";
            dataTable.Columns.Add("Price", typeof(decimal)).ColumnName = "Стоимость";
            using (var context = new AcreaContext(DbConst.context))
            {
                var components = context.Components.Include(c => c.CComponentType).ToList();
                foreach (var component in components)
                {
                    DataRow row = dataTable.NewRow();
                    row["Наименование"] = component.Name;
                    row["Тип"] = component.CComponentType?.Name ?? "";
                    row["Количество"] = component.Count;
                    row["Стоимость"] = component.Price;
                    dataTable.Rows.Add(row);
                }
            }
            return dataTable;
        }
        public static async Task<int> GetComponentIdByName(string name)
        {
            int id = 0;
            using (var context = new AcreaContext(DbConst.context))
            {
                id = await context.Components.Where(c => c.Name == name)
                     .Select(c => c.Id)
                     .FirstOrDefaultAsync();
            }

            return id;
        }
        public static async Task<int> SetComponentId()
        {
            using (var context = new AcreaContext(DbConst.context))
                return await context.Components.CountAsync();
        }
        public static async Task InsertComponent(int id, string name, int type, int count, double price)
        {
            var component = new DB.Component()
            {
                Id = id,
                Name = name,
                Type = type,
                Count = count,
                Price = price
            };
            using (var context = new AcreaContext(DbConst.context))
            {
                await context.Components.AddAsync(component);
                await context.SaveChangesAsync();
            }
        }
        public static async Task UpdateComponent(int id, string name, int type, int count, double price)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var component = await context.Components.FindAsync(id);
                if (component != null)
                {
                    component.Name = name;
                    component.Type = type;
                    component.Count = count;
                    component.Price = price;

                    context.Components.Update(component);
                    await context.SaveChangesAsync();
                }
            }
        }
        public static async Task DeleteComponent(int id)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var component = await context.Components.FindAsync(id);
                if (component != null)
                {
                    context.Components.Remove(component);
                    await context.SaveChangesAsync();
                }
            }
        }

        //Entity: ComponentType
        public static async Task<int> GetComponentTypeID(string name)
        {
            int id = 1;
            using (var context = new AcreaContext(DbConst.context))
            {
                id = await context.ComponentTypes.Where(ct => ct.Name == name)
                    .Select(ct => ct.Id)
                    .FirstOrDefaultAsync();
            }
            return id;
        }
        public static async Task<Dictionary<int, string>> GetComponentTypeFromDB()
        {
            var context = new AcreaContext(DbConst.context);
            return await context.ComponentTypes.ToDictionaryAsync(e => e.Id, e => e.Name);
        }
        public static async Task<string> GetComponentTypeName(int id)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var componentType = await context.ComponentTypes.FirstOrDefaultAsync(ct => ct.Id == id);
                return componentType?.Name ?? string.Empty;
            }
        }

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
            var client = new DB.Client()
            {
                Id = id,
                Name = name,
                Phone = phone
            };
            using (var context = new AcreaContext(DbConst.context))
            {
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();
            }

        }

        public static async Task<int> SetClientId()
        {
            using (var context = new AcreaContext(DbConst.context))
                return await context.Clients.CountAsync();
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
            int id;
            using (var context = new AcreaContext(DbConst.context))
            {
                id = await context.Clients.Where(c => c.Phone == phone)
                     .Select(c => c.Id)
                     .FirstOrDefaultAsync();
            }

            return id;
        }
        public static DataTable GetClientDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string)).ColumnName = "ФИО" ;
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


        //Entity: Order


    }
}
