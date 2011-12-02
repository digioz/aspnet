using System;
using System.IO;
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
    public class DirectoryDataManager
    {      
        private string csFilePath;
        private string csFileExtenstion;
        private string csRelativePath;

        public DirectoryDataManager()
	    {
            csFilePath = String.Empty;
            csFileExtenstion = String.Empty;

            LoadConfigurationSettings();        
        }

        public string FilePath
        {
            get { return csFilePath; }
            set { csFilePath = value; }
        }

        public string FileExtenstion
        {
            get { return csFileExtenstion; }
            set { csFileExtenstion = value; }
        }

        public string RelativePath
        {
            get { return csRelativePath; }
            set { csRelativePath = value; }
        }

        public DirectoryDataList GetDirectoryFiles()
        {
            DirectoryFile loFile;
            DirectoryDataList loFiles = new DirectoryDataList();
            DirectoryInfo loDir = new DirectoryInfo(csFilePath);
            FileInfo[] loFileListSRC = loDir.GetFiles("*." + csFileExtenstion);

            foreach (FileInfo loFileSRC in loFileListSRC)
            {
                loFile = new DirectoryFile();

                loFile.FileName = loFileSRC.Name;
                loFile.DateCreated = loFileSRC.CreationTime;
                loFile.DateModified = loFileSRC.LastWriteTime;
                loFile.Size = loFileSRC.Length / 1024;

                loFiles.Add(loFile);
            }

            return loFiles;
        }

        public void LoadConfigurationSettings()
        {
            csFilePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            csFileExtenstion = ConfigurationManager.AppSettings["FileExtension"].ToString();
            csRelativePath = ConfigurationManager.AppSettings["RelativePath"].ToString();
        }
    }
}

