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
    public partial class UnconfirmedAdvs : System.Web.UI.Page
    {
        public int freeAdvsCount,staredAdvsCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadfreeGridView();
            LoadStaredGridView();
        }

        private void LoadStaredGridView()
        {
            staredAdvsGridView.DataSource = MemberFunctions.UnconfirmedStaredAdvertismentsDataTable();
            staredAdvsGridView.DataBind();
            freeAdvsCount = ((DataTable)staredAdvsGridView.DataSource).Rows.Count;
        }

        private void LoadfreeGridView()
        {
            FreeAdvsGridView.DataSource = MemberFunctions.UnconfirmedFreeAdvertismentsDataTable();
            FreeAdvsGridView.DataBind();
            freeAdvsCount = ((DataTable)FreeAdvsGridView.DataSource).Rows.Count;
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

        protected void ConfirmFreeAdvsButton_Click(object sender, EventArgs e)
        {
            CheckBox chkAdd;
            int rowCount;
            rowCount = FreeAdvsGridView.Rows.Count;
            int i;
            for (i = 0; i <= (rowCount - 1); i++)
            {
                chkAdd = (CheckBox)FreeAdvsGridView.Rows[i].FindControl("chkSelectAdd");
                int ID = int.Parse(FreeAdvsGridView.DataKeys[i].Value.ToString());
                if (chkAdd.Checked == true)
                {
                    MemberFunctions.ConfirmAdvertisment(ID);
                }
            }

            LoadfreeGridView();
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

        protected void DenyFreeAdvsButton_Click(object sender, EventArgs e)
        {
            CheckBox chkAdd;
            int rowCount;
            rowCount = FreeAdvsGridView.Rows.Count;
            int i;
            string reason = TextBox2.Text;
            if (string.IsNullOrEmpty(reason)) reason = "به یکی از دلایل ذیل آگهی شما تایید نشد: 1- متن تکراری. 2- متن کوتاه. 3- متن، عنوان یا کلمات کلیدی نامناسب. 4- آگهی مخالف با قوانین";
            for (i = 0; i <= (rowCount - 1); i++)
            {
                chkAdd = (CheckBox)FreeAdvsGridView.Rows[i].FindControl("chkSelectAdd");
                int ID = int.Parse(FreeAdvsGridView.DataKeys[i].Value.ToString());
                if (chkAdd.Checked == true)
                {
                    MemberFunctions.DenyAdvertisment(ID, reason);
                }
            }
            LoadfreeGridView();
        }

        protected void DenyStaredAdvsButton_Click(object sender, EventArgs e)
        {
            CheckBox chkAdd;
            int rowCount;
            rowCount = staredAdvsGridView.Rows.Count;
            int i;
            string reason = denyReasonStaredTextBox.Text;
            if (string.IsNullOrEmpty(reason)) reason = "به یکی از دلایل ذیل آگهی شما تایید نشد: 1- متن تکراری. 2- متن کوتاه. 3- متن، عنوان یا کلمات کلیدی نامناسب. 4- آگهی مخالف با قوانین";
            for (i = 0; i <= (rowCount - 1); i++)
            {
                chkAdd = (CheckBox)staredAdvsGridView.Rows[i].FindControl("chkSelectAdd");
                int ID = int.Parse(staredAdvsGridView.DataKeys[i].Value.ToString());
                if (chkAdd.Checked == true)
                {
                    MemberFunctions.DenyAdvertisment(ID, reason);
                }
            }
            LoadStaredGridView();
        }

        
    }
}