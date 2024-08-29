using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using ACREA;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Windows.Forms;


namespace DB
{
    //public static class DataBase
    //{
    //    private const string connectionString = "Data Source=acrea.db;Version=3;";

    //    public static void CreateDataBase(Dictionary<int, string> statusDict)
    //    {
    //        string dbName = "acrea.db";
    //        SQLiteConnection.CreateFile(dbName);
    //        string connectionString = $"Data Source={dbName};Version=3;";
    //        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    //        {
    //            connection.Open();
    //            using (var createDB = new SQLiteCommand(SqlQueries.CreateDB(), connection))
    //                createDB.ExecuteNonQuery();
    //            InsertStatus(statusDict, connection);
    //        }
    //    }
    //    private static void InsertStatus(Dictionary<int, string> statusDict, SQLiteConnection connection)
    //    {
    //        foreach (var item in statusDict)
    //        {
    //            using (var command = new SQLiteCommand(SqlQueries.insertStatus, connection))
    //            {
    //                command.Parameters.AddWithValue("@status_id", item.Key);
    //                command.Parameters.AddWithValue("@status", item.Value);
    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    public static List<PartType> GetPartTypeList()
    //    {
    //        List<PartType> partTypeList = new List<PartType>();
    //        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
    //        {
    //            connection.Open();
    //            using (var command = new SQLiteCommand(SqlQueries.selectPartType, connection))
    //            {

    //                using (SQLiteDataReader reader = command.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        PartType partType = new PartType(reader.GetInt32(0), reader.GetString(1));
    //                        partTypeList.Add(partType);
    //                    }
    //                }
    //            }
    //        }
    //        return partTypeList;
    //    }

    //    public static PartType GetPartType(string type_name)
    //    {
    //        int id = 0;
    //        string type = "";
    //        using (var connect = new SQLiteConnection(connectionString))
    //        {
    //            connect.OpenAsync();
    //            using (var command = new SQLiteCommand(@"SELECT type_id, type FROM PartType WHERE PartType.type = @type", connect))
    //            {
    //                command.Parameters.AddWithValue("@type", type_name);
    //                using (var reader = command.ExecuteReader())
    //                {
    //                    while (reader.Read())
    //                    {
    //                        id = reader.GetInt32(0);
    //                        type = reader.GetString(1);
    //                    }
    //                }
    //            }
    //        }
    //        return new PartType(id, type);
    //    }
    //    public static void InsertPart(ComponentPart componentPart)
    //    {
    //        using (var connect = new SQLiteConnection(connectionString))
    //        {
    //            connect.Open();
    //            using (var command = new SQLiteCommand(DB.SqlQueries.insertPart, connect))
    //            {
    //                command.Parameters.AddWithValue("@name", componentPart.Name);
    //                command.Parameters.AddWithValue("@part_type", componentPart.GetTypeID());
    //                command.Parameters.AddWithValue("@quantity", componentPart.Quantity);
    //                command.Parameters.AddWithValue("@price", componentPart.Price);
    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    public static void UpdatePart(ComponentPart oldPart, ComponentPart newPart)
    //    {
    //        using (var connect = new SQLiteConnection(connectionString))
    //        {
    //            connect.Open();
    //            using (var command = new SQLiteCommand(SqlQueries.updatePart, connect))
    //            {
    //                command.Parameters.AddWithValue("@name", newPart.Name);
    //                command.Parameters.AddWithValue("@type", newPart.GetTypeID().ToString());
    //                command.Parameters.AddWithValue("@quantity", newPart.Quantity.ToString());
    //                command.Parameters.AddWithValue("@price", newPart.Price.ToString());
    //                command.Parameters.AddWithValue("@old_name", oldPart.Name);
    //                command.Parameters.AddWithValue("@old_PType", oldPart.GetTypeID().ToString());
    //                command.Parameters.AddWithValue("@old_quantity", oldPart.Quantity.ToString());
    //                command.Parameters.AddWithValue("@old_price", oldPart.Price.ToString());
    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    public static void DeletePart(string name)
    //    {
    //        using (var connect = new SQLiteConnection(connectionString))
    //        {
    //            connect.Open();
    //            using (var command = new SQLiteCommand(SqlQueries.deletePart, connect))
    //            {
    //                command.Parameters.AddWithValue("@name", name);
    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    public static DataTable GetDataTable(string selectQuery)
    //    {
    //        DataTable table = new DataTable();
    //        //using (var connect = new SQLiteConnection(connectionString))
    //        //{
    //        //    connect.Open();
    //        //    using (var command = new SQLiteCommand(selectQuery, connect))
    //        //    {
    //        //        using (var reader = command.ExecuteReader())
    //        //        {
    //        //            for (int i = 0; i < reader.FieldCount; i++)
    //        //                table.Columns.Add(reader.GetName(i));
    //        //            while (reader.Read())
    //        //            {
    //        //                DataRow row = table.NewRow();
    //        //                for (int i = 0; i < reader.FieldCount; i++)
    //        //                    row[i] = reader.GetValue(i);
    //        //                table.Rows.Add(row);
    //        //            }
    //        //        }
    //        //    }
    //        //}
    //        return table;
    //    }

    //    public static void InsertClient(string name, string phone)
    //    {
    //        using (var connect = new SQLiteConnection(connectionString))
    //        {
    //            connect.Open();
    //            using (var command = new SQLiteCommand(string.Format(DB.SqlQueries.insertClient, name, phone), connect))
    //            {
    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //    public static void UpdateClient(string name, string phone, string oldName, string oldPhone)
    //    {
    //        using (var connect = new SQLiteConnection(connectionString))
    //        {
    //            connect.Open();
    //            using (var command = new SQLiteCommand(string.Format(DB.SqlQueries.updateClient, name, phone, oldName, oldPhone),
    //                connect))
    //            {
    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }

    //    public static void DeleteClient(string name, string phone)
    //    {
    //        using (var connect = new SQLiteConnection(connectionString))
    //        {
    //            connect.Open();
    //            using (var command = new SQLiteCommand(string.Format(DB.SqlQueries.deleteClient, name, phone), connect))
    //            {
    //                command.ExecuteNonQuery();
    //            }
    //        }
    //    }
    //}

    public class SQLiteConfiguration : DbConfiguration
    {
        static SQLiteConfiguration()
        {
            DbConfiguration.SetConfiguration(new SQLiteConfiguration());
        }

        public SQLiteConfiguration()
        {
            SetProviderServices("System.Data.SQLite", System.Data.SQLite.EF6.SQLiteProviderServices.Instance);
        }
    }

    public static class DataBaseContext
    {
        public static void CreateDB(string dbPath)
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);
            Database.SetInitializer(new CreateDatabaseIfNotExists<AcreaContext>());
            //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbPath
            using (var context = new AcreaContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
    []
    public class AcreaContext : DbContext
    {
        public AcreaContext() : base("name=DefaultConnection")
        {
            this.Database.Log = s => System.IO.File.AppendAllText("acrea-log.txt", s);
        }


        public DbSet<Client> Clients { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ComponentOrder> ComponentOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Client>()
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<ComponentType>()
                .HasKey(ct => ct.Id);

            modelBuilder.Entity<Component>()
                .HasKey(c => c.Id)
                .HasRequired(c => c.CComponentType)
                .WithMany()
                .HasForeignKey(c => c.Type);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id)
                .HasRequired(o => o.OClient)
                .WithMany()
                .HasForeignKey(o => o.Client);

            modelBuilder.Entity<ComponentOrder>()
                .HasKey(co => new { co.OrderId, co.ComponentId })
                .HasRequired(co => co.Order)
                .WithMany(o => o.ComponentOrders)
                .HasForeignKey(co => co.OrderId);

            modelBuilder.Entity<ComponentOrder>()
                .HasRequired(co => co.Component)
                .WithMany()
                .HasForeignKey(co => co.ComponentId);
        }
    }
}


    



