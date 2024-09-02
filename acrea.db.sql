BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Clients" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Clients" PRIMARY KEY AUTOINCREMENT,
    "Phone" TEXT NOT NULL,
    "Name" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "ComponentOrders" (
    "OrderId" INTEGER NOT NULL,
    "ComponentId" INTEGER NOT NULL,
    "Count" INTEGER NOT NULL,
    CONSTRAINT "PK_ComponentOrders" PRIMARY KEY ("OrderId", "ComponentId"),
    CONSTRAINT "FK_ComponentOrders_Components_ComponentId" FOREIGN KEY ("ComponentId") REFERENCES "Components" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_ComponentOrders_Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders" ("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "ComponentTypes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_ComponentTypes" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "Components" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Components" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL,
    "Type" INTEGER NOT NULL,
    "Count" INTEGER NOT NULL,
    "Price" REAL NOT NULL,
    CONSTRAINT "FK_Components_ComponentTypes_Type" FOREIGN KEY ("Type") REFERENCES "ComponentTypes" ("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Orders" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY AUTOINCREMENT,
    "DateStart" TEXT NOT NULL,
    "DateDeadline" TEXT NOT NULL,
    "Client" INTEGER NOT NULL,
    "Device" TEXT NOT NULL,
    "Defect" TEXT NOT NULL,
    "Status" INTEGER NOT NULL,
    "Price" REAL NULL,
    CONSTRAINT "FK_Orders_Clients_Client" FOREIGN KEY ("Client") REFERENCES "Clients" ("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Status" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Status" PRIMARY KEY AUTOINCREMENT,
    "Name" TEXT NOT NULL
);
INSERT INTO "Clients" ("Id","Phone","Name") VALUES (1,'79999999999','Иванов Иван Иванович'),
 (2,'79998887776','Петров Петр Петрович');
INSERT INTO "ComponentTypes" ("Id","Name") VALUES (1,'Резистор'),
 (2,'Конденсатор'),
 (3,'Транзистор'),
 (4,'Диод'),
 (5,'Микросхема'),
 (6,'Индуктивность'),
 (7,'Терморезистор'),
 (8,'Фоторезистор'),
 (9,'Светодиод'),
 (10,'Кнопка'),
 (11,'Переключатель'),
 (12,'Микрофон'),
 (13,'Динамик'),
 (14,'Батарея'),
 (15,'Аккумулятор'),
 (16,'Потенциометр'),
 (17,'Кварцевый резонатор'),
 (18,'Стабилитрон'),
 (19,'Оптрон'),
 (20,'Микроконтроллер'),
 (21,'Разъем'),
 (22,'Стабилизатор напряжения'),
 (23,'Сенсорный экран'),
 (24,'Микросхема памяти'),
 (25,'Термостат'),
 (26,'Дисплей LCD'),
 (27,'Дисплей OLED');
INSERT INTO "Components" ("Id","Name","Type","Count","Price") VALUES (1,'Дисплей Honor 8c',23,0,2330.0);
INSERT INTO "Orders" ("Id","DateStart","DateDeadline","Client","Device","Defect","Status","Price") VALUES (1,'2024-09-02 00:00:00','2024-09-30 00:00:00',2,'Телефон','разбит экран',1,444.0);
INSERT INTO "Status" ("Id","Name") VALUES (1,'Начат'),
 (2,'В Ремонте'),
 (3,'Диагностика'),
 (4,'Ожидание запчастей'),
 (5,'Отказ'),
 (6,'Завершен');
CREATE INDEX "IX_ComponentOrders_ComponentId" ON "ComponentOrders" ("ComponentId");
CREATE INDEX "IX_Components_Type" ON "Components" ("Type");
CREATE INDEX "IX_Orders_Client" ON "Orders" ("Client");
COMMIT;
