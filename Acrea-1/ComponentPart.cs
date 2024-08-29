using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACREA
{
    public class PartType
    {
        public int ID { get; set; }
        public string Type { get; set; }

        public PartType(int id, string type)
        {
            ID = id;
            Type = type;
        }
        public PartType()
        {
            
        }

        public (int, string) GetPartInfo()
        {
            return (ID, Type);
        }

        public string GetType() => this.Type;

        public int GetID() => this.ID;
    }



    public class ComponentPart
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PartType PType { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public ComponentPart(string name, PartType type, int quantity, double price, int id)
        {
            this.ID = id;
            this.Name = name;
            this.PType = type;
            this.Quantity = quantity;
            this.Price = price;
        }

        public ComponentPart()
        {

        }

        public (int, string, string, int, double) GetComponentPartInfo()
        {
            return (this.ID, this.Name, this.PType.GetPartInfo().Item2, this.Quantity, this.Price);
        }

        public void SetID(int id)
        {
            this.ID = id;
        }

        public string GetName() => this.Name.ToString();

        public int GetID() => this.ID;

        public string GetType() => this.PType.GetType().ToString();

        public int GetTypeID() => this.PType.GetID();

        public int GetQuantity() => this.Quantity;  

        public double GetPrice() => this.Price; 
           
        
        
    }
}
