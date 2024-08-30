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


        //public static async void InsertStatuses() => await DataBaseContext.InsertStatuses(GetStatusDict()); 
        public async static void DbIsExist(string dbPath = "acrea.db")
        {
            if(!File.Exists(dbPath))
                await DataBaseContext.CreateDB(dbPath);
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
