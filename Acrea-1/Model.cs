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

namespace ACREA
{
    public static class Model
    {

        //public static async void InsertStatuses() => await DataBaseContext.InsertStatuses(GetStatusDict()); 
        public static async void DbIsExist()
        {
            if(!File.Exists(DbConst.db))
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
        public static async Task LoadComponentsToDataGridView(DataGridView dataGridView)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var components = await context.Components.ToListAsync();

                dataGridView.Columns.Clear();

                dataGridView.Columns.Add("Id", "ID");
                dataGridView.Columns.Add("Name", "Название");
                dataGridView.Columns.Add("Type", "Тип");
                dataGridView.Columns.Add("Count", "Количество");
                dataGridView.Columns.Add("Price", "Цена");

                foreach (var component in components)
                {
                    dataGridView.Rows.Add(component.Id, component.Name, component.Type, component.Count, component.Price);
                }
            }
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

        public static async Task UpdateComponent()
        {
            //TO DO
        }

        public static async Task<int> GetComponentTypeID(string name)
        {
            int id = 1;
            using(var context = new AcreaContext(DbConst.context))
            {
                id = await context.ComponentTypes.Where(ct => ct.Name == name)
                    .Select(ct => ct.Id)
                    .FirstOrDefaultAsync();
            }
            return id;
        }
        public static async Task<int> SetComponentId()
        {
            using (var context = new AcreaContext(DbConst.context))
                return await context.Components.CountAsync();
        }
        public static async Task<Dictionary<int, string>> GetComponentTypeFromDB()
        {
            var context = new AcreaContext(DbConst.context);
            return await context.ComponentTypes.ToDictionaryAsync(e => e.Id, e => e.Name);
        }
        public static Dictionary<int, string> GetPartTypeDict(List<PartType> partTypes)
        {
            Dictionary<int, string> getPartTypeDict = new Dictionary<int, string>();
            foreach(var item in partTypes)
            {
                getPartTypeDict[item.ID] = item.Type;
            }
            return getPartTypeDict;
        }


     
    }
}
