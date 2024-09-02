using DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static async Task UpdateComponentCount(int componentId, int amount, bool isIncrement)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                var component = await context.Components.FindAsync(componentId);
                if (component != null)
                {
                    if (isIncrement)
                    {
                        component.Count += amount;
                    }
                    else
                    {
                        if (component.Count >= amount)
                        {
                            component.Count -= amount;
                        }
                        else
                        {
                            MessageBox.Show("Количество после удаления станет отрицательным");
                            return;
                        }
                    }

                    context.Components.Update(component);
                    await context.SaveChangesAsync();
                }
            }
        }
        public static async Task<DB.Component?> GetComponentByName(string name)
        {
            using(var context = new AcreaContext(DbConst.context))
            {
                int id = await GetComponentIdByName(name);
                return await context.Components.FindAsync(id);
            }
        }

        public static DataTable GetComponentsDataTable(List<DB.Component> components)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Название", typeof(string));
            dataTable.Columns.Add("Количество", typeof(int));
      //      dataTable.Columns.Add("Цена", typeof(double));

            foreach (var component in components)
            {
                DataRow row = dataTable.NewRow();
                row["Название"] = component.Name;
                row["Количество"] = component.Count;
               // row["Цена"] = component.Price;
                dataTable.Rows.Add(row);
            }

            return dataTable;
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

        //Entity: ComponentOrder
        //public static async Task AddComponentToOrder(int orderId, int componentId, int count)
        //{
        //    using (var context = new AcreaContext(DbConst.context))
        //    {
        //        var existingComponentOrder = await context.ComponentOrders.FirstOrDefaultAsync(co => co.OrderId == orderId && co.ComponentId == componentId);
        //        if (existingComponentOrder != null)
        //        {
        //            existingComponentOrder.Count += count;
        //            context.ComponentOrders.Update(existingComponentOrder);
        //        }
        //        else
        //        {
        //            var componentOrder = new DB.ComponentOrder
        //            {
        //                OrderId = orderId,
        //                ComponentId = componentId,
        //                Count = count
        //            };
        //            context.ComponentOrders.Add(componentOrder);
        //        }
        //        await context.SaveChangesAsync();
        //    }
        //}
    }
    
}
