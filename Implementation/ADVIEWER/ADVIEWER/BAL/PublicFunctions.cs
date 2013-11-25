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

            Single result = 0;

            if (ml.Rates.Where(t => t.AdvertismentId == AdvId).Count() > 0)
            {
                result = (Single)ml.Rates.Where(t => t.AdvertismentId == AdvId).Average(t => t.Value);
            }
            return result;
        }

        public static StateCity[] GetStatesAndCities()
        {
            ModelContainer ml = new ModelContainer();
            return ml.StateCities.Where(t => t.StateId == null).ToArray();
        }

        public static Advertisment[] GetAdvByStateID(int ID)
        {
            ModelContainer ml = new ModelContainer();
            StateCity[] AllCitiesFromState = ml.StateCities.Where(t => t.StateId == ID || t.Id == ID).ToArray();
            List<Advertisment> AllCitiesAdvs = new List<Advertisment>();
            List<Advertisment> ReturnAllCitiesAdvs = new List<Advertisment>();
            foreach (StateCity Cities in AllCitiesFromState)
            {
                AllCitiesAdvs = ml.Advertisments.Where(t => t.StateCityID == Cities.Id && t.IsConfirmed == true).ToList();
                foreach (Advertisment ReturnAdv in AllCitiesAdvs)
                {
                    ReturnAllCitiesAdvs.Add(ReturnAdv);
                }
                AllCitiesAdvs.Clear();
            }
            return ReturnAllCitiesAdvs.ToArray();
            
        }
    }
}