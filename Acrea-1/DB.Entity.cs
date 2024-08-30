using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DB
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Phone { get; set; }
        public string Name { get; set; }
    }

    public class ComponentType
    {
        public ComponentType(int id, string name)
        {
            Id = id;
            Name = name;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Component
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public virtual ComponentType CComponentType { get; set; }
    }

    public class Order
    {
        public Order()
        {
            ComponentOrders = new List<ComponentOrder>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }
        public virtual Order Order { get; set; }
        public virtual Component Component { get; set; }
    }

    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
