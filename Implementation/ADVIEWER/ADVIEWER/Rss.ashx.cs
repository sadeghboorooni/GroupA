using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Web;
using RssToolkit.Rss;
using ADVIEWER.BAL;

namespace ADVIEWER
{
    /// <summary>
    /// Summary description for Rss
    /// </summary>
    public class Rss : RssDocumentHttpHandler
    {
        protected override void PopulateRss(string rssName, string userName)
        {
            AssignorAdvertisment[] rAssignorAdvertisment = PublicFunctions.GetLast9Advs();
            Rss.Channel = new RssChannel();
            Rss.Version = "2.0";
            Rss.Channel.Title = "تبلیغ نما";
            Rss.Channel.PubDate = "Tue, 10 Apr 2007 23:01:10 GMT";
            Rss.Channel.LastBuildDate = DateTime.Now.ToString("R");
            Rss.Channel.Description = "Adviewer Rss";
            Rss.Channel.Generator = "adviewer";
            Rss.Channel.Language = "en";
            Rss.Channel.Link = "http://adviewer.ir";
            Rss.Channel.Docs = "http://adviewer.ir";
            Rss.Channel.Items = new List<RssItem>();
            foreach (AssignorAdvertisment adv in rAssignorAdvertisment)
            {
                RssItem advitem = new RssItem();
                advitem.Title = adv.Title;
                advitem.Author = adv.FullName;
                advitem.PubDate = adv.LastRenewal.ToString("R");
                advitem.Description ="<div style=\"line-height:1.3; font-family: Tahoma; font-size: 8pt; direction: rtl; text-align: center\">"
                    + "<p align=\"center\" dir=\"rtl\">";
                    if (adv.Pic != "")
                    {
                        advitem.Description += "<a href = \"http://www.adviewer.ir/advcontent.aspx?id=" + adv.ID + "\">" +
                        " <img src =\"http://adviewer.ir" + adv.Pic.Replace("~","")  + "\" style = 'max-width:200px; float:right'/>" + "</a>";
                    }

                    advitem.Description += "</p> </div>";
                    advitem.Description += "<div style=\"line-height:1.5em; font-family:Tahoma;font-size: 8pt; direction:rtl; text-align:right;\">"
                                        + "<p align=\"right\" dir=\"rtl\">";
                    advitem.Description += adv.Description;
                    advitem.Description += "</p> </div>";
                if (adv.StateCity != null)
                {
                    advitem.Description +=
                        "<div style=\"direction: rtl; text-align: center\"><p align=\"right\" dir=\"rtl\"> ";
                    if (adv.StateCity.StateId != null)
                    {
                        adv.Description +=
                            "<span style='font-size=17px;color:blue'>آگهی مربوط به استان:</span> استان " +
                            "<a style='color:green' href = \"http://www.adviewer.ir/ShowStateAdvs.aspx?id=" +
                            adv.StateCity.StateId + "\">" + adv.StateCity.State.Name + "</a>"
                            + " شهر  " + "<a style='color:green' href = \"http://www.adviewer.ir/ShowStateAdvs.aspx?id=" +
                            adv.StateCityID + "\">" + adv.StateCity.Name + "</a>" +
                            "</p></div>"
                            ;
                    }
                    else
                    {
                        advitem.Description +=
                            "<span style='font-size=17px;color:blue'>آگهی مربوط به استان:</span>  استان " +
                            "<a style='color:green' href = \"http://www.adviewer.ir/ShowStateAdvs.aspx?id=" +
                            adv.StateCityID + "\">" + adv.StateCity.Name + "</a>" +
                            "</tr></td>";
                    }
                }

                if (adv.Group != null)
                {
                    advitem.Description +=
                        "<div style=\"direction: rtl; text-align: center\"><p align=\"right\" dir=\"rtl\"> ";
                    if (adv.Group.ParentID != null)
                    {
                        advitem.Description +=
                            "<span style='font-size=17px;color:blue'>آگهی مربوط به گروه:</span> گروه  " +
                            "<a style='color:green' href = \"http://www.adviewer.ir/ShowGroupAdvs.aspx?id=" +
                            adv.Group.ParentID + "\">" + adv.Group.ParentGroup.GroupName + "</a>"
                            + "  زیرگروه  " +
                            "<a style='color:green' href = \"http://www.adviewer.ir/ShowGroupAdvs.aspx?id=" +
                            adv.GroupID + "\">" + adv.Group.GroupName + "</a>" +
                            "</tr></td>"
                            ;
                    }
                    else
                    {
                        advitem.Description +=
                            "<span style='font-size=17px;color:blue'>آگهی مربوط به گروه :</span> گروه  " +
                            "<a style='color:green' href = \"http://www.adviewer.ir/ShowGroupAdvs.aspx?id=" +
                            adv.GroupID + "\">" + adv.Group.GroupName + "</a>" +
                            "</tr></td>";
                    }
                }


                advitem.Link = "http://adviewer.ir/Advcontent.aspx?id=" + adv.ID;
                advitem.Guid = new RssGuid();
                advitem.Guid.Text = "http://adviewer.ir/Advcontent.aspx?id=" + adv.ID;
                

                Rss.Channel.Items.Add(advitem);
            }

            
        }
    }
}