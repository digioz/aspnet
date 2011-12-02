using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Configuration;

public class gbSerialize
{
    private string csPath;
    
    public gbSerialize(string psPath)
    {
        csPath = psPath;
    }
    
    public ArrayList SortArrayList(ArrayList paListUnsorted)
    {
        ArrayList loSortedArrayList = new ArrayList();
        ArrayList loSortedArrayListString = new ArrayList();
        ArrayList laArray = new ArrayList(2);
        string lsExtension = ".xml";
        int i = 0;
        
        for (i = 0; i <= paListUnsorted.Count - 1; i++) {
            paListUnsorted[i] = paListUnsorted[i].ToString().Replace(lsExtension, "");
            if (Utility.IsNumeric(paListUnsorted[i])) {
                loSortedArrayList.Add(Convert.ToInt32(paListUnsorted[i]));
            }
        }

        loSortedArrayList.Sort((IComparer)new Comparer());
        
        for (i = 0; i <= loSortedArrayList.Count - 1; i++) {
            loSortedArrayListString.Add(loSortedArrayList[i].ToString() + ".xml");
        }
        
        return loSortedArrayListString;
    }
    
    public ArrayList GetFileNames()
    {
        DirectoryInfo loMessages = new DirectoryInfo(csPath);
        FileInfo[] loMessage = loMessages.GetFiles("*.xml");
        ArrayList loFileNames = new ArrayList();
        ArrayList loFileNamesSorted = new ArrayList();
        int i = 0;
        
        for (i = 0; i <= loMessage.Length - 1; i++) {
            loFileNames.Add(loMessage[i].Name.ToString());
        }
        loFileNamesSorted = SortArrayList(loFileNames);
        return loFileNamesSorted;
    }
    
    public int GetNextId()
    {
        ArrayList laList = new ArrayList();
        string lsFile = String.Empty;
        int liId = 0;
        laList = GetFileNames();
        
        foreach (string lsFile2 in laList) {
            lsFile = lsFile2.Replace(".xml", "");
            if (Convert.ToInt32(lsFile) > liId) {
                liId = Convert.ToInt32(lsFile);
            }
        }
        return liId;
    }
    
    public string SerializeMessage(gbMessage loMessage)
    {
        string loResponse = "";
        try {
            XmlSerializer loMessageSerialize = new XmlSerializer(typeof(gbMessage));
            StreamWriter loWriteStream = new StreamWriter(csPath + "\\" + loMessage.ID.ToString() + ".xml");
            
            loMessageSerialize.Serialize(loWriteStream, loMessage);
            loResponse = "Message Stored Successfully!";
            loWriteStream.Close();
        }
        catch (Exception ex) {
            loResponse = "Error: " + ex.Message;
        }
        return loResponse;
    }
    
    public gbMessage DeserializeMessage(string lsId, ref string lsError)
    {
        string loResponse = "";
        gbMessage gbMessage = new gbMessage();
        try {
            XmlSerializer loMessage = new XmlSerializer(typeof(gbMessage));
            StreamReader loStreamReader = new StreamReader(csPath + "\\" + lsId);
            gbMessage = (gbMessage)loMessage.Deserialize(loStreamReader);
            loResponse = "Message Retrieved Successfully!";
            loStreamReader.Close();
        }
        catch (Exception ex) {
            loResponse = "Error: " + ex.Message;
        }
        return gbMessage;
    }
    
    public string DisplayMessage(gbMessage loMessage, string lsPath, string csPath)
    {
        string lsTemplate = "";
        string lsError = String.Empty;
        string lsTemplateName = ConfigurationManager.AppSettings["Template"];
        lsTemplate = GetFileContents(csPath + "\\templates\\" + lsTemplateName + "\\message_box.html",lsError);

        lsTemplate = lsTemplate.Replace("{TPLPATH}", lsPath + "/templates/" + lsTemplateName); // + "/");
        lsTemplate = lsTemplate.Replace("{ID}", loMessage.ID.ToString());
        lsTemplate = lsTemplate.Replace("{SUBMITDATE}", loMessage.SubmitDate);
        lsTemplate = lsTemplate.Replace("{NAME}", loMessage.Name);
        lsTemplate = lsTemplate.Replace("{EMAIL}", loMessage.Email);
        lsTemplate = lsTemplate.Replace("{MESSAGE}", SmileyFaces(loMessage.Message));
        //lsTemplate = Strings.Replace(lsTemplate, "{TPLPATH}", lsPath + "/templates/" + lsTemplateName + "/");
        //lsTemplate = Strings.Replace(lsTemplate, "{ID}", loMessage.Id);
        //lsTemplate = Strings.Replace(lsTemplate, "{SUBMITDATE}", loMessage.SubmitDate);
        //lsTemplate = Strings.Replace(lsTemplate, "{NAME}", loMessage.Name);
        //lsTemplate = Strings.Replace(lsTemplate, "{EMAIL}", loMessage.Email);
        //lsTemplate = Strings.Replace(lsTemplate, "{MESSAGE}", SmileyFaces(loMessage.Message));
        return lsTemplate;
    }
    
    public string GetFileContents(string FullPath, string ErrInfo)
    {
        string strContents = "";
        StreamReader objReader = default(StreamReader);
        try {
            objReader = new StreamReader(FullPath);
            strContents = objReader.ReadToEnd();
            objReader.Close();
        }
        catch (Exception Ex) {
            ErrInfo = Ex.Message;
        }
        return strContents;
    }
    
    public bool SaveTextToFile(string strData, string FullPath, string ErrInfo)
    {
        bool bAns = false;
        StreamWriter objReader = default(StreamWriter);
        
        try {
            objReader = new StreamWriter(FullPath);
            objReader.Write(strData);
            objReader.Close();
            bAns = true;
        }
        catch (Exception Ex) {
            ErrInfo = Ex.Message;
            bAns = false;
        }
        return bAns;
    }
    
    public string SmileyFaces(string strData)
    {
        string lsData = strData;
        string[][] laSmiley = new string[23][];
        string lsString = "";
        int i = 0;
        
        laSmiley[0] = new string[] { ":arrow:", "icon_arrow.gif" };
        laSmiley[1] = new string[] { ":D", "icon_biggrin.gif" };
        laSmiley[2] = new string[] { ":?", "icon_confused.gif" };
        laSmiley[3] = new string[] { "8)", "icon_cool.gif" };
        laSmiley[4] = new string[] { ":cry:", "icon_cry.gif" };
        laSmiley[5] = new string[] { ":shock:", "icon_eek.gif" };
        laSmiley[6] = new string[] { ":evil:", "icon_evil.gif" };
        laSmiley[7] = new string[] { ":!:", "icon_exclaim.gif" };
        laSmiley[8] = new string[] { ":(", "icon_frown.gif" };
        laSmiley[9] = new string[] { ":idea:", "icon_idea.gif" };
        laSmiley[10] = new string[] { ":lol:", "icon_lol.gif" };
        laSmiley[11] = new string[] { ":x", "icon_mad.gif" };
        laSmiley[12] = new string[] { ":green:", "icon_mrgreen.gif" };
        laSmiley[13] = new string[] { ":|", "icon_neutral.gif" };
        laSmiley[14] = new string[] { ":question:", "icon_question.gif" };
        laSmiley[15] = new string[] { ":P", "icon_razz.gif" };
        laSmiley[16] = new string[] { ":oops:", "icon_redface.gif" };
        laSmiley[17] = new string[] { ":roll:", "icon_rolleyes.gif" };
        laSmiley[18] = new string[] { ":)", "icon_smile.gif" };
        laSmiley[19] = new string[] { ":o", "icon_surprised.gif" };
        laSmiley[20] = new string[] { ":twisted:", "icon_twisted.gif" };
        laSmiley[21] = new string[] { ":wink:", "icon_wink.gif" };
        
        for (i = 0; i <= 21; i++) {
            lsString = "<img src=\"images/" + laSmiley[i][1] + "\" border=0>";
            lsData = lsData.Replace(laSmiley[i][0], lsString);
        }
        
        lsData = lsData.Replace("&nbsp;", " ");
        
        return lsData;
    }
}