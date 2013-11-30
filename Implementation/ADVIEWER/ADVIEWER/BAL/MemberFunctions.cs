using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADVIEWER.DAL;
using System.Reflection;
using System.Data;
using System.IO;


namespace ADVIEWER.BAL
{

    public class MemberFunctions
    {
        public static bool MakeNewAdvertisment(int starCount, int advDuration, string title, string shortdescription, string description,
            string keywordStr, string price, string link, string fullName, string mobile, string tell, string telltime,
            string email, string yahooid, string address, int userId, string tempAdd, string mainAdd, string fileName, int groupId,int StateCityID)
        {
            ModelContainer ml = new ModelContainer();

            Advertisment newAdv = new Advertisment();

            newAdv.UserId = userId;
            newAdv.StarCount = starCount;
            newAdv.Title = title;
            newAdv.AdvDuration = advDuration;
            newAdv.Description = description;
            newAdv.ShortDescription = shortdescription;
            newAdv.Price = price;
            newAdv.Link = link;
            newAdv.FullName = fullName;
            newAdv.Mobile = mobile;
            newAdv.Tell = tell;
            newAdv.TellTime = telltime;
            newAdv.Email = email;
            newAdv.YahooID = yahooid;
            newAdv.Address = address;
            newAdv.ExpirationDate = DateTime.Now;
            newAdv.RegistrationDate = DateTime.Now;
            newAdv.LastRenewal = DateTime.Now;
            newAdv.GroupID = groupId;
            newAdv.Pic = "";
            newAdv.StateCityID = StateCityID;

            foreach (int kwId in MemberFunctions.ParseKeyWords(keywordStr))
            {
                KeyWord tempkw = ml.KeyWords.Where(t => t.ID == kwId).First();
                newAdv.KeyWords.Add(tempkw);
            }

            ml.Advertisments.AddObject(newAdv);
            try
            {
                ml.SaveChanges();
                if (tempAdd != "")
                {
                    SaveImage(tempAdd, mainAdd + newAdv.ID + "/", fileName);
                    newAdv.Pic = mainAdd + newAdv.ID + "/" + fileName;
                    ml.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void SetAdvRate(int AdvId, Single Value)
        {
            int? UserId = null;
            int CurUserId = AccountFunctions.currentUserId();
            if (CurUserId != -1) UserId = CurUserId;
            ModelContainer ml = new ModelContainer();
            Rate r;

            if (CurUserId != -1)// member user
            {
                if (ml.Rates.Where(t => t.AdvertismentId == AdvId && t.UserId == UserId).Count() > 0)//rate this adv in past
                {
                    r = ml.Rates.Where(t => t.AdvertismentId == AdvId && t.UserId == UserId).First();
                    r.Value = Value;
                }//rate just now
                else
                {
                    r = new Rate();
                    r.Advertisment = ml.Advertisments.Where(t => t.ID == AdvId).First();
                    r.User = ml.Users.Where(t => t.ID == CurUserId).First();
                    r.Value = Value;
                    ml.AddToRates(r);
                }
            }
            else//anonymous user 
            {
                List<AssignorRate> sessionRates;
                if (System.Web.HttpContext.Current.Session["AdvRates"] != null)
                {
                    sessionRates = (List<AssignorRate>)System.Web.HttpContext.Current.Session["AdvRates"];
                    if (sessionRates.Where(t => t.AdvertismentId == AdvId).Count() > 0)//anonymous user rate in past(saved in session)
                    {
                        AssignorRate ar = sessionRates.Where(t => t.AdvertismentId == AdvId).First();
                        Rate preRate = new Rate();
                        r = ml.Rates.Where(t => t.AdvertismentId == AdvId && t.UserId == null && t.Value == ar.Value).First();
                        r.Value = Value;
                    }//anonymous user rate just now
                    else
                    {
                        r = new Rate();
                        r.Value = Value;
                        r.Advertisment = ml.Advertisments.Where(t => t.ID == AdvId).First();
                        ml.AddToRates(r);
                    }
                }//anonymous user rate just now
                else
                {
                    r = new Rate();
                    r.Value = Value;
                    r.Advertisment = ml.Advertisments.Where(t => t.ID == AdvId).First();
                    ml.AddToRates(r);
                }
            }

            ml.SaveChanges();
        }
        public static void SaveImage(string tempAdd, string mainAdd, string filename)
        {

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(mainAdd)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(mainAdd));
            }

            File.Copy(HttpContext.Current.Server.MapPath(tempAdd + filename), HttpContext.Current.Server.MapPath(mainAdd + filename));

            File.Delete(HttpContext.Current.Server.MapPath(tempAdd + filename));

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
                    if (ml.KeyWords.Where(t => t.ID== id).Count() > 0)
                    {
                        kwList.Add(ml.KeyWords.Where(t => t.ID == id).Select(t => t.ID).First());
                    }
                }
                catch
                {
                    if (ml.KeyWords.Where(t => t.Text == kwStr).Count() == 0)
                    {
                        KeyWord newkw = new KeyWord();
                        newkw.Text = kwStr;
                        ml.KeyWords.AddObject(newkw);
                        ml.SaveChanges();
                        kwList.Add(newkw.ID);
                    }
                }

            }

            return kwList.ToArray();
        }
        public static DataTable UnconfirmedFreeAdvertismentsDataTable()
        {
            ModelContainer ml = new ModelContainer();

            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => t.IsConfirmed == false && t.IsRead == false && t.StarCount == -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, -1, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList);
        }
        public static void ConfirmAdvertisment(int AdvID)
        {
            ModelContainer ml = new ModelContainer();
            Advertisment adv = ml.Advertisments.Where(t => t.ID == AdvID).FirstOrDefault();
            //if (adv.StarCount == -1)
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
            //if (adv.StarCount == -1)
            {
                adv.IsRead = true;
                adv.IsConfirmed = false;
                adv.DenyReason = reason;
                ml.SaveChanges();
            }
        }
        public static void AddNewTicket(string text, string title, int userId)
        {
            ModelContainer ml = new ModelContainer();
            Ticket t = new Ticket();
            t.Priority = "";
            t.Text = text;
            t.Title = title;
            t.User = ml.Users.Where(u => u.ID == userId).First();
            t.IsRead = false;
            t.LastUpdate = DateTime.Now;
            t.RegDate = DateTime.Now;

            ml.Tickets1.AddObject(t);
            ml.SaveChanges();

        }
        public static AssignorTicket GetTicketData(int id)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<Ticket, AssignorTicket>(ml.Tickets1.Where(t => t.ID == id).FirstOrDefault());
        }
        public static List<AssignorTicket> GetListTicketData(int id)
        {
            ModelContainer ml = new ModelContainer();
            var x = ml.Tickets1.Where(t => t.UserID == id).ToArray();
            List<AssignorTicket> r = new List<AssignorTicket>();
            foreach (Ticket tic in x)
            {
                r.Add(PublicFunctions.MakeAssignor<Ticket, AssignorTicket>(tic));
            }
            return r;
        }

        public static AssignorTicket[] GetListTicketData()
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorTicket> at = new List<AssignorTicket>();

            foreach (Ticket tt in ml.Tickets1.Where(t => t.RegDate == t.LastUpdate).OrderByDescending(t => t.LastUpdate).ToArray())
            {
                at.Add(PublicFunctions.MakeAssignor<Ticket, AssignorTicket>(tt));
            }

            return at.ToArray();
        }

        public static void DeleteTicket(int TicketID)
        {
            ModelContainer ml = new ModelContainer();
            Ticket TicketDeleted = ml.Tickets1.Where(t => t.ID == TicketID).First();
            ml.DeleteObject(TicketDeleted);
            ml.SaveChanges();
        }

        public static void DeleteAdv(int AdvID)
        {
            ModelContainer ml = new ModelContainer();
            Advertisment AdvForDelete = ml.Advertisments.Where(t => t.ID == AdvID).First();
            AdvForDelete.KeyWords.Clear();
            ml.DeleteObject(AdvForDelete);
            ml.SaveChanges();
        }

        public static AssignorAdvertisment GetAdvertismentData(int id)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(ml.Advertisments.Where(t => t.ID == id).FirstOrDefault());
        }
        public static AssignorAdvertisment[] GetUserAdvs(int UserID)
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorAdvertisment> aAdv = new List<AssignorAdvertisment>();
            foreach (Advertisment ad in ml.Users.Where(a => a.ID == UserID).FirstOrDefault().Advertisments)
            {
                aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(ad));
            }

            return aAdv.ToArray();
        }
        public static AssignorAdvertisment[] GetUserConfirmedAdvs(int UserID)
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorAdvertisment> aAdv = new List<AssignorAdvertisment>();
            foreach (Advertisment ad in ml.Users.Where(a => a.ID == UserID).FirstOrDefault().Advertisments.Where(t => t.IsConfirmed))
            {
                aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(ad));
            }

            return aAdv.ToArray();
        }
        public static AssignorGroup[] GetSubGroups()
        {
            ModelContainer ml = new ModelContainer();

            List<Group> ParentGroup = new List<Group>();
            ParentGroup = ml.Groups.Where(t => t.ParentID == null).OrderBy(t=> t.GroupName).ToList();
            List<AssignorGroup> aGroup = new List<AssignorGroup>();
            foreach (Group gr in ParentGroup)
            {
                aGroup.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(gr));
                foreach (Group subgr in gr.childGroup.OrderBy(t=> t.GroupName))
                {
                    aGroup.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(subgr));
                }
            }

            return aGroup.ToArray();
        }
        public static AssignorStateCity[] GetStateAndCityForDropDown()
        {
            ModelContainer ml = new ModelContainer();

            List<StateCity> State = new List<StateCity>();
            State = ml.StateCities.Where(t => t.StateId == null).OrderBy(t=> t.Name).ToList();
            List<AssignorStateCity> aState = new List<AssignorStateCity>();
            foreach (StateCity sc in State)
            {
                aState.Add(PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(sc));
                foreach (StateCity city in sc.Cities.OrderBy(t=> t.Name))
                {
                    aState.Add(PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(city));
                }
            }

            return aState.ToArray();
        }
        public static AssignorGroup[] GetParentGroups()
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorGroup> aGroup = new List<AssignorGroup>();
            foreach (Group gr in ml.Groups.Where(t => t.ParentID == null))
            {
                aGroup.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(gr));
            }

            return aGroup.OrderBy(t=> t.GroupName).ToArray();
        }
        public static AssignorGroup[] GetSubGroupsByID(int ID)
        {
            ModelContainer ml = new ModelContainer();


            List<AssignorGroup> aGroup = new List<AssignorGroup>();
            foreach (Group gr in ml.Groups.Where(t => t.ParentID == ID))
            {
                aGroup.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(gr));
            }

            return aGroup.OrderBy(t => t.GroupName).ToArray();
        }
        public static void AddNewGroup(string groupName, int? parentId)
        {
            Group g = new Group();
            g.GroupName = groupName;
            g.ParentID = parentId;
            ModelContainer ml = new ModelContainer();
            ml.Groups.AddObject(g);
            ml.SaveChanges();
        }


        internal static AssignorGroup GetGroupData(int groupId)
        {
            ModelContainer ml = new ModelContainer();

            return PublicFunctions.MakeAssignor<Group, AssignorGroup>(ml.Groups.Where(t => t.ID == groupId).First());
        }

        internal static void UpdateGroupData(int Id, string groupName, int? parentId)
        {
            ModelContainer ml = new ModelContainer();
            Group g = ml.Groups.Where(t => t.ID == Id).First();
            g.GroupName = groupName;
            g.ParentID = parentId;
            ml.SaveChanges();
        }
        public static AssignorAdvertisment[] GetAdvByGroupID(int ID)
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorAdvertisment> aAdv = new List<AssignorAdvertisment>();

            if (ml.Groups.Where(t => t.ID == ID).First().ParentID == null)
            {
                foreach (Advertisment adv1 in (from adv in ml.Advertisments
                                               where (adv.GroupID == ID || adv.GroupID == (from Gr in ml.Groups where Gr.ParentID == ID select Gr.ID).FirstOrDefault()) && adv.IsConfirmed == true
                                               select adv))
                {
                    aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(adv1));
                }
            }
            else
                foreach (Advertisment adv1 in ml.Advertisments.Where(t => t.GroupID == ID && t.IsConfirmed == true))
                {
                    aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(adv1));
                }


            return aAdv.ToArray();

        }
        public static object UnconfirmedStaredAdvertismentsDataTable()
        {
            ModelContainer ml = new ModelContainer();

            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => t.IsConfirmed == false && t.IsRead == false && t.StarCount > -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, adv.StarCount, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList);
        }

        internal static void SetTicketAnswer(int TicketID, string answer)
        {
            ModelContainer ml = new ModelContainer();
            Ticket t1 = ml.Tickets1.Where(t => t.ID == TicketID).First();
            t1.Answer = answer;
            t1.LastUpdate = DateTime.Now;
            ml.SaveChanges();
        }

        internal static void DeleteGroup(int id)
        {
            ModelContainer ml = new ModelContainer();
            Group g = ml.Groups.Where(t => t.ID == id).First();

            foreach (Group childGroup in g.childGroup.ToArray())
            {
                ml.Groups.DeleteObject(childGroup);
            }

            ml.DeleteObject(g);

            ml.SaveChanges();

        }


        internal static float GetAdvUserRate(int AdvId)
        {
            ModelContainer ml = new ModelContainer();
            int UserId = AccountFunctions.currentUserId();
            if (UserId != -1 && ml.Rates.Where(t => t.AdvertismentId == AdvId && t.UserId == UserId).Count() > 0)
            {
                return ml.Rates.Where(t => t.AdvertismentId == AdvId && t.UserId == UserId).Select(t => t.Value).First();
            }
            else
            {
                return 0;
            }
        }

        internal static AssignorStateCity[] GetStates()
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorStateCity> aStateCity = new List<AssignorStateCity>();
            foreach (StateCity sc in ml.StateCities.Where(t => t.StateId == null))
            {
                aStateCity.Add(PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(sc));
            }
            return aStateCity.ToArray();
        }

        internal static void DeleteStateCity(int id)
        {
            ModelContainer ml = new ModelContainer();
            StateCity s = ml.StateCities.Where(t => t.ID == id).First();

            foreach (StateCity c in s.Cities.ToArray())
            {
                ml.DeleteObject(c);
            }
            ml.DeleteObject(s);

            ml.SaveChanges();
        }

        internal static AssignorStateCity[] GetStatesCities()
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorStateCity> aStateCity = new List<AssignorStateCity>();
            foreach (StateCity sc in ml.StateCities)
            {
                aStateCity.Add(PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(sc));
            }
            return aStateCity.ToArray();
        }

        internal static void AddNewStateCity(string Name, int? StateId)
        {
            ModelContainer ml = new ModelContainer();
            StateCity sc = new StateCity();
            sc.Name = Name;
            if (StateId != null) sc.State = ml.StateCities.Where(t => t.ID == StateId).First();
            ml.StateCities.AddObject(sc);
            ml.SaveChanges();
        }

        internal static AssignorStateCity GetStateCityData(int StateCityId)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(ml.StateCities.Where(t => t.ID == StateCityId).First());
        }

        internal static void UpdateStateCityData(int StateCityId, string Name, int? StateId)
        {
            ModelContainer ml = new ModelContainer();
            StateCity sc = ml.StateCities.Where(t => t.ID == StateCityId).First();
            sc.Name = Name;
            if (StateId != null)
            {
                sc.State = ml.StateCities.Where(t => t.ID == StateId).First();
            }
            else
            {
                sc.State = null;
                sc.StateId = null;
            }
            ml.SaveChanges();
        }
    }
    public class ShowAdvertisment
    {
        public string Description,
            FullName,
            Title,
            Pic;
        public int ID, UserId, starCount;
        public DateTime RegistrationDate;

        public ShowAdvertisment(int ID,
            string Title,
            string Description,
            string FullName,
            string Pic,
            DateTime RegistrationDate, int starcount,
            int UserId)
        {
            this.ID = ID;
            this.FullName = FullName;
            this.Description = Description;
            this.Pic = Pic;
            this.RegistrationDate = RegistrationDate;
            this.Title = Title;
            this.starCount = starcount;
            this.UserId = UserId;
        }
    }
}