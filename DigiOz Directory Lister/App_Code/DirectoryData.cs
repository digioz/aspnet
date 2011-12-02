using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace digioz.DirectoryLister
{
    public class DirectoryFile
    {
        private string csFileName;
        private DateTime cdDateCreated;
        private DateTime cdDateModified;
        private double cdSize;

        public DirectoryFile()
	    { }

        public string FileName
        {
           get { return csFileName; }
            set { csFileName = value; }
        }

        public DateTime DateCreated
        {
            get { return cdDateCreated; }
            set { cdDateCreated = value; }
        }

        public DateTime DateModified
        {
            get { return cdDateModified; }
            set { cdDateModified = value; }
        }

        public double Size
        {
            get { return cdSize; }
            set { cdSize = value; }
        }
    }
}

