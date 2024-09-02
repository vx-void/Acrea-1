BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Clients" (
	"Id"	INTEGER NOT NULL,
	"Phone"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_Clients" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ComponentTypes" (
	"Id"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_ComponentTypes" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Status" (
	"Id"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_Status" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Orders" (
	"Id"	INTEGER NOT NULL,
	"DateStart"	TEXT NOT NULL,
	"DateDeadline"	TEXT,
	"Client"	INTEGER NOT NULL,
	"Device"	TEXT NOT NULL,
	"Defect"	TEXT NOT NULL,
	"Status"	INTEGER NOT NULL,
	"Price"	REAL,
	CONSTRAINT "FK_Orders_Clients_Client" FOREIGN KEY("Client") REFERENCES "Clients"("Id") ON DELETE CASCADE,
	CONSTRAINT "PK_Orders" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "Components" (
	"Id"	INTEGER NOT NULL,
	"Name"	TEXT NOT NULL,
	"Type"	INTEGER NOT NULL,
	"Count"	INTEGER NOT NULL,
	"Price"	REAL NOT NULL,
	CONSTRAINT "FK_Components_ComponentTypes_Type" FOREIGN KEY("Type") REFERENCES "ComponentTypes"("Id") ON DELETE CASCADE,
	CONSTRAINT "PK_Components" PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "ComponentOrders" (
	"OrderId"	INTEGER NOT NULL,
	"ComponentId"	INTEGER NOT NULL,
	"Count"	INTEGER NOT NULL,
	CONSTRAINT "FK_ComponentOrders_Components_ComponentId" FOREIGN KEY("ComponentId") REFERENCES "Components"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_ComponentOrders_Orders_OrderId" FOREIGN KEY("OrderId") REFERENCES "Orders"("Id") ON DELETE CASCADE,
	CONSTRAINT "PK_ComponentOrders" PRIMARY KEY("OrderId","ComponentId")
);
INSERT INTO "Clients" VALUES (1,'+79999999999','Иванов Иван Иванович');
INSERT INTO "Clients" VALUES (2,'+7888888888','Петров Петр Петрович');
INSERT INTO "Clients" VALUES (3,'4534534534534','Смиронов А О');
INSERT INTO "Clients" VALUES (4,'345645756786','Андрееев Андрей Андреевич');
INSERT INTO "ComponentTypes" VALUES (1,'Резистор');
INSERT INTO "ComponentTypes" VALUES (2,'Конденсатор');
INSERT INTO "ComponentTypes" VALUES (3,'Транзистор');
INSERT INTO "ComponentTypes" VALUES (4,'Диод');
INSERT INTO "ComponentTypes" VALUES (5,'Микросхема');
INSERT INTO "ComponentTypes" VALUES (6,'Индуктивность');
INSERT INTO "ComponentTypes" VALUES (7,'Терморезистор');
INSERT INTO "ComponentTypes" VALUES (8,'Фоторезистор');
INSERT INTO "ComponentTypes" VALUES (9,'Светодиод');
INSERT INTO "ComponentTypes" VALUES (10,'Кнопка');
INSERT INTO "ComponentTypes" VALUES (11,'Переключатель');
INSERT INTO "ComponentTypes" VALUES (12,'Микрофон');
INSERT INTO "ComponentTypes" VALUES (13,'Динамик');
INSERT INTO "ComponentTypes" VALUES (14,'Батарея');
INSERT INTO "ComponentTypes" VALUES (15,'Аккумулятор');
INSERT INTO "ComponentTypes" VALUES (16,'Потенциометр');
INSERT INTO "ComponentTypes" VALUES (17,'Кварцевый резонатор');
INSERT INTO "ComponentTypes" VALUES (18,'Стабилитрон');
INSERT INTO "ComponentTypes" VALUES (19,'Оптрон');
INSERT INTO "ComponentTypes" VALUES (20,'Микроконтроллер');
INSERT INTO "ComponentTypes" VALUES (21,'Разъем');
INSERT INTO "ComponentTypes" VALUES (22,'Стабилизатор напряжения');
INSERT INTO "ComponentTypes" VALUES (23,'Сенсорный экран');
INSERT INTO "ComponentTypes" VALUES (24,'Микросхема памяти');
INSERT INTO "ComponentTypes" VALUES (25,'Термостат');
INSERT INTO "ComponentTypes" VALUES (26,'Дисплей LCD');
INSERT INTO "ComponentTypes" VALUES (27,'Дисплей OLED');
INSERT INTO "Status" VALUES (1,'Начат');
INSERT INTO "Status" VALUES (2,'В Ремонте');
INSERT INTO "Status" VALUES (3,'Диагностика');
INSERT INTO "Status" VALUES (4,'Ожидание запчастей');
INSERT INTO "Status" VALUES (5,'Отказ');
INSERT INTO "Status" VALUES (6,'Завершен');
INSERT INTO "Orders" VALUES (1,'2024-09-01 19:45:04.9014545','2024-09-19 19:45:04.886',3,'gtwertwer','dfgdfger',1,444.0);
INSERT INTO "Orders" VALUES (2,'2024-09-01 00:00:00','2024-09-29 00:00:00',4,'Телефон','разбит экран',2,1000.0);
INSERT INTO "Components" VALUES (1,'тачскрин Honor 8C',23,2,2330.0);
CREATE INDEX IF NOT EXISTS "IX_ComponentOrders_ComponentId" ON "ComponentOrders" (
	"ComponentId"
);
CREATE INDEX IF NOT EXISTS "IX_Components_Type" ON "Components" (
	"Type"
);
CREATE INDEX IF NOT EXISTS "IX_Orders_Client" ON "Orders" (
	"Client"
);
COMMIT;
