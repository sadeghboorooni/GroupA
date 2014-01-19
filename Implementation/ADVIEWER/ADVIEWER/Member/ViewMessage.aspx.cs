using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Member
{
    public partial class ViewMessage : System.Web.UI.Page
    {
        public string MessageText, MessageDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            int MessageID = int.Parse(Request.QueryString["id"]);
            AssignorMessage CurMessage = MemberFunctions.GetMessageByID(MessageID);
            MessageText = CurMessage.Text;
            MessageDate = PublicFunctions.SolarDateConvertor(CurMessage.RegistrationDate);
        }
    }
}