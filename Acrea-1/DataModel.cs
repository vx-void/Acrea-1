using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Xml.Linq;

namespace ACREA
{
    public static partial class DataModel
    {

        //public static async void InsertStatuses() => await DataBaseContext.InsertStatuses(GetStatusDict()); 
        public static async void DbIsExist()
        {
            if (!File.Exists(DbConst.db))
                await CreateDB();
        }
        private static async Task CreateDB()
        {
            using (var context = new AcreaContext(DbConst.context))
            {
                await context.Database.EnsureCreatedAsync();
                foreach (var item in DbConst.statusDict)
                {
                    var status = new Status(item.Key, item.Value);
                    context.Status.Add(status);
                    context.SaveChanges();
                }
                foreach (var item in DbConst.componentTypeDict)
                {
                    var componentType = new ComponentType(item.Key, item.Value);
                    context.ComponentTypes.Add(componentType);
                    context.SaveChanges();
                }

            }

        }
        
        //Entity: status
        public static int GetStatusByName(string status)
        {
            Dictionary<string, int> reverseStatusDict = DbConst.statusDict
           .Reverse()
           .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
            return reverseStatusDict[status];
        }

        public static string GetStatusById(int id)
        {
            string status = "";
            using (var context = new AcreaContext(DbConst.context))
            {
                status = context.Status.Where(c => c.Id == id)
                     .Select(c => c.Name)
                     .FirstOrDefault();
            }

            return status;
        }



    }
}
