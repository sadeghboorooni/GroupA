﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADVIEWER.DataModel;
using ADVIEWER.Codes;

namespace ADVIEWER.Member
{
    public partial class AddNewAdv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            
=======

>>>>>>> 880d0349c902102dc505ae51ede2863ad2ad430e
            if (string.IsNullOrEmpty(AdvTitleTxt.Text) || string.IsNullOrEmpty(AdvTexttxt.Text) || string.IsNullOrEmpty(Nametxt.Text) || string.IsNullOrEmpty(KeyWordtxt.Text))
            {
                ltr_error.Text = "فیلدهای الزامی را کامل کنید";
                ltr_error.Visible = true;

                return;
            }

            Advetisement newadv = new Advetisement();

            newadv.User = AccountCodes.currentUser();

            newadv.Title = AdvTitleTxt.Text;
            newadv.Description= AdvShorttxt.Text;
            newadv.Text = System.Text.RegularExpressions.Regex.Replace(AdvTexttxt.Text, "<[^>]*>", string.Empty);
            foreach (KeyWord kw in memberCodes.ParseKeyWords(KeyWordtxt.Text)) 
            {
                newadv.KeyWords.Add(kw);
            }
            newadv.Link = Linktxt.Text;
            newadv.Address = Addresstxt.Text;
            newadv.FullName = Nametxt.Text;
            newadv.Tell = TellTimetxt.Text;
            newadv.Mobile = Mobiletxt.Text;
            newadv.Price = Pricetxt.Text;
            newadv.TellTime = TellTimetxt.Text;
            newadv.Email = Emailtxt.Text;
            newadv.YahooID = YahooIDtxt.Text;
            if (newadv.Link.ToLower().Trim() == "http://") newadv.Link = "";
            newadv.StarCount = int.Parse(AdvKindDrop.SelectedValue);
            newadv.AdvDuration = int.Parse(MonthDrop.SelectedValue);
            
            


            memberCodes.MakeNewAdvertisment(newadv);
        }
      
    }
}