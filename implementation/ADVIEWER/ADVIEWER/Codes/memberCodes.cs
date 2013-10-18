using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADVIEWER.DataModel;


namespace ADVIEWER.DataModel
{
    public partial class Advertisment 
    {
        public static Advertisment InsertAvertisment(global::System.Int32 id, global::System.Int32 starCount, global::System.String title, global::System.String text, global::System.String pic, global::System.Boolean isActive, global::System.String fullName, global::System.String email, global::System.DateTime expirationDate, global::System.DateTime registrationDate, global::System.Int32 reviewCount, global::System.Int32 advDuration, global::System.Int32 userId)
        {
            Advertisment advertisment = new Advertisment();
            advertisment.ID = id;
            advertisment.StarCount = starCount;
            advertisment.Title = title;
            advertisment.Text = text;
            advertisment.Pic = pic;
            advertisment.IsActive = isActive;
            advertisment.FullName = fullName;
            advertisment.Email = email;
            advertisment.ExpirationDate = expirationDate;
            advertisment.RegistrationDate = registrationDate;
            advertisment.ReviewCount = reviewCount;
            advertisment.AdvDuration = advDuration;
            advertisment.UserId = userId;
            return advertisment;
        }
    }
}


namespace ADVIEWER.Codes
{
    
    public class memberCodes
    {
        public static bool MakeNewAdvertisment(Advertisment newadv)
        {
            
            ModelContainer ml = new ModelContainer();
            ml.Advertisments.AddObject(newadv);
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

        public static KeyWord[] ParseKeyWords(string keywordStr) 
        {
            List<KeyWord> kwList = new List<KeyWord>();
            ModelContainer ml = new ModelContainer();

            foreach (string kwStr in keywordStr.Split(',')) 
            {
                try
                {
                    int id = int.Parse(kwStr);
                    if (ml.KeyWords.Where(t => t.Id == id).Count() > 0) 
                    {
                        kwList.Add(ml.KeyWords.Where(t => t.Id == id).First());
                    }
                }
                catch 
                {
                    KeyWord newkw = new KeyWord();
                    newkw.Text = kwStr;
                    ml.KeyWords.AddObject(newkw);
                    ml.SaveChanges();
                    kwList.Add(newkw);
                }
                
            }

            return kwList.ToArray();
        }
    }
}