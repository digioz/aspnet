using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public sealed class Alert
{
    public Alert()
    {
        // Constructor
    }

    public static void Show(string psMessage)
    {
        // Cleans the message to allow single quotation marks 
        string lsCleanMessage = psMessage.Replace("'", "'");
        string lsScript = "<script type=\"text/javascript\">alert('" + lsCleanMessage + "');</script>";

        // Gets the executing web page 
        Page loPage = HttpContext.Current.CurrentHandler as Page;

        // Checks if the handler is a Page and that the script isn't allready on the Page 
        if (loPage != null && !loPage.ClientScript.IsClientScriptBlockRegistered("alert"))
        {
            loPage.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", lsScript);
        }
    }
}
