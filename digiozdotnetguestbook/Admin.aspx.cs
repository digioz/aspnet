using System;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml;


public partial class Admin : System.Web.UI.Page
{
    public int ciPage;
    public bool cbOrder;
    public string csPath = HttpContext.Current.Server.MapPath(".");
    public string ciMsgPerPage = ConfigurationManager.AppSettings["MessagesPerPage"].ToString();
    public string csAdminUsername = ConfigurationManager.AppSettings["AdminUsername"].ToString();
    public string csAdminPassword = ConfigurationManager.AppSettings["AdminPassword"].ToString();

    //public int RoundUp(decimal num)
    //{
    //    int functionReturnValue = 0;
    //    if ((num - Convert.ToInt32(num) != 0))
    //    {
    //        functionReturnValue = Convert.ToInt32(num) + 1;
    //    }
    //    else
    //    {
    //        functionReturnValue = Convert.ToInt32(num);
    //    }
    //    return functionReturnValue;
    //}

    //public void GetStartAndEnd(ref int liStart, ref int liEnd, int liTotalCount, int liPage, bool lbOrder)
    //{
    //    if (cbOrder == true)
    //    {
    //        // asc
    //        if (liTotalCount < Convert.ToInt32(ciMsgPerPage))
    //        {
    //            liStart = 0;
    //            liEnd = liTotalCount;
    //        }
    //        else
    //        {
    //            liStart = (liPage - 1) * Convert.ToInt32(ciMsgPerPage);
    //            liEnd = (liStart + Convert.ToInt32(ciMsgPerPage)) - 1;
    //            if (liEnd > liTotalCount)
    //            {
    //                liEnd = liTotalCount;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        // desc
    //        if (liTotalCount < Convert.ToInt32(ciMsgPerPage))
    //        {
    //            liStart = liTotalCount;
    //            liEnd = 0;
    //        }
    //        else
    //        {
    //            liStart = liTotalCount - ((liPage - 1) * Convert.ToInt32(ciMsgPerPage));
    //            liEnd = (liStart - Convert.ToInt32(ciMsgPerPage)) + 1;
    //            if (liEnd < 0)
    //            {
    //                liEnd = 0;
    //            }
    //        }
    //    }
    //}

    //public string GenerateNavigation(int liTotalCount, int liPage, bool lbOrder)
    //{
    //    string lsNavigation = "";
    //    decimal ldRatio = (decimal)liTotalCount / Convert.ToDecimal(ciMsgPerPage);
    //    int i = 0;
    //    string lsOrder = null;

    //    if (lbOrder == true)
    //    {
    //        lsOrder = "desc";
    //    }
    //    else
    //    {
    //        lsOrder = "asc";
    //    }

    //    if (ldRatio < 1)
    //    {
    //        lsNavigation = "Page <a href=\"List.aspx\">1</a>";
    //    }
    //    else
    //    {
    //        lsNavigation = "Page ";
    //        for (i = 1; i < RoundUp(ldRatio); i++)
    //        {
    //            lsNavigation += "<a href=\"Admin.aspx?page=" + i + "&order=" + lsOrder + "\">" + i + "</a> ";
    //        }
    //    }

    //    return lsNavigation;
    //}
    
    protected void AdminLoginControl_Authenticate(object sender, AuthenticateEventArgs e)
    {
        Session["AdminUsername"] = AdminLoginControl.UserName;
        Session["AdminPassword"] = AdminLoginControl.Password;
        Response.Redirect("Admin.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["AdminUsername"]) == csAdminUsername && Convert.ToString(Session["AdminPassword"]) == csAdminPassword)
        {
            // Login Successfull!
            AdminLoginControl.Visible = false;
            MsgDisplay.Visible = true;
            lblNavigation.Visible = true;

            // Check if Message Needs to be Deleted ---------------------

            if (Utility.IsNumeric(Request.QueryString["msg"]))
            {
                try
                {
                    File.Delete(csPath + "\\App_Data\\" + Request.QueryString["msg"] + ".xml");
                    MsgDisplay.Text = "Message Removed!<br /><a href=\"Admin.aspx\">Click Here</a> to continue.";
                    return;
                }
                catch (Exception ex)
                {
                    MsgDisplay.Text = "Could not remove message!";

                }
            }

            // Actual Display of Messages -------------------------------

            try
            {
                ciPage = Convert.ToInt32(Request.QueryString["page"].ToString());
            }
            catch (Exception ex)
            {
                ciPage = 1;
            }

            if (Request.QueryString["order"] == "desc")
            {
                cbOrder = true;
            }
            else
            {
                cbOrder = false;
            }

            try
            {
                ArrayList laFiles = new ArrayList();
                string lsError = "";
                int i = 0;
                int liStart = 0;
                int liEnd = 0;
                gbSerialize coSerialize = new gbSerialize(csPath + "\\App_Data");
                string lsPath = Request.ApplicationPath;

                laFiles = coSerialize.GetFileNames();
                Utility.GetStartAndEnd(ref liStart, ref liEnd, laFiles.Count, ciPage, cbOrder, Convert.ToInt16(ciMsgPerPage));

                if (cbOrder == true)
                {
                    for (i = liStart; i < liEnd; i++)
                    {
                        gbMessage loMessage = new gbMessage();
                        loMessage = coSerialize.DeserializeMessage(laFiles[i].ToString(), ref lsError);
                        MsgDisplay.Text += "<a href=\"Admin.aspx?msg=" + loMessage.ID + "\">Delete Message</a>";
                        MsgDisplay.Text += coSerialize.DisplayMessage(loMessage, lsPath, csPath);
                    }
                }
                else
                {
                    for (i = liStart; i > (liEnd); i--)
                    {
                        gbMessage loMessage = new gbMessage();
                        loMessage = coSerialize.DeserializeMessage(laFiles[i - 1].ToString(), ref lsError);
                        MsgDisplay.Text += "<a href=\"Admin.aspx?msg=" + loMessage.ID + "\">Delete Message</a>";
                        MsgDisplay.Text += coSerialize.DisplayMessage(loMessage, lsPath, csPath);
                    }
                }

                lblNavigation.Text = Utility.GenerateNavigation(laFiles.Count, ciPage, cbOrder,"Admin", Convert.ToInt16(ciMsgPerPage));
            }
            catch (XmlException ex)
            {
                Response.Write("<b>Error</b>: " + ex.Message.ToString());

            }
        }
        else
        {
            // Login Failed!
            AdminLoginControl.Visible = true;
            MsgDisplay.Visible = false;
            lblNavigation.Visible = false;
        }
    }

}
