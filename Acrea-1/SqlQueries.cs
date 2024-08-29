using ACREA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;
using static System.Net.Mime.MediaTypeNames;

namespace DB
{
    public static class SqlQueries
    {
        public static string CreateDB()
        {
            return "CREATE TABLE \"Client\"(\"client_id\" INTEGER NOT NULL, \"name\" TEXT NOT NULL, \"phone\" TEXT," +
                   "PRIMARY KEY(\"client_id\" AUTOINCREMENT));" +

                   "CREATE TABLE \"PartType\"(\"type_id\" INTEGER NOT NULL, \"type\" TEXT NOT NULL UNIQUE," +
                   "PRIMARY KEY(\"type_id\" AUTOINCREMENT));" +

                   "CREATE TABLE \"Part\"(\"part_id\" INTEGER NOT NULL, \"name\" TEXT NOT NULL, \"part_type\" INTEGER NOT NULL, " +
                   "\"quantity\"  INTEGER NOT NULL, \"price\" REAL NOT NULL, PRIMARY KEY(\"part_id\" AUTOINCREMENT)," +
                   "FOREIGN KEY(\"part_type\") REFERENCES \"PartType\"(\"type_id\"));" +

                   "CREATE TABLE \"Status\"(\"status_id\" INTEGER NOT NULL,\"status\" TEXT NOT NULL UNIQUE, " +
                   "PRIMARY KEY(\"status_id\" AUTOINCREMENT));" +

                   "CREATE TABLE \"Order\"(\"order_id\" INTEGER NOT NULL, \"client\" INTEGER NOT NULL,\"device\" TEXT NOT NULL," +
                   "\"defect\" TEXT,\"work\" TEXT,\"date_start\" REAL NOT NULL,\"date_end\" REAL NOT NULL,\"status\" INTEGER NOT NULL," +
                   "\"price\" REAL NOT NULL, " +
                   "PRIMARY KEY(\"order_id\" AUTOINCREMENT), " +
                   "FOREIGN KEY(\"client\") REFERENCES \"Client\"(\"client_id\")," +
                   "FOREIGN KEY(\"status\") REFERENCES \"Status\"(\"status_id\"));" +

                   "CREATE TABLE \"OrderPart\"(\"order_id\" INTEGER NOT NULL,\"part_id\" INTEGER NOT NULL, \"count\" INTEGER DEFAULT 0," +
                   "FOREIGN KEY(\"order_id\") REFERENCES \"Order\"(\"order_id\")," +
                   "FOREIGN KEY(\"part_id\") REFERENCES \"Part\"(\"part_id\"));";
        }

        public const string insertStatus = @"INSERT INTO Status (status_id, status ) VALUES
                                                                    (@status_id, @status)";

        public const string updateComponent = @"UPDATE Part
                                                        SET
                                                        part_type = @part_type,
                                                        quantity = @quantity,
                                                        price = quantity
                                                        WHERE
                                                        name = @name;"
        ;

        public const string deleteComponent = "DELETE FROM Part WHERE id = @id";

        public const string selectPartType = "select type_id, type from PartType";

        public const string insertPart = @"INSERT INTO Part(name, part_type, quantity, price)
                                            VALUES
                                            (@name, 
                                            @part_type,
                                            @quantity,
                                            @price           
                                            );";

        public const string selectPart = @"SELECT 
                                           name AS 'Наименование', 
                                           PartType.type AS 'Тип компонента', 
                                           quantity AS 'Количество', 
                                           price AS 'Стоимость'  
                                           FROM 
                                           Part 
                                           JOIN PartType ON Part.part_type = PartType.type_id";
     
        public const string updatePart = @"UPDATE Part
                                           SET
                                            name = @name,
                                            part_type = @type,
                                            quantity = @quantity,
                                            price = @price
                                            WHERE
                                            part_id = 
                                                (
                                                SELECT part_id
                                                FROM Part
                                                WHERE
                                                name = @old_name AND
                                                part_type = @old_PType AND
                                                quantity = @old_quantity AND
                                                price = @old_price
                                                LIMIT 1
                                                 );";

        public const string selectPartID = @"SELECT 
                                                part_id 
                                             FROM 
                                                Part 
                                             WHERE 
                                                part_type = @type
                                             AND
	                                            name = @name;";

        public const string selectPartByID = @"SELECT name, part_type, quantity, price FROM Part WHERE part_id = @id";

        public const string deletePart = @"DELETE FROM Part WHERE name = @name";

        public const string selectClient = @"SELECT client_id AS '#ID', name AS 'ФИО', phone AS 'Контактный телефон' FROM Client";

        public const string insertClient = @"INSERT INTO Client(name, phone) VALUES('{0}', '{1}')";

        public const string updateClient = @"UPDATE Client SET name = '{0}', phone = '{1' WHERE client_id = (SELECT client_id FROM Client WHERE name = '{2}' AND phone = '{3}')";

        public const string deleteClient = @"DELETE FROM Client WHERE client_id = (SELECT client_id FROM Client WHERE name = '{0}' AND phone = '{1}')";
    }




}
