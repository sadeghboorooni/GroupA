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
            ml.Users.AddObject(newUser);
            ml.SaveChanges();
        }

        public static void loginUser(Guid UserId) 
        {
            throw new NotImplementedException();
        }
    }
}