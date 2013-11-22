using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using ADVIEWER.DAL;

namespace ADVIEWER.BAL
{
    public class PublicFunctions
    {

        public static Advertisment[] GetLast9Advs() 
        {
            ModelContainer ml = new ModelContainer();
            return ml.Advertisments.Where(t=>t.IsConfirmed).OrderByDescending(t => t.RegistrationDate).Take(9).ToArray();
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            FieldInfo[] Props = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo prop in Props)
            {
                //Setting column names as Property names _solved_ and columnType
                dataTable.Columns.Add(prop.Name, prop.FieldType);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        internal static Single GetAdvAverageRate(int AdvId)
        {
            ModelContainer ml = new ModelContainer();
            var r = ml.Rates.Where(t => t.AdvertismentId == AdvId).Average(t => t.Value);

            Single result = r == null ? 0 : (Single)r;
            return result;
        }
    }
}