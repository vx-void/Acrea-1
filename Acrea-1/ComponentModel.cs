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
    }
}
