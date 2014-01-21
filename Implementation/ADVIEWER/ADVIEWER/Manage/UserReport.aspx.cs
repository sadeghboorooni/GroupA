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
    public partial class UserReport : System.Web.UI.Page
    {
        public int freeAdvsCount,staredAdvsCount;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadfreeGridView();
            //LoadStaredGridView();
        }

        private void LoadStaredGridView()
        {
            if (!string.IsNullOrEmpty(StartDateY.Text.ToString()) && !string.IsNullOrEmpty(StartDateM.Text.ToString()) && !string.IsNullOrEmpty(StartDateD.Text.ToString()) && !string.IsNullOrEmpty(EndDateY.Text.ToString()) && !string.IsNullOrEmpty(EndDateM.Text.ToString()) && !string.IsNullOrEmpty(EndDateD.Text.ToString()))
            {
                if (StartDateY.Text.ToString().Length == 3) 
                {
                    StartDateY.Text = "0"+StartDateY.Text.ToString();
                }
                if (StartDateY.Text.ToString().Length == 2)
                {
                    StartDateY.Text = "13" + StartDateY.Text.ToString();
                }
                if (StartDateY.Text.ToString().Length == 1)
                {
                    StartDateY.Text = "130" + StartDateY.Text.ToString();
                }
                if (StartDateM.Text.ToString().Length == 1)
                {
                    StartDateM.Text = "0" + StartDateM.Text.ToString();
                }
                if (StartDateD.Text.ToString().Length == 1)
                {
                    StartDateD.Text = "0" + StartDateD.Text.ToString();
                }


                if (EndDateY.Text.ToString().Length == 3)
                {
                    EndDateY.Text = "0" + EndDateY.Text.ToString();
                }
                if (EndDateY.Text.ToString().Length == 2)
                {
                    EndDateY.Text = "13" + EndDateY.Text.ToString();
                }
                if (EndDateY.Text.ToString().Length == 1)
                {
                    EndDateY.Text = "130" + EndDateY.Text.ToString();
                }
                if (EndDateM.Text.ToString().Length == 1)
                {
                    EndDateM.Text = "0" + EndDateM.Text.ToString();
                }
                if (EndDateD.Text.ToString().Length == 1)
                {
                    EndDateD.Text = "0" + EndDateD.Text.ToString();
                }

                staredAdvsGridView.DataSource = MemberFunctions.UserDataTable((StartDateY.Text.ToString() + StartDateM.Text.ToString() + StartDateD.Text.ToString()), (EndDateY.Text.ToString() + EndDateM.Text.ToString() + EndDateD.Text.ToString()));
            staredAdvsGridView.DataBind();
            staredAdvsCount = ((DataTable)staredAdvsGridView.DataSource).Rows.Count;
            }
        }

        private void LoadfreeGridView()
        {
            if (!string.IsNullOrEmpty(StartDateY.Text.ToString()) && !string.IsNullOrEmpty(StartDateM.Text.ToString()) && !string.IsNullOrEmpty(StartDateD.Text.ToString()) && !string.IsNullOrEmpty(EndDateY.Text.ToString()) && !string.IsNullOrEmpty(EndDateM.Text.ToString()) && !string.IsNullOrEmpty(EndDateD.Text.ToString()))
            {
                if (StartDateY.Text.ToString().Length == 3)
                {
                    StartDateY.Text = "0" + StartDateY.Text.ToString();
                }
                if (StartDateY.Text.ToString().Length == 2)
                {
                    StartDateY.Text = "13" + StartDateY.Text.ToString();
                }
                if (StartDateY.Text.ToString().Length == 1)
                {
                    StartDateY.Text = "130" + StartDateY.Text.ToString();
                }
                if (StartDateM.Text.ToString().Length == 1)
                {
                    StartDateM.Text = "0" + StartDateM.Text.ToString();
                }
                if (StartDateD.Text.ToString().Length == 1)
                {
                    StartDateD.Text = "0" + StartDateD.Text.ToString();
                }


                if (EndDateY.Text.ToString().Length == 3)
                {
                    EndDateY.Text = "0" + EndDateY.Text.ToString();
                }
                if (EndDateY.Text.ToString().Length == 2)
                {
                    EndDateY.Text = "13" + EndDateY.Text.ToString();
                }
                if (EndDateY.Text.ToString().Length == 1)
                {
                    EndDateY.Text = "130" + EndDateY.Text.ToString();
                }
                if (EndDateM.Text.ToString().Length == 1)
                {
                    EndDateM.Text = "0" + EndDateM.Text.ToString();
                }
                if (EndDateD.Text.ToString().Length == 1)
                {
                    EndDateD.Text = "0" + EndDateD.Text.ToString();
                }

                staredAdvsGridView.DataSource = MemberFunctions.AdReportNormal((StartDateY.Text.ToString() + StartDateM.Text.ToString() + StartDateD.Text.ToString()), (EndDateY.Text.ToString() + EndDateM.Text.ToString() + EndDateD.Text.ToString()));
                staredAdvsGridView.DataBind();
                staredAdvsCount = ((DataTable)staredAdvsGridView.DataSource).Rows.Count;
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
            CheckBox chkAdd;
            int rowCount;
            rowCount = staredAdvsGridView.Rows.Count;
            int i;
            //string reason = denyReasonStaredTextBox.Text;
            //if (string.IsNullOrEmpty(reason)) reason = "به یکی از دلایل ذیل آگهی شما تایید نشد: 1- متن تکراری. 2- متن کوتاه. 3- متن، عنوان یا کلمات کلیدی نامناسب. 4- آگهی مخالف با قوانین";
            //for (i = 0; i <= (rowCount - 1); i++)
            //{
            //    chkAdd = (CheckBox)staredAdvsGridView.Rows[i].FindControl("chkSelectAdd");
            //    int ID = int.Parse(staredAdvsGridView.DataKeys[i].Value.ToString());
            //    if (chkAdd.Checked == true)
            //    {
            //        MemberFunctions.DenyAdvertisment(ID, reason);
            //    }
            //}
            LoadStaredGridView();
        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadfreeGridView();
            LoadStaredGridView();
        }
       
        
    }
}