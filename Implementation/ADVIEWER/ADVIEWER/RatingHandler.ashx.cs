using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADVIEWER.DAL;
using ADVIEWER.BAL;
using System.Web.SessionState;

namespace ADVIEWER
{
    /// <summary>
    /// Summary description for RatingHandler
    /// </summary>
    public class RatingHandler : IHttpHandler , IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                int AdvId = int.Parse(context.Request["advId"]);
                Single Value = Single.Parse(context.Request["val"]);
                MemberFunctions.SetAdvRate(AdvId, Value);//save rate in db

                if (AccountFunctions.currentUserId() == -1)//set session for anonymous user
                {
                    List<Rate> sessionRates;
                    if (context.Session["AdvRates"] != null)
                    {
                        sessionRates = (List<Rate>)context.Session["AdvRates"];
                        context.Session.Remove("AdvRates");
                    }
                    else
                    {
                        sessionRates = new List<Rate>();
                    }
                    if (sessionRates.Where(t => t.AdvertismentId == AdvId).Count() > 0)
                    {
                        Rate r = sessionRates.Where(t => t.AdvertismentId == AdvId).First();
                        sessionRates.Remove(r);
                        r.Value = Value;
                        sessionRates.Add(r);
                    }
                    else
                    {
                        Rate r = new Rate();
                        r.Value = Value;
                        r.AdvertismentId = AdvId;
                    }
                    context.Session.Add("AdvRates", sessionRates);
                }
                
            }
            catch 
            { }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}