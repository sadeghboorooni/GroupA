using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ADVIEWER.DataModel;

namespace ADVIEWER.Codes
{
    public class AccountCodes
    {
        public static void newUser(Guid UserId,string UserFullName) 
        {
            MembershipUser mu = Membership.GetUser(UserId);
            ModelContainer ml = new ModelContainer();
            User newUser = new User();
            newUser.LastLogin = DateTime.Now;
            newUser.RegisterDate = DateTime.Now;
            newUser.FullName = UserFullName;
            newUser.UserProviderKey = UserId;
            ml.Users.AddObject(newUser);
            ml.SaveChanges();
        }

        public static void loginUser(Guid UserId) 
        {
            ModelContainer ml = new ModelContainer();
            ml.Users.Where(t => t.UserProviderKey == UserId).FirstOrDefault().LastLogin = DateTime.Now;
            ml.SaveChanges();
        }

        public static int currentUserId() 
        {
            ModelContainer ml = new ModelContainer();
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            return ml.Users.Where(t => t.UserProviderKey == userGuid).Select(t => t.ID).FirstOrDefault();
        }

        public static User GetUserInformation(int UserID)
        {
            ModelContainer ml = new ModelContainer();
            return ml.Users.Where(a => a.ID == UserID).FirstOrDefault();
        }

        public static Advertisment[] GetUserAdvs (int UserID)
        {
            ModelContainer ml = new ModelContainer();
            return ml.Users.Where(a => a.ID == UserID).FirstOrDefault().Advertisments.ToArray();
        }

    }
}