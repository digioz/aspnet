using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[Serializable()]
public class gbMessage
{
    private int ciID;
    private string csSubmitDate;
    private string csName;
    private string csEmail;
    private string csMessage;

    public gbMessage()
    {
        ciID = 0;
        csSubmitDate = "";
        csName = "";
        csEmail = "";
        csMessage = "";
    }

    public int ID
    {
        get { return ciID; }
        set { ciID = value; }
    }

    public string SubmitDate
    {
        get { return csSubmitDate; }
        set { csSubmitDate = value; }
    }

    public string Name
    {
        get { return csName; }
        set { csName = value; }
    }

    public string Email
    {
        get { return csEmail; }
        set { csEmail = value; }
    }

    public string Message
    {
        get { return csMessage; }
        set { csMessage = value; }
    }
}