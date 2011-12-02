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

public partial class Response : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            gbResponse loResponse = (gbResponse)Session["ResponsePost"];
            MsgDisplay.Text = "<center>" + loResponse.ResponseDescription + "</center>";
        }
        catch (Exception ex)
        {
            MsgDisplay.Text = ex.Message.ToString();
        }

        MsgDisplay.Text += "<br /><br /><center><a href=\"List.aspx\">Click Here To Continue</a></center>";
    }
}
