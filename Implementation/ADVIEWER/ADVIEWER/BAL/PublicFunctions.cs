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
            if (ml.StateCities.Where(t => t.Id == ID).First().StateId == null)
            {
                return (from adv in ml.Advertisments
                        where (adv.StateCityID == ID || adv.StateCityID == (from st in ml.StateCities where st.StateId == ID select st.Id).FirstOrDefault()) && adv.IsConfirmed == true 
                        select adv).ToArray();

            }
            else
                return ml.Advertisments.Where(t => t.StateCityID == ID && t.IsConfirmed == true).ToArray();
        }
        public static List<StateAndCitiesForReapeater> GetStatesWithCities()
        {
            ModelContainer ml = new ModelContainer();
            List<StateCity> AllState = ml.StateCities.Where(t=> t.StateId == null).ToList();
            List<StateAndCitiesForReapeater> ReturnListOfClasses = new List<StateAndCitiesForReapeater>();
            foreach(StateCity AS in AllState){
                StateAndCitiesForReapeater Temp = new StateAndCitiesForReapeater(AS.Id);
                ReturnListOfClasses.Add(Temp);
            }
            return ReturnListOfClasses;
        }
    }

    public class StateAndCitiesForReapeater
    {
        private int Id;

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private StateCity[] cities;

        public StateCity[] Cities
        {
            get { return cities; }
            set { cities = value; }
        }

        public StateAndCitiesForReapeater(int ID)
        {
            ModelContainer ml = new ModelContainer();
            this.ID = ID;
            this.Name = ml.StateCities.Where(t => t.Id == ID).First().Name;
            SetCities();
        }

        private void SetCities()
        {
            ModelContainer ml = new ModelContainer();
            Cities = ml.StateCities.Where(t => t.StateId == this.ID).ToArray();
        }
    }
}   