using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Client
    {
        
        public int Id { get; set; }
        public int Phone { get; set; }
        public string Name { get; set; }
    }

    public class ComponentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public virtual ComponentType CComponentType { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public double DateStart { get; set; }
        public double? DateDeadline { get; set; }
        public int Client { get; set; }
        public string Device { get; set; }
        public int Status { get; set; }
        public double? Price { get; set; }

        public virtual Client OClient { get; set; }
        public virtual ICollection<ComponentOrder> ComponentOrders { get; set; }
    }

    public class ComponentOrder
    {
        public int OrderId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
        public virtual Order Order { get; set; }
        public virtual Component Component { get; set; }
    }

    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
