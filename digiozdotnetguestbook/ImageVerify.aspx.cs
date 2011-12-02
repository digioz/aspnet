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

public partial class ImageVerify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CImgVerify cI = new CImgVerify();
        string sTxt = cI.getRandomAlphaNumeric();
        System.Web.HttpContext.Current.Session["imagecode"] = sTxt;
        System.Drawing.Bitmap bmp = cI.generateImage(sTxt);

        Response.ContentType = "image/gif";
        bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);

        bmp.Dispose();
    }
}
