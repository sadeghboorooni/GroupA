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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["entity"] != null) 
            {
                if (Request.QueryString["entity"] == "keyword")
                {
                    ModelContainer ml = new ModelContainer();
                    string resp = "[";

                    foreach (KeyWord kw in ml.KeyWords) 
                    {
                        resp+="{\"name\":\""+kw.Text+"\",\"id\":\""+kw.Id+"\"},";
                    }
                    resp += "]";
                    Response.Write(resp);
                }
            }
        }
    }
}