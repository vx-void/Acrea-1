using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.IO;

namespace ACREA
{
    public static class Model
    {
        private static Dictionary<int, string> GetStatusDict()
        {
            return new Dictionary<int, string>()
            {
                { 1, "Начат" },
                { 2, "В Ремонте" },
                { 3, "Диагностика" },
                { 4, "Ожидание запчастей" },
                { 5, "Отказ" },
                { 6, "Завершен" }

            };
        }
        public static void DbIsExist()
        {
            //if (File.Exists("acrea.db"))
            //    return;
            //else
            //    //DataBase.CreateDataBase(GetStatusDict());
            DataBaseContext.CreateDB("acrea.db");

        }
        public static Dictionary<int, string> GetPartTypeDict(List<PartType> partTypes)
        {
            Dictionary<int, string> getPartTypeDict = new Dictionary<int, string>();
            foreach(var item in partTypes)
            {
                getPartTypeDict[item.ID] = item.Type;
            }
            return getPartTypeDict;
        }

     
    }
}
