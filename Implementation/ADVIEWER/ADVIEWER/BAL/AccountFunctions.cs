using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ADVIEWER.DAL;

namespace ADVIEWER.BAL
{
    public class AccountFunctions
    {
        public static bool newUser(Guid UserId,string UserFullName, string mail) 
        {
            try
            {
                ModelContainer ml = new ModelContainer();
                User newUser = new User();
                newUser.LastLogin = DateTime.Now;
                newUser.RegisterDate = DateTime.Now;
                newUser.FullName = UserFullName;
                newUser.UserProviderKey = UserId;
                newUser.Mail = mail;
                ml.Users.AddObject(newUser);
                ml.SaveChanges();
                return true;
            }
            catch 
            {
                Membership.DeleteUser(Membership.GetUser(UserId).UserName);
                return false;
            }
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

        public static void UpdateUserInfo(Int32 id, String fullName,String about ,String address,String fax ,String mobile,String tell, String yahooId)
        {
            ModelContainer ml = new ModelContainer();
            User user = ml.Users.Where(t => t.ID == id).FirstOrDefault();
            user.FullName = fullName;
            user.About = about;
            user.Address = address;
            user.Fax = fax;
            user.Mobile = mobile;
            user.Tell = tell;
            user.YahooID = yahooId;
            ml.SaveChanges();
        }

        

    }
}