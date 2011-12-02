using System;
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

public partial class custom_controls_TopMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hlAddEntry.Text = ConfigurationManager.AppSettings["AddEntry"].ToString();
        hlAddEntry.NavigateUrl = "../Default.aspx";
        hlViewGuestbook.Text = ConfigurationManager.AppSettings["ViewGuestbook"].ToString();
        hlViewGuestbook.NavigateUrl = "../List.aspx";
        hlNewPostFirst.Text = ConfigurationManager.AppSettings["NewPostFirst"].ToString();
        hlNewPostFirst.NavigateUrl = "../List.aspx?page=1&order=asc";
        hlNewPostLast.Text = ConfigurationManager.AppSettings["NewPostLast"].ToString();
        hlNewPostLast.NavigateUrl = "../List.aspx?page=1&order=desc";
        hlAdmin.Text = ConfigurationManager.AppSettings["AdminPageName"].ToString();
        hlAdmin.NavigateUrl = "../Admin.aspx";
    }
}
