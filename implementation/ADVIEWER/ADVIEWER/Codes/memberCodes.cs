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
    }
}