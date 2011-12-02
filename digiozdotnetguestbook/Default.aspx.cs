using System;
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

public partial class _Default : System.Web.UI.Page 
{
    string csPath = HttpContext.Current.Server.MapPath(".") + "\\App_Data";
    string csConfigPath = HttpContext.Current.Server.MapPath(".") + "\\config";
    string csVerifyCode = ConfigurationManager.AppSettings["VerifyCode"];

    private string GetVisitorIP()
    {
        string lsIPAddress = string.Empty;

        lsIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (lsIPAddress == string.Empty) lsIPAddress = Request.ServerVariables["REMOTE_ADDR"];

        return lsIPAddress;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (csVerifyCode == "1")
        {
            lblVerifyCode.Visible = true;
            ImgVerifyCode.Visible = true;
            txtVerifyCode.Visible = true;
            ImgVerifyCode.ImageUrl = "ImageVerify.aspx";
        }
        else
        {
            lblVerifyCode.Visible = false;
            ImgVerifyCode.Visible = false;
            txtVerifyCode.Visible = false;
        }
    }

    protected void Smiley_Click(object sender, EventArgs e)
    {
        ImageButton imgClicked = (ImageButton)sender;
        yourmessage.Text += " " + imgClicked.AlternateText + " ";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string loCleanName = "";
        string loCleanEmail = "";
        gbValidation loValidation = new gbValidation();
        gbResponse loResponse = null;
        string lsIP = string.Empty;

        try
        {
            if (csVerifyCode == "1")
            {
                if (txtVerifyCode.Text != Convert.ToString(System.Web.HttpContext.Current.Session["imagecode"]))
                {
                    lblResponse.ForeColor = System.Drawing.Color.Red;
                    lblResponse.Text = "<center>Wrong Image Verification Code!</center>";
                    lblVerifyCode.ForeColor = System.Drawing.Color.Red;
                    lblVerifyCode.ToolTip = "Wrong Image Verification Code!";
                    Alert.Show("Wrong Image Verification Code!");
                    return;
                }
            }

            if (loValidation.IsEmail(youremail.Text) != true)
            {
                lblResponse.ForeColor = System.Drawing.Color.Red;
                lblResponse.Text = "<center>Invalid Email. Please Enter a Valid Email!</center>";
                lblVerifyCode.ForeColor = System.Drawing.Color.Red;
                lblVerifyCode.ToolTip = "Invalid Email. Please Enter a Valid Email";
                Alert.Show("Invalid Email. Please Enter a Valid Email!");
                return;
            }

            if (loValidation.IsSpam(yourmessage.Text, csConfigPath, GetVisitorIP()))
            {
                lblResponse.ForeColor = System.Drawing.Color.Red;
                lblResponse.Text = "<center>Spam detected in your message. Your IP was logged!</center>";
                Alert.Show("Spam detected in your message. Your IP was logged!");
                return;
            }

            gbSerialize lsSerialize = new gbSerialize(csPath);
            int liId = lsSerialize.GetNextId() + 1;
            gbMessage loMessage = new gbMessage();
            string lsResponse = "";
            UBBCode loUBBCode = new UBBCode(yourmessage.Text);

            loCleanName = gbValidation.CleanString(yourname.Text);
            loCleanEmail = gbValidation.CleanString(youremail.Text);

            {
                loMessage.ID = liId;
                loMessage.SubmitDate = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToShortTimeString().ToString();
                loMessage.Name = loCleanName;
                loMessage.Email = loCleanEmail;
                loMessage.Message = loUBBCode.HTMLCode;
            }

            lsResponse = lsSerialize.SerializeMessage(loMessage);

            loResponse = new gbResponse();
            loResponse.ResponseCode = 1;
            loResponse.ResponseDescription = lsResponse;

            Session["ResponsePost"] = loResponse;
            Response.Redirect("Response.aspx");
        }
        catch (Exception ex)
        {
            lblResponse.Text = "<center>Error: " + ex.Message.ToString() + "</center>";
        }
    }
}
