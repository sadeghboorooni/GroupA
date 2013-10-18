using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADVIEWER.DataModel;


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
    }
}