using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ACREA;
using System.Security.Authentication;

namespace DB
{
    public class Client
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }

        public Client(string name, string phone)
        {
            Id = Model.SetClientId();
            Name = name;
            Phone = phone;     
        }
        public Client(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
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

        //[ForeignKey("Type")]
        public virtual ComponentType CComponentType { get; set; }
    }

    public class Order
    {
        public Order()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateDeadline { get; set; }
        public int Client { get; set; }
        public string Device { get; set; }
        public string Defect { get; set; }
        public int Status { get; set; }
        public double? Price { get; set; }
        //[ForeignKey("Client")]
        public virtual Client OClient { get; set; }
        //[ForeignKey("ComponentOrders")]
        public virtual ICollection<ComponentOrder> ComponentOrders { get; set; }
    }

    public class ComponentOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int ComponentId { get; set; }
        public int Count { get; set; }

        //[ForeignKey("Order")]
        public virtual Order Order { get; set; }
        //[ForeignKey("Component")]
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
