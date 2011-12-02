using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class gbResponse
{
    private int ciResponseCode;
    private string csResponseDescription;

    public gbResponse()
    {
        ciResponseCode = 0;
        csResponseDescription = "";
    }

    public int ResponseCode
    {
        get { return ciResponseCode; }
        set
        {
            if (Utility.IsNumeric(value))
            {
                ciResponseCode = value;
            }
        }
    }

    public string ResponseDescription
    {
        get { return csResponseDescription; }
        set { csResponseDescription = value; }
    }
}