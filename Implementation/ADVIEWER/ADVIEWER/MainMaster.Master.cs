﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.BAL;

namespace ADVIEWER.Main
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGropus();
            makeStatesMenu();
        }

        protected void LoadGropus()
        {
            GroupsRepeater.DataSource = MemberFunctions.GetParentGroups();
            GroupsRepeater.DataBind();
        }

        protected void getSubGroupsFunc(object sender, RepeaterItemEventArgs e)
        {

            Literal ltrsub = e.Item.FindControl("GetSubGroups") as Literal;
            int id = int.Parse(ltrsub.Text);
            ltrsub.Text = "";
            AssignorGroup[] SubGroups = MemberFunctions.GetSubGroupsByID(id);
            foreach (AssignorGroup sub in SubGroups)
            {
                ltrsub.Text += string.Format(" <li><a  style=\"font-size:11pt\" href='../ShowGroupAdvs.aspx?ID={0}&Title={1} '>{2}</a></li>", sub.ID,sub.GroupName, sub.GroupName);

            }

        }

        private void makeStatesMenu()
        {

            List<AssignorStateCity> States = PublicFunctions.GetStatesAndCities().ToList();
            int stateCount = 2;

            string innerHtml = "<ul><li class=\"unstyled\"><div class=\"yamm-content\"><ul  class=\"unstyled\">\n";
            innerHtml += "<li style=\"list-style: none;padding-right:7px;margin:0;padding-top:5px;padding-left:7px;\"><a style=\"\" href='../StateCityList.aspx' title=\"لیست استان ها و شهرها\""  + ">" + "لیست استان ها و شهرها";
            innerHtml += "<i class=\"icon-arrow-left\" style=\"font-size: 10px;padding-left: 5px;color: rgb(90, 238, 90);\"></i>" + "</a></li>\n";
            foreach (AssignorStateCity sc in States.OrderBy(t => t.Name))
            {
                innerHtml += "<li style=\"list-style: none;padding-right:7px;margin:0;padding-top:5px;padding-left:7px;\"><a style=\"\" href='../ShowStateAdvs.aspx?" + "ID=" + sc.ID.ToString() + "&Title="  + sc.Name + "'";
                innerHtml += " title='" + "تبلیغات استان "  + sc.Name + "'" + ">";
                innerHtml += sc.Name;
                innerHtml += "</a></li>\n";
                if (stateCount++ % 5 == 0)
                {
                    innerHtml += "</ul>\n<ul class=\"unstyled\">\n";
                }
            }
            innerHtml += "</ul></div></li></ul>";

            statesDiv.InnerHtml = innerHtml;

        }

    }
}