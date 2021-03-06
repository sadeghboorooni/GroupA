﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADVIEWER.DAL;
using System.Reflection;
using System.Data;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace ADVIEWER.BAL
{
    //! MemberFunctions Class
    /*! !
     This Class is For Functions used in member section, note that manager is a member
     */
    public class MemberFunctions
    {

        //! MakeNewAdvertisment
        /*! 
         This returns all the data in the chart is an ad for it in the Keyword Abtza Id find them and if you did not have it on the table it will add it id allottable, and it's videos id the adds the information to advertisers. adding the image to the address given in the address information is saved ads
         */
        public static bool MakeNewAdvertisment(int starCount, int advDuration, string title, string shortdescription, string description,
            string keywordStr, string price, string link, string fullName, string mobile, string tell, string telltime,
            string email, string yahooid, string address, int userId, string tempAdd, string mainAdd, string fileName, int groupId, int StateCityID)
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
            newAdv.ExpirationDate = DateTime.Now.AddMonths(advDuration);
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
        //! GetUserFavoriteGroups
        /*! 
         returns the string that used in auto complete field for user favorite groups field
         */

        public static string GetUserFavoriteGroups(int UserID)
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorGroup> TempGroups = new List<AssignorGroup>();
            String resp = "[";
            foreach (Group gr in ml.Users.Where(t => t.ID == UserID).FirstOrDefault().Groups.ToArray())
            {
                resp += "{" + "name:" + '"' + gr.GroupName + '"' + "," + "id:" + gr.ID + "},";

            }
            if (resp.LastIndexOf(',') != -1) resp = resp.Remove(resp.LastIndexOf(','));
            resp += "]";
            //resp = resp.Replace(@"\", "");
            return resp;
        }

        //! SetAdvRate
        /*! 
         insert or update the value of rating an advertisement 
         */
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

        //! SaveImage
        /*! 
         This is the first Czech to address is that if there is no input, it will generate and store the image at that address.
         */
        public static void SaveImage(string tempAdd, string mainAdd, string filename)
        {

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(mainAdd)))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(mainAdd));
            }
            try
            {
                File.Move(HttpContext.Current.Server.MapPath(tempAdd + filename), HttpContext.Current.Server.MapPath(mainAdd + filename));

                File.Delete(HttpContext.Current.Server.MapPath(tempAdd + filename));
            }
            catch
            { }

        }

        //! ParseKeyWords
        /*! 
         This function takes a string input and then it all on the field "," id separator and returns the entire category in the output. If you are not a member of keyword table, then it adds the keyword, and then returns the new id.
         */

        public static int[] ParseKeyWords(string keywordStr)
        {
            List<int> kwList = new List<int>();
            ModelContainer ml = new ModelContainer();

            foreach (string kwStr in keywordStr.Split(','))
            {
                try
                {
                    int id = int.Parse(kwStr);
                    if (ml.KeyWords.Where(t => t.ID == id).Count() > 0)
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

        //! UnconfirmedFreeAdvertismentsDataTable
        /*! 
         This function returns all the free advertising that have been approved
         */

        public static DataTable UnconfirmedFreeAdvertismentsDataTable()
        {
            ModelContainer ml = new ModelContainer();

            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => (t.IsConfirmed == false && t.IsRead == false) && t.StarCount == -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, -1, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList);
        }

        //! ConfirmAdvertisment
        /*! 
         This function reads the characteristics of certified puts an ad equals true.
         */

        public static void ConfirmAdvertisment(int AdvID)
        {
            ModelContainer ml = new ModelContainer();
            Advertisment adv = ml.Advertisments.Where(t => t.ID == AdvID).FirstOrDefault();
            //if (adv.StarCount == -1)
            {
                adv.IsRead = true;
                adv.IsConfirmed = true;
                adv.ExpirationDate = DateTime.Now.AddMonths(adv.AdvDuration);
                ml.SaveChanges();

                if (adv.StarCount == 2)
                {
                    SendMail(adv);
                }
            }

        }

        //! SendMail
        /*! 
         This Function is just for sending a email
         */

        private static void SendMail(Advertisment adv)
        {
            ModelContainer ml = new ModelContainer();
            var fromAddress = new MailAddress("adviewer1@gmail.com", "تبلیغ نما");
            Group TempSubGroup = ml.Groups.Where(t => t.ID == adv.GroupID).First();
            Group TempParentGroup = TempSubGroup.parentGroup;

            foreach (User u in ml.Users)
            {
                if (u.Groups.Contains(TempSubGroup) || u.Groups.Contains(TempParentGroup))
                {
                    var toAddress = new MailAddress(u.Mail, u.FullName);

                    const string fromPassword = "hamid123";
                    string subject = adv.Title;
                    string src = "";
                    if (adv.Pic.ToString() != "")
                        src = HttpContext.Current.Server.MapPath(adv.Pic).ToString();
                    string body = "<h1></h1><br><table style = \" direction:rtl;line-height:40px\">" +
                        "<tr> <td colspan =\"2\">" +
                        "<a href =\"http://www.adviewer.ir\">" +
                        "<img src=\"http://www.adviewer.ir/Styles/Images/Logo.png \" style = \"max-width:15%; float:right\" />" +
                        "</a>" +
                        "</td> </tr>" +
                        "<tr> <td>" +
                        "<span style='font-size=17px;color:blue'>عنوان آگهی: </span>" +
                        "<a style='color:green' href = \"http://www.adviewer.ir/advcontent.aspx?id=" + adv.ID + "\">" + adv.Description + "</a>" +
                         "</td> </tr>";
                    if (src != "")
                    {
                        body += "<tr><td colspan = \"2\">" +
                        "<a href = \"http://www.adviewer.ir/advcontent.aspx?id=" + adv.ID + "\">" +
                        " <img src = \"" + src + "\" style = \"max-width:200px; float:right\"/>" + "</a>";
                    }

                    body += "</td> </tr>";
                    if (adv.StateCity != null)
                        if (adv.StateCity.StateId != null)
                        {
                            body += "<tr><td>" +
                                "<span style='font-size=17px;color:blue'>آگهی مربوط به استان:</span> استان " + "<a style='color:green' href = \"http://www.adviewer.ir/ShowStateAdvs.aspx?id=" + adv.StateCity.StateId + "\">" + adv.StateCity.State.Name + "</a>"
                                + " شهر  " + "<a style='color:green' href = \"http://www.adviewer.ir/ShowStateAdvs.aspx?id=" + adv.StateCityID + "\">" + adv.StateCity.Name + "</a>" +
                               "</tr></td>"
                                ;
                        }
                        else
                        {
                            body += "<tr><td>" +
                            "<span style='font-size=17px;color:blue'>آگهی مربوط به استان:</span>  استان " + "<a style='color:green' href = \"http://www.adviewer.ir/ShowStateAdvs.aspx?id=" + adv.StateCityID + "\">" + adv.StateCity.Name + "</a>" +
                               "</tr></td>";
                        }

                    if (adv.Group != null)
                        if (adv.Group.ParentID != null)
                        {
                            body += "<tr><td>" +
                                "<span style='font-size=17px;color:blue'>آگهی مربوط به گروه:</span> گروه  " + "<a style='color:green' href = \"http://www.adviewer.ir/ShowGroupAdvs.aspx?id=" + adv.Group.ParentID + "\">" + adv.Group.parentGroup.GroupName + "</a>"
                                + "  زیرگروه  " + "<a style='color:green' href = \"http://www.adviewer.ir/ShowGroupAdvs.aspx?id=" + adv.GroupID + "\">" + adv.Group.GroupName + "</a>" +
                               "</tr></td>"
                                ;
                        }
                        else
                        {
                            body += "<tr><td>" +
                            "<span style='font-size=17px;color:blue'>آگهی مربوط به گروه :</span> گروه  " + "<a style='color:green' href = \"http://www.adviewer.ir/ShowGroupAdvs.aspx?id=" + adv.GroupID + "\">" + adv.Group.GroupName + "</a>" +
                               "</tr></td>";
                        }


                    body += "</table>";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    })
                    {
                        smtp.Send(message);
                    }
                }
            }
        }

        //! DenyAdvertisment
        /*! 
         do the jobs tha t nessecery to deny an advertisement
         */

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

        //! AddNewTicket
        /*! 
         The function of a ticket will receive all the information it can store.
         */

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

        //! GetTicketData
        /*! 
         This function returns a ticket id of that information.
         */

        public static AssignorTicket GetTicketData(int id)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<Ticket, AssignorTicket>(ml.Tickets1.Where(t => t.ID == id).FirstOrDefault());
        }


        //! GetListTicketData
        /*! 
        This function takes a user id found it to be a function of all the ticket that was created by that person returns.
         */

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

        //! GetListTicketData
        /*! 
        This function does not enter a value in the input list of ticket that will be the last update they will return back to REG.
         */

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

        //! GetListCommentData
        /*! 
        return the array of assignorComments orderd by its registration date
         */
        public static AssignorComment[] GetListCommentData()
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorComment> at = new List<AssignorComment>();

            foreach (Comment tt in ml.Messages.OfType<Comment>().Where(t => t.IsConfirmed == false).OrderByDescending(t => t.RegistrationDate).ToArray())
            {
                at.Add(PublicFunctions.MakeAssignor<Comment, AssignorComment>(tt));
            }

            return at.ToArray();
        }

        //! GetCommentData
        /*! 
        return the comment that it's id passed to its
         */
        public static AssignorComment GetCommentData(int id)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<Comment, AssignorComment>(ml.Messages.OfType<Comment>().Where(t => t.ID == id).FirstOrDefault());
        }


        //! DeleteTicket
        /*! 
        This entry id in the function receives a ticket and it will be deleted from the database.
         */

        public static void DeleteTicket(int TicketID)
        {
            ModelContainer ml = new ModelContainer();
            Ticket TicketDeleted = ml.Tickets1.Where(t => t.ID == TicketID).First();
            ml.DeleteObject(TicketDeleted);
            ml.SaveChanges();
        }

        //! DeleteComment
        /*! 
        This entry id in the function receives a comment and it will be deleted from the database.
         */

        public static void DeleteComment(int CommentID)
        {
            ModelContainer ml = new ModelContainer();
            Comment CommentDeleted = ml.Messages.OfType<Comment>().Where(t => t.ID == CommentID).First(); ml.DeleteObject(CommentDeleted);
            ml.SaveChanges();
        }

        //! ConfirmComment
        /*! 
        do the jobs tha t nessecery to confirm a comment
         */

        public static void ConfirmComment(int id)
        {
            ModelContainer ml = new ModelContainer();
            Comment ConfirmComment = ml.Messages.OfType<Comment>().Where(t => t.ID == id).First();
            ConfirmComment.IsConfirmed = true;
            ml.SaveChanges();
        }

        //! DeleteAdv
        /*! 
        This function receives an ad in the input id and it will be deleted from the database.
         */

        public static void DeleteAdv(int AdvID)
        {
            ModelContainer ml = new ModelContainer();
            Advertisment AdvForDelete = ml.Advertisments.Where(t => t.ID == AdvID).First();
            AdvForDelete.KeyWords.Clear();
            ml.DeleteObject(AdvForDelete);
            ml.SaveChanges();
        }

        //! GetAdvertismentData
        /*! 
        This function takes an advertiser id and all the information it returns.
         */

        public static AssignorAdvertisment GetAdvertismentData(int id)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(ml.Advertisments.Where(t => t.ID == id).FirstOrDefault());
        }

        //! GetUserAdvs
        /*! 
        This function receives the input of personal id and insert advertising that person returns.
         */

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

        //! GetUserConfirmedAdvs
        /*! This function receives the input of personal id and advertising inserts and confirmed that a person will return.*/
        public static AssignorAdvertisment[] GetUserConfirmedAdvs(int UserID)
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorAdvertisment> aAdv = new List<AssignorAdvertisment>();
            foreach (Advertisment ad in ml.Users.Where(a => a.ID == UserID).FirstOrDefault().Advertisments.Where(t => t.IsConfirmed))
            {
                aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(ad));
            }

            return aAdv.OrderByDescending(t => t.LastRenewal).ToArray();
        }
        //! GetSubGroups
        /*! This function returns all sub-groups.*/
        public static AssignorGroup[] GetSubGroups()
        {
            ModelContainer ml = new ModelContainer();

            List<Group> ParentGroup = new List<Group>();
            ParentGroup = ml.Groups.Where(t => t.ParentID == null).OrderBy(t => t.GroupName).ToList();
            List<AssignorGroup> aGroup = new List<AssignorGroup>();
            foreach (Group gr in ParentGroup)
            {
                aGroup.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(gr));
                foreach (Group subgr in gr.childGroup.OrderBy(t => t.GroupName))
                {
                    aGroup.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(subgr));
                }
            }

            return aGroup.ToArray();
        }

        //! GetStateAndCityForDropDown
        /*! 
         returns all states and cities
         */
        public static AssignorStateCity[] GetStateAndCityForDropDown()
        {
            ModelContainer ml = new ModelContainer();

            List<StateCity> State = new List<StateCity>();
            State = ml.StateCities.Where(t => t.StateId == null).OrderBy(t => t.Name).ToList();
            List<AssignorStateCity> aState = new List<AssignorStateCity>();
            foreach (StateCity sc in State)
            {
                aState.Add(PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(sc));
                foreach (StateCity city in sc.Cities.OrderBy(t => t.Name))
                {
                    aState.Add(PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(city));
                }
            }

            return aState.ToArray();
        }

        //! GetParentGroups
        /*! This function will return all key subgroups such as Saipa car but do not open it.*/
        public static AssignorGroup[] GetParentGroups()
        {
            ModelContainer ml = new ModelContainer();

            List<AssignorGroup> aGroup = new List<AssignorGroup>();
            foreach (Group gr in ml.Groups.Where(t => t.ParentID == null))
            {
                aGroup.Add(PublicFunctions.MakeAssignor<Group, AssignorGroup>(gr));
            }

            return aGroup.OrderBy(t => t.GroupName).ToArray();
        }

        //! GetSubGroupsByID
        /*! This function get a group id after that return all sub grpup of that*/
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

        //! AddNewGroup
        /*! This function in a subclass to receive input data and creates a new subgroup.*/
        public static void AddNewGroup(string groupName, int? parentId)
        {
            Group g = new Group();
            g.GroupName = groupName;
            g.ParentID = parentId;
            ModelContainer ml = new ModelContainer();
            ml.Groups.AddObject(g);
            ml.SaveChanges();
        }

        //! GetGroupData
        /*! The function to get the node id of a subset of all the data it returns.*/
        internal static AssignorGroup GetGroupData(int groupId)
        {
            ModelContainer ml = new ModelContainer();

            return PublicFunctions.MakeAssignor<Group, AssignorGroup>(ml.Groups.Where(t => t.ID == groupId).First());
        }

        //! UpdateGroupData
        /*! This function receives an input of new information and to update them.*/
        internal static void UpdateGroupData(int Id, string groupName, int? parentId)
        {
            ModelContainer ml = new ModelContainer();
            Group g = ml.Groups.Where(t => t.ID == Id).First();
            g.GroupName = groupName;
            g.ParentID = parentId;
            ml.SaveChanges();
        }

        //! GetAdvByGroupID
        /*! The entries will receive an ID and the ID of those that are advertising their GroupID is being input to output will be Brarbr.*/
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

        //! UnconfirmedStaredAdvertismentsDataTable
        /*! This function will return all ads starred that have been approved*/
        public static object UnconfirmedStaredAdvertismentsDataTable()
        {
            ModelContainer ml = new ModelContainer();

            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => (t.IsConfirmed == false && t.IsRead == false) && t.StarCount > -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, adv.StarCount, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList);
        }


        //! UserDataTable
        /*! This Function Return list of user That login betwean f and l*/
        public static object UserDataTable(string f, string l)
        {
            ModelContainer ml = new ModelContainer();

            DateTime fdate, ldate;


            fdate = DateTime.ParseExact(f, "yyyyMMdd", null);


            ldate = DateTime.ParseExact(l, "yyyyMMdd", null);


            List<AssignorUser> userList = new List<AssignorUser>();
            foreach (User us in ml.Users.Where(t => (t.LastLogin >= fdate && t.LastLogin <= ldate)))
            {
                userList.Add(PublicFunctions.MakeAssignor<User, AssignorUser>(us));
            }
            userList = userList.OrderByDescending(t => t.RegisterDate).ToList();
            return userList;
        }

        //! UserDataTable2
        /*! This Function Return list of user That have information name or mail or id*/
        public static object UserDataTable2(string name, string mail, string id)
        {
            ModelContainer ml = new ModelContainer();
            List<ShowUser> userList = new List<ShowUser>();

            //000
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(id))
            {
                int p = Int32.Parse(id);
                foreach (User us in ml.Users.Where(t => (t.FullName == name && t.ID == p && t.Mail == mail)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }


            //001

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mail) && string.IsNullOrEmpty(id))
            {

                foreach (User us in ml.Users.Where(t => (t.FullName == name && t.Mail == mail)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }

            //010
            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(id))
            {
                int p = Int32.Parse(id);
                foreach (User us in ml.Users.Where(t => (t.FullName == name && t.ID == p)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }

            //011
            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(mail) && string.IsNullOrEmpty(id))
            {

                foreach (User us in ml.Users.Where(t => (t.FullName == name)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }

            //100
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(id))
            {
                int p = Int32.Parse(id);
                foreach (User us in ml.Users.Where(t => (t.ID == p && t.Mail == mail)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }


            //101
            if (string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(mail) && string.IsNullOrEmpty(id))
            {

                foreach (User us in ml.Users.Where(t => (t.FullName == name && t.Mail == mail)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }

            //110
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(id))
            {
                int p = Int32.Parse(id);
                foreach (User us in ml.Users.Where(t => (t.ID == p)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }


            //111
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(mail) && string.IsNullOrEmpty(id))
            {

                foreach (User us in ml.Users.Where(t => (t.IsManager == false || t.IsManager == true)))
                {
                    userList.Add(new ShowUser(us.ID, us.FullName, us.Mail, us.RegisterDate, us.LastLogin));
                }
            }

            userList = userList.OrderByDescending(t => t.RegisterDate).ToList();
            return PublicFunctions.ToDataTable<ShowUser>(userList);
        }

        //! CountAdReportStar
        /*! return count of Ad Report Star*/
        public static int CountAdReportStar()
        {
            ModelContainer ml = new ModelContainer();
            DateTime a = DateTime.Now;

            int b = Int32.Parse(a.Day.ToString());
            int c = Int32.Parse(a.Month.ToString());
            int d = Int32.Parse(a.Year.ToString());

            if (b == 1)
            {
                if (c == 1)
                {
                    c = 12;
                    d = d - 1;
                    b = 29;

                }
                else
                {
                    c = c - 1;
                    b = 30;
                }
            }
            else
                b = b - 1;
            string e = b.ToString();
            if (e.Length < 2)
                e = "0" + e;
            string f = c.ToString();
            if (f.Length < 2)
                f = "0" + f;
            e = d.ToString() + f + e;

            DateTime g = DateTime.ParseExact(e, "yyyyMMdd", null);


            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => (t.RegistrationDate >= a && t.RegistrationDate <= g) && t.StarCount > -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, adv.StarCount, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList).Rows.Count;
        }

        //! AdReportStar
        /*! return count of Ad Star betwean f and l*/
        public static object AdReportStar(string f, string l)
        {
            ModelContainer ml = new ModelContainer();
            DateTime fdate, ldate;


            fdate = DateTime.ParseExact(f, "yyyyMMdd", null);

            ldate = DateTime.ParseExact(l, "yyyyMMdd", null);
            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => (t.IsConfirmed == true && t.RegistrationDate >= fdate && t.RegistrationDate <= ldate) && t.StarCount > -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, adv.StarCount, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList);
        }

        //! CountAdReportNormal
        /*! return count of Ad Report Star*/
        public static int CountAdReportNormal()
        {
            ModelContainer ml = new ModelContainer();
            DateTime a = DateTime.Now;

            int b = Int32.Parse(a.Day.ToString());
            int c = Int32.Parse(a.Month.ToString());
            int d = Int32.Parse(a.Year.ToString());

            if (b == 1)
            {
                if (c == 1)
                {
                    c = 12;
                    d = d - 1;
                    b = 29;

                }
                else
                {
                    c = c - 1;
                    b = 30;
                }
            }
            else
                b = b - 1;
            string e = b.ToString();
            if (e.Length < 2)
                e = "0" + e;
            string f = c.ToString();
            if (f.Length < 2)
                f = "0" + f;
            e = d.ToString() + f + e;

            DateTime g = DateTime.ParseExact(e, "yyyyMMdd", null);


            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => (t.RegistrationDate >= a && t.RegistrationDate <= g) && t.StarCount > -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, adv.StarCount, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList).Rows.Count;
        }

        //! AdReportNormal
        /*! This Function Return list of ad That Registered betwean f and l*/
        public static object AdReportNormal(string f, string l)
        {
            ModelContainer ml = new ModelContainer();
            DateTime fdate, ldate;


            fdate = DateTime.ParseExact(f, "yyyyMMdd", null);

            ldate = DateTime.ParseExact(l, "yyyyMMdd", null);
            List<ShowAdvertisment> unreadList = new List<ShowAdvertisment>();
            foreach (Advertisment adv in ml.Advertisments.Where(t => (t.IsConfirmed == true && t.RegistrationDate >= fdate && t.RegistrationDate <= ldate) && t.StarCount > -1))
            {
                unreadList.Add(new ShowAdvertisment(adv.ID, adv.Title, adv.ShortDescription, adv.FullName, adv.Pic, adv.RegistrationDate, adv.StarCount, adv.UserId));
            }
            unreadList = unreadList.OrderByDescending(t => t.RegistrationDate).ToList();
            return PublicFunctions.ToDataTable<ShowAdvertisment>(unreadList);
        }

        //! SetTicketAnswer
        /*! This function takes a string input and a Shnayh for Ticket with ID equal to the value of the field will answer it.*/
        internal static void SetTicketAnswer(int TicketID, string answer)
        {
            ModelContainer ml = new ModelContainer();
            Ticket t1 = ml.Tickets1.Where(t => t.ID == TicketID).First();
            t1.Answer = answer;
            t1.LastUpdate = DateTime.Now;
            ml.SaveChanges();
        }


        //! DeleteGroup
        /*! This function get id of a group an delete that group and all sub group*/
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

        //! GetAdvUserRate
        /*! This function get id of a ad and return the rate of that*/
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

        //! GetStates
        /*! This function returns all provinces.*/
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

        //! DeleteStateCity
        /*! This function takes in input the Astna ID a provincial cities, it is deleted from the system.*/
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

        //! GetStatesCities
        /*! This function returns information StatesCities table.*/
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

        //! AddNewStateCity
        /*! This function takes an input name and ID of a provincial town in the province is created.*/
        internal static void AddNewStateCity(string Name, int? StateId)
        {
            ModelContainer ml = new ModelContainer();
            StateCity sc = new StateCity();
            sc.Name = Name;
            if (StateId != null) sc.State = ml.StateCities.Where(t => t.ID == StateId).First();
            ml.StateCities.AddObject(sc);
            ml.SaveChanges();
        }

        //! GetStateCityData
        /*! Statecity ID function on the input and the output it gives statecity*/
        internal static AssignorStateCity GetStateCityData(int StateCityId)
        {
            ModelContainer ml = new ModelContainer();
            return PublicFunctions.MakeAssignor<StateCity, AssignorStateCity>(ml.StateCities.Where(t => t.ID == StateCityId).First());
        }

        //! UpdateStateCityData
        /*! This function takes the input data and the value of a statecity it is updated.*/
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

        //! GetLast9AdvsByUserGroups
        /*! 
         return array of advertisement for default page
         */
        internal static AssignorAdvertisment[] GetLast9AdvsByUserGroups(int UserId)
        {
            ModelContainer ml = new ModelContainer();
            AssignorUser aUser = AccountFunctions.GetUserInformation(UserId);
            if (aUser.Groups.Count() == 0)
            {
                return PublicFunctions.GetLast9Advs();
            }
            else
            {
                int[] aid = aUser.Groups.Select(t => t.ID).ToArray();

                var q = (from adv1 in ml.Advertisments
                         from grp in aid
                         where adv1.GroupID == grp
                         select adv1).ToArray();

                List<AssignorAdvertisment> aAdv = new List<AssignorAdvertisment>();
                foreach (Advertisment adv2 in q)
                {
                    aAdv.Add(PublicFunctions.MakeAssignor<Advertisment, AssignorAdvertisment>(adv2));
                }

                return aAdv.OrderBy(a => Guid.NewGuid()).Take(9).ToArray();
            }
        }

        //! setUserImage
        /*! This Function Set User image !!!*/
        public static void setUserImage(string tempAdd, string mainAdd, int userId, string fileName)
        {
            ModelContainer ml = new ModelContainer();
            User currentUser = ml.Users.Where(t => t.ID == userId).First();
            try
            {

                if (tempAdd != "")
                {
                    SaveImage(tempAdd, mainAdd, fileName);
                    currentUser.PicAddress = mainAdd + fileName;
                    ml.SaveChanges();
                }

            }
            catch
            {

            }

        }

        //! RenewAdv
        /*! This Functiun change atribute of ad that like new ad*/
        public static void RenewAdv(int ID)
        {
            ModelContainer ml = new ModelContainer();
            Advertisment adv1 = ml.Advertisments.Where(t => t.ID == ID).First();
            adv1.IsConfirmed = false;
            adv1.IsRead = false;
            adv1.LastRenewal = DateTime.Now;
            ml.SaveChanges();
        }

        //! deleteImage
        /*! This Function Remove image of a user*/
        public static void deleteImage(int userid)
        {
            ModelContainer ml = new ModelContainer();
            User currentUser = ml.Users.Where(t => t.ID == userid).First();
            string path = currentUser.PicAddress;
            try
            {
                if (path != null)
                {
                    if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
                    {
                        try
                        {
                            System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(path));
                        }

                        catch
                        {
                        }
                        currentUser.PicAddress = null;
                        ml.SaveChanges();
                    }
                }
            }
            catch
            {
            }


        }

        //! AddNewUserMessages
        /*! 
         Add New User Messages to data base, the receivers passed to function by UsersList. 
         */
        public static void AddNewUserMessages(string UsersList, string MessageContent)
        {
            ModelContainer ml = new ModelContainer();
            int CurUserID = AccountFunctions.currentUserId();
            foreach (string UserIDStr in UsersList.Split(','))
            {
                int UserID = int.Parse(UserIDStr);
                UserMessage Temp = new UserMessage();
                Temp.RecieverID = UserID;
                Temp.Text = MessageContent;
                Temp.SenderID = CurUserID;
                Temp.RegistrationDate = DateTime.Now;
                ml.AddToMessages(Temp);
            }

            try
            {
                ml.SaveChanges();
            }
            catch { }
        }

        //! GetSendMessageInboxDataSource
        /*! 
         return array of messages that specific user sent.
         */
        public static AssignorUserMessage[] GetSendMessageInboxDataSource(int UserID)
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorUserMessage> ReturnList = new List<AssignorUserMessage>();

            try
            {
                foreach (UserMessage Usr in ml.Messages.OfType<UserMessage>().Where(t => t.SenderID == UserID))
                {
                    ReturnList.Add(PublicFunctions.MakeAssignor<UserMessage, AssignorUserMessage>(Usr));
                }
                return ReturnList.ToArray();
            }
            catch
            {
                return null;
            }
        }

        //! GetRecieveMessageInboxDataSource
        /*! 
         return array of messages that specific user recived.
         */
        public static AssignorUserMessage[] GetRecieveMessageInboxDataSource(int UserID)
        {
            ModelContainer ml = new ModelContainer();
            List<AssignorUserMessage> ReturnList = new List<AssignorUserMessage>();

            try
            {
                foreach (UserMessage Usr in ml.Messages.OfType<UserMessage>().Where(t => t.RecieverID == UserID))
                {
                    ReturnList.Add(PublicFunctions.MakeAssignor<UserMessage, AssignorUserMessage>(Usr));
                }
                return ReturnList.ToArray();
            }
            catch
            {
                return null;
            }
        }

        //! GetRecieveMessageInboxDataSource
        /*! 
         return specific message that its ID passed to it.
         */
        public static AssignorMessage GetMessageByID(int MessageID)
        {
            ModelContainer ml = new ModelContainer();
            try
            {
                return PublicFunctions.MakeAssignor<Message, AssignorMessage>(ml.Messages.OfType<UserMessage>().Where(t => t.ID == MessageID).First());
            }
            catch
            {
                return null;
            }
        }
    }

    //! ShowAdvertisment
    /*! This class have som atribute of object of advertisment*/
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

    //! ShowUser
    /*! This class have som atribute of object of Users*/
   public class ShowUser
    {
        public string FullName,
            Mail;
        public int ID;
        public DateTime RegisterDate,
            LastLogin;

        public ShowUser(int ID, string FullName, string Mail, DateTime RegisterDate, DateTime LastLogin)
        {
            this.ID = ID;
            this.FullName = FullName;
            this.Mail = Mail;
            this.LastLogin = LastLogin;
            this.RegisterDate = RegisterDate;

        }
    }
}