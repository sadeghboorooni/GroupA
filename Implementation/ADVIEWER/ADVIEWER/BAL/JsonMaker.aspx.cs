using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.DAL;

namespace ADVIEWER.BAL
{
    public partial class JsonMaker : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            ModelContainer ml = new ModelContainer();

            if (Request.QueryString["entity"] != null)
            {

                if (Request.QueryString["entity"] == "keyword")
                {
                    string resp = "[";
                    string q = Request.QueryString["q"];
                    foreach (KeyWord kw in ml.KeyWords.Where(t=>t.Text.Contains(q)))
                    {
                        resp += "{\"name\":\"" + kw.Text + "\",\"id\":\"" + kw.ID + "\"},";
                    }
                    if(resp.LastIndexOf(',')!=-1) resp = resp.Remove(resp.LastIndexOf(','));
                    resp += "]";
                    Response.Write(resp);
                }
                else if (Request.QueryString["entity"] == "favoritegroup")
                {
                    string resp = "[";
                    string q = Request.QueryString["q"];
                    foreach (Group gr in ml.Groups.Where(t => t.GroupName.Contains(q)))
                    {
                        resp += "{\"name\":\"" + gr.GroupName + "\",\"id\":\"" + gr.ID + "\"},";
                    }
                    if (resp.LastIndexOf(',') != -1) resp = resp.Remove(resp.LastIndexOf(','));
                    resp += "]";
                    Response.Write(resp);
                }
                else if (Request.QueryString["entity"] == "initialfavoritegroup")
                {
                    int CurrentUserID = AccountFunctions.currentUserId();
 
                    string resp = "[";
                    foreach (Group gr in ml.Users.Where(t => t.ID == CurrentUserID).FirstOrDefault().Groups.ToArray())
                    {
                        resp += "{\"name\":\"" + gr.GroupName + "\",\"id\":\"" + gr.ID + "\"},";
                    }
                    if (resp.LastIndexOf(',') != -1) resp = resp.Remove(resp.LastIndexOf(','));
                    resp += "]";
                    Response.Write(resp);
                }
            }
        }
    }
}