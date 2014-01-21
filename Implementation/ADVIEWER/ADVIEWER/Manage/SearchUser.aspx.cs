using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;
using System.Data;

namespace ADVIEWER.Manage
{
    public partial class SearchUser : System.Web.UI.Page
    {
        public int freeAdvsCount,staredAdvsCount;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void LoadStaredGridView()
        {


            if (name.Text.ToString() == "__")
                name.Text = "";
            if (email.Text.ToString() == "__")
                email.Text = "";
            if (user_id.Text.ToString() == "__")
                user_id.Text = "";

                staredAdvsGridView.DataSource = MemberFunctions.UserDataTable2(name.Text.ToString(),email.Text.ToString(),user_id.Text.ToString());
                staredAdvsGridView.DataBind();
                staredAdvsCount = ((DataTable)staredAdvsGridView.DataSource).Rows.Count;
                if (string.IsNullOrEmpty(name.Text.ToString())) 
                {
                    name.Text = "__";
                }
                if (string.IsNullOrEmpty(user_id.Text.ToString()))
                {
                    user_id.Text = "__";
                }
                if (string.IsNullOrEmpty(email.Text.ToString()))
                {
                    email.Text = "__";
                }
            
        }

        
        protected void FreeAdvsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int index = e.NewPageIndex + 1;
            string url = Request.Url.GetLeftPart(UriPartial.Path);

            e.Cancel = true; ;
            Response.Redirect(string.Format("{0}?epage={1}", url, index));
        }
        protected void staredAdvsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int index = e.NewPageIndex + 1;
            string url = Request.Url.GetLeftPart(UriPartial.Path);

            e.Cancel = true; ;
            Response.Redirect(string.Format("{0}?epage={1}", url, index));
        }


        protected void ConfirmStaredAdvsButton_Click(object sender, EventArgs e)
        {
            CheckBox chkAdd;
            int rowCount;
            rowCount = staredAdvsGridView.Rows.Count;
            int i;
            for (i = 0; i <= (rowCount - 1); i++)
            {
                chkAdd = (CheckBox)staredAdvsGridView.Rows[i].FindControl("chkSelectAdd");
                int ID = int.Parse(staredAdvsGridView.DataKeys[i].Value.ToString());
                if (chkAdd.Checked == true)
                {
                    MemberFunctions.ConfirmAdvertisment(ID);
                    
                }
            }

            LoadStaredGridView();
        }

        

        protected void DenyStaredAdvsButton_Click(object sender, EventArgs e)
        {
            
            int rowCount;
            rowCount = staredAdvsGridView.Rows.Count;
            
            
            LoadStaredGridView();
        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            LoadStaredGridView();
        }
       
        
    }
}