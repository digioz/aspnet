using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using digioz.DirectoryLister;

public partial class _Default : System.Web.UI.Page 
{
    public string csRelativePath;

    protected void Page_Load(object sender, EventArgs e)
    {
        DirectoryDataManager loDirectoryManager = new DirectoryDataManager();
        DirectoryDataList loDirectoryList;

        csRelativePath = loDirectoryManager.RelativePath;
        loDirectoryList = loDirectoryManager.GetDirectoryFiles();

        GridViewFiles.DataSource = loDirectoryList;
        GridViewFiles.DataBind();
    }
}
