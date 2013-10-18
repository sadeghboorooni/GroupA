using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADVIEWER.DataModel;

namespace ADVIEWER.Codes
{
    public class memberCodes
    {
        public static bool MakeNewAdvertisment(Advetisement newadv)
        {
            
            ModelContainer ml = new ModelContainer();
            ml.Advetisements.AddObject(newadv);
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