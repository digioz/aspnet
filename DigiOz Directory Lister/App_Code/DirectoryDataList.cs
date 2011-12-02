using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.ComponentModel;

namespace digioz.DirectoryLister
{
    public class DirectoryDataList : BindingList<DirectoryFile>
    {
	    public DirectoryDataList()
	    { }
    }
}

