using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ADVIEWER.DAL;

namespace ADVIEWER.BAL
{
    //! AccountFunctions
    /*!
     this class represents the functions for work with membership.
     */
    public class AccountFunctions
    {

        //! newUser
        /*!
         make new user in both databases.
         */
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

        //! SetLastLogin
        /*!
         set last login property of user class when specific user loged in.
         */
        public static void SetLastLogin(Guid UserId) 
        {
            ModelContainer ml = new ModelContainer();
            ml.Users.Where(t => t.UserProviderKey == UserId).FirstOrDefault().LastLogin = DateTime.Now;
            ml.SaveChanges();
        }

        //! currentUserId
        /*!
         return the id of logged in user. return -1 if no user logged in.
         */
        public static int currentUserId() 
        {
            ModelContainer ml = new ModelContainer();
            if (Membership.GetUser() == null) return -1;
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            return ml.Users.Where(t => t.UserProviderKey == userGuid).Select(t => t.ID).FirstOrDefault();
        }

        //! GetUserInformation
        /*!
         return the data of specific user that its id passed to this function.
         */
        public static AssignorUser GetUserInformation(int UserID)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<User,AssignorUser>(ml.Users.Where(a => a.ID == UserID).FirstOrDefault());
        }

        //! UpdateUserInfo
        /*!
         update datas of specific user with fields that passed to it. 
         */
        public static void UpdateUserInfo(Int32 id, String fullName,String about ,String address,String fax ,String mobile,String tell, String yahooId,String favgroups)
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
            List<string> Groups = favgroups.Split(',').ToList();
            user.Groups.Clear();

            
                foreach (string grid in Groups)
                {
                    if (grid != "")
                    {
                        int GroupId = int.Parse(grid);
                        Group TempGroup = ml.Groups.Where(t => t.ID == GroupId).FirstOrDefault();
                        user.Groups.Add(TempGroup);
                    }
                }
            ml.SaveChanges();
        }

        //! IsManager
        /*!
         if logged in user is manager return true, otherwise return false.  
         */
        public static bool IsManager()
        {
            ModelContainer ml = new ModelContainer();
            Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
            return ml.Users.Where(t => t.UserProviderKey == userGuid).Select(t => t.IsManager).FirstOrDefault();
        }
    }
}