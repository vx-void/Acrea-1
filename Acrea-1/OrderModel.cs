using DB;
using Microsoft.EntityFrameworkCore;
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
    public static partial class DataModel
    {
        //Entity: Order
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
                    row["Статус"] = DataModel.GetStatusById(order.Status);
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

        public static int GetNextOrderId()
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
        public static async Task AddComponentToOrder(int orderId, int componentId)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var order = await context.Set<Order>().FirstOrDefaultAsync(o => o.Id == orderId);
                        var component = await context.Set<Component>().FirstOrDefaultAsync(c => c.Id == componentId);

                        if (order == null)
                        {
                            throw new InvalidOperationException($"Order with ID {orderId} not found.");
                        }

                        if (component == null)
                        {
                            throw new InvalidOperationException($"Component with ID {componentId} not found.");
                        }

                        if (component.Count <= 0)
                        {
                            throw new InvalidOperationException($"Component {component.Name} is out of stock.");
                        }

                        var componentOrder = new ComponentOrder
                        {
                            OrderId = orderId,
                            ComponentId = componentId,
                            Count = 1
                        };

                        context.Set<ComponentOrder>().Add(componentOrder);

                        order.Price += component.Price;
                        component.Count -= 1;

                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        //        public static async Task AddComponentToOrder(int orderId, int componentId)
        //{
        //    using (var context = new AcreaContext(DbConst.context))
        //    {
        //        using (var transaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var order = await context.Set<Order>().FirstOrDefaultAsync(o => o.Id == orderId);
        //                var component = await context.Set<Component>().FirstOrDefaultAsync(c => c.Id == componentId);

        //                if (order == null)
        //                {
        //                    throw new InvalidOperationException($"Order with ID {orderId} not found.");
        //                }

        //                if (component == null)
        //                {
        //                    throw new InvalidOperationException($"Component with ID {componentId} not found.");
        //                }

        //                if (component.Count <= 0)
        //                {
        //                    throw new InvalidOperationException($"Component {component.Name} is out of stock.");
        //                }

        //                var componentOrder = new ComponentOrder
        //                {
        //                    OrderId = orderId,
        //                    ComponentId = componentId,
        //                    Count = 1
        //                };

        //                context.Set<ComponentOrder>().Add(componentOrder);

        //                order.Price += component.Price;
        //                component.Count -= 1;

        //                await context.SaveChangesAsync();
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}

        public static void RemoveComponentFromOrder(int orderId, int componentId)
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var componentOrder = context.Set<ComponentOrder>().FirstOrDefault(co => co.OrderId == orderId && co.ComponentId == componentId);
                        if (componentOrder != null)
                        {
                            context.Set<ComponentOrder>().Remove(componentOrder);
                            var order = context.Set<Order>().Find(orderId);
                            var component = context.Set<Component>().Find(componentId);
                            if (order != null && component != null)
                            {
                                order.Price -= component.Price;
                                component.Count += 1;
                            }
                            context.SaveChanges();
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static DataTable GetComponentOrderDataTable(int orderId)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Наименование", typeof(string));
            table.Columns.Add("Количество", typeof(int));
            using (var context = new AcreaContext(DbConst.context))
            {
                var componentOrders = context.Set<ComponentOrder>()
                    .Where(co => co.OrderId == orderId)
                    .ToList();
                //if (componentOrders.Count == 0)
                //{
                //    var newComponentOrder = new ComponentOrder
                //    {
                //        OrderId = orderId,
                //        ComponentId = 0,
                //        Count = 0
                //    };
                //    context.Set<ComponentOrder>().Add(newComponentOrder);
                //    context.SaveChanges();
                //    componentOrders.Add(newComponentOrder);
                //}
                if (componentOrders.Count == 0)
                {
                    return table; 
                }
                foreach (var componentOrder in componentOrders)
                {
                    var component = context.Set<Component>().Find(componentOrder.ComponentId);
                    if (component != null)
                    {
                        table.Rows.Add(component.Name, componentOrder.Count);
                    }
                    else
                    {
                        table.Rows.Add("Неизвестный компонент", componentOrder.Count);
                    }
                }
            }
            return table;
        }
    }
}
