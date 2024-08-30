using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public static class DbConst
    {
        public static string db = "acrea.db";

        public static Dictionary<int, string > statusDict = new Dictionary<int, string>()
            {
                { 1, "Начат" },
                { 2, "В Ремонте" },
                { 3, "Диагностика" },
                { 4, "Ожидание запчастей" },
                { 5, "Отказ" },
                { 6, "Завершен" }

            };

        public static Dictionary<int, string>  componentTypeDict = new Dictionary<int, string>()
        {
            { 1, "Резистор" },
            { 2, "Конденсатор" },
            { 3, "Транзистор" },
            { 4, "Диод" },
            { 5, "Микросхема" },
            { 6, "Индуктивность" },
            { 7, "Терморезистор" },
            { 8, "Фоторезистор" },
            { 9, "Светодиод" },
            { 10, "Кнопка" },
            { 11, "Переключатель" },
            { 12, "Микрофон" },
            { 13, "Динамик" },
            { 14, "Батарея" },
            { 15, "Аккумулятор" },
            { 16, "Потенциометр" },
            { 17, "Кварцевый резонатор" },
            { 18, "Стабилитрон" },
            { 19, "Оптрон" },
            { 20, "Микроконтроллер" },
            { 21, "Разъем" },
            { 22, "Стабилизатор напряжения" },
            { 23, "Сенсорный экран" },
            { 24, "Микросхема памяти" },
            { 25, "Термостат" },
            { 26, "Дисплей LCD" },
            { 27, "Дисплей OLED" }
        };

        public static DbContextOptions<AcreaContext> context = new DbContextOptionsBuilder<AcreaContext>()
                         .UseSqlite($"Data Source={db.ToString()};")
                         .Options;
    }
}
