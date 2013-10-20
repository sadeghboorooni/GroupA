using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADVIEWER.DataModel;
using System.Reflection;
using System.Data;


namespace ADVIEWER.Codes
{
    
    public class memberCodes
    {
        public static bool MakeNewAdvertisment( int starCount, String title, String text, String pic, Boolean isActive, String fullName, 
            String email, DateTime expirationDate, DateTime registrationDate, int reviewCount, int advDuration, int userId,string keywordStr)
        {
            ModelContainer ml = new ModelContainer();

            Advertisment newAdv = new Advertisment();
            newAdv.StarCount = starCount;
            newAdv.Title = title;
            newAdv.Text = text;
            newAdv.Pic = pic;
            newAdv.IsActive = isActive;
            newAdv.FullName = fullName;
            newAdv.Email = email;
            newAdv.ExpirationDate = expirationDate;
            newAdv.RegistrationDate = registrationDate;
            newAdv.ReviewCount = reviewCount;
            newAdv.AdvDuration = advDuration;
            newAdv.UserId = userId;
            foreach (int kwId in memberCodes.ParseKeyWords(keywordStr))
            {
                KeyWord tempkw = ml.KeyWords.Where(t => t.Id == kwId).First();
                newAdv.KeyWords.Add(tempkw);
            }

            ml.Advertisments.AddObject(newAdv);
            try
            {
                ml.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int[] ParseKeyWords(string keywordStr) 
        {
            List<int> kwList = new List<int>();
            ModelContainer ml = new ModelContainer();

            foreach (string kwStr in keywordStr.Split(',')) 
            {
                try
                {
                    int id = int.Parse(kwStr);
                    if (ml.KeyWords.Where(t => t.Id == id).Count() > 0) 
                    {
                        kwList.Add(ml.KeyWords.Where(t => t.Id == id).Select(t => t.Id).First());
                    }
                }
                catch 
                {
                    KeyWord newkw = new KeyWord();
                    newkw.Text = kwStr;
                    ml.KeyWords.AddObject(newkw);
                    ml.SaveChanges();
                    kwList.Add(newkw.Id);
                }
                
            }

            return kwList.ToArray();
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            FieldInfo[] Props = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo prop in Props)
            {

                //Setting column names as Property names
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
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static DataTable unconfirmedFreeAdvertismentsDataTable() 
        {
            ModelContainer ml = new ModelContainer();

            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => t.IsConfirmed == false && t.IsRead == false && t.StarCount == -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.Description, adv.FullName, adv.Pic, adv.RegistrationDate,adv.UserId));
            }

            return ToDataTable<ShowAdvertisment>(unreadList);
        }
        public static void ConfirmAdvertisment(int AdvID) 
        {
            ModelContainer ml = new ModelContainer();
            Advertisment adv = ml.Advertisments.Where(t => t.ID == AdvID).FirstOrDefault();
            if (adv.StarCount == -1) 
            {
                adv.IsRead = true;
                adv.IsConfirmed = true;
                ml.SaveChanges();
            }
        }
        public static void DenyAdvertisment(int AdvID, string reason)
        {
            ModelContainer ml = new ModelContainer();
            Advertisment adv = ml.Advertisments.Where(t => t.ID == AdvID).FirstOrDefault();
            if (adv.StarCount == -1)
            {
                adv.IsRead = true;
                adv.IsConfirmed = false;
                adv.DenyReason = reason;
                ml.SaveChanges();
            }
        }

        public static Advertisment GetAdvertismentInformation(int id)
        {
            ModelContainer ml = new ModelContainer();
            return ml.Advertisments.Where(t => t.ID == id).FirstOrDefault();
        }
    }
    public class ShowAdvertisment 
    {
        public string Description,
            FullName,
            Title,
            Pic;
        public int ID,UserId;
        public DateTime RegistrationDate;

        public ShowAdvertisment(int ID,
            string Title,
            string Description,
            string FullName,
            string Pic,
            DateTime RegistrationDate,
            int UserId) 
        {
            this.ID = ID;
            this.FullName = FullName;
            this.Description = Description;
            this.Pic = Pic;
            this.RegistrationDate = RegistrationDate;
            this.Title = Title;
            this.UserId = UserId;
        }
    }
}