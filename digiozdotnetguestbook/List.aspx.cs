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

public partial class List : System.Web.UI.Page
{
    public int ciPage;
    public bool cbOrder;
    public string csPath = HttpContext.Current.Server.MapPath(".");
    public string ciMsgPerPage = ConfigurationManager.AppSettings["MessagesPerPage"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
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
            string lsError = String.Empty;
            int i = 0;
            int liStart = 0;
            int liEnd = 0;
            gbSerialize coSerialize = new gbSerialize(csPath + "\\App_Data");
            string lsPath = Request.ApplicationPath;
            
            laFiles = coSerialize.GetFileNames();
            Utility.GetStartAndEnd(ref liStart, ref liEnd, laFiles.Count, ciPage, cbOrder, Convert.ToInt16(ciMsgPerPage));

            if (cbOrder)
            {
                for (i=liStart; i<liEnd; i++)
                {
                    gbMessage loMessage = new gbMessage();
                    loMessage = (gbMessage)coSerialize.DeserializeMessage(laFiles[i].ToString(), ref lsError);
                    MsgDisplay.Text += coSerialize.DisplayMessage(loMessage, lsPath, csPath);
                }
            }
            else
            {
                for (i=liStart; i> liEnd; i--)
                {
                    gbMessage loMessage = new gbMessage();
                    loMessage = (gbMessage)coSerialize.DeserializeMessage(laFiles[i - 1].ToString(), ref lsError);
                    MsgDisplay.Text += coSerialize.DisplayMessage(loMessage, lsPath, csPath);
                }
            }

            lblNavigation.Text = Utility.GenerateNavigation(laFiles.Count, ciPage, cbOrder, "List", Convert.ToInt16(ciMsgPerPage));
        }
        catch (Exception ex)
        {
            Response.Write("<b>Error</b>: " + ex.Message.ToString());
        }
    }
}
