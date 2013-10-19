using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.Codes;

namespace ADVIEWER.Manage
{
    public partial class UnconfirmedAdvs : System.Web.UI.Page
    {
        public string adiCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            FreeAdvsGridView.DataSource = memberCodes.unconfirmedFreeAdvertismentsDataTable();
            FreeAdvsGridView.DataBind();
        }
        protected void FreeAdvsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int index = e.NewPageIndex + 1;
            string url = Request.Url.GetLeftPart(UriPartial.Path);

            e.Cancel = true; ;
            Response.Redirect(string.Format("{0}?epage={1}", url, index));
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //DataAccessDataContext _data = new DataAccessDataContext();
            //CheckBox chkAdd;
            //int rowCount;
            //rowCount = GridView2.Rows.Count;
            //int i;
            //for (i = 0; i <= (rowCount - 1); i++)
            //{
            //    chkAdd = (CheckBox)GridView2.Rows[i].FindControl("chkSelectAdd");
            //    long ID = long.Parse(GridView2.DataKeys[i].Value.ToString());
            //    if (chkAdd.Checked == true)
            //    {
            //        _data.Confirm_Agahi(ID);
            //    }
            //}

            //GridView2.DataBind();
            //getCount();
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            //DataAccessDataContext _data = new DataAccessDataContext();
            //CheckBox chkAdd;
            //int rowCount;
            //rowCount = GridView2.Rows.Count;
            //int i;
            //string reason = TextBox2.Text;
            //if (string.IsNullOrEmpty(reason)) reason = "به یکی از دلایل ذیل آگهی شما تایید نشد: 1- متن تکراری. 2- متن کوتاه. 3- متن، عنوان یا کلمات کلیدی نامناسب. 4- آگهی مخالف با قوانین";
            //for (i = 0; i <= (rowCount - 1); i++)
            //{
            //    chkAdd = (CheckBox)GridView2.Rows[i].FindControl("chkSelectAdd");
            //    long ID = long.Parse(GridView2.DataKeys[i].Value.ToString());
            //    if (chkAdd.Checked == true)
            //    {
            //        _data.UnConfirm_Agahi(ID, reason);
            //    }
            //}
            //GridView2.DataBind();
            //getCount();
        }
    }
}