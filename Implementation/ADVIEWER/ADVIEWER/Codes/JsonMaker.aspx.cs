using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.DataModel;

namespace ADVIEWER.Codes
{
    public partial class JsonMaker : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {

            if (Request.QueryString["entity"] != null)
            {

                if (Request.QueryString["entity"] == "keyword")
                {
                    ModelContainer ml = new ModelContainer();
                    string resp = "[";
                    string q = Request.QueryString["q"];
                    foreach (KeyWord kw in ml.KeyWords.Where(t=>t.Text.Contains(q)))
                    {
                        resp += "{\"name\":\"" + kw.Text + "\",\"id\":\"" + kw.Id + "\"},";
                    }
                    if(resp.LastIndexOf(',')!=-1) resp = resp.Remove(resp.LastIndexOf(','));
                    resp += "]";
                    Response.Write(resp);
                }
            }
        }
    }
}