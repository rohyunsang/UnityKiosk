using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;



public class Mongo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    string sftpPath = "220.149.231.136";
    [SerializeField]
    string fileName = "UnityTest";

    [SerializeField]
    string userName = "std5101";

    [SerializeField]
    string pwd = "ce5101";

    [SerializeField]
    string UploadDirectory = "RohTest";

    void Start()
    {
        UploadFile(sftpPath,fileName,userName,pwd,UploadDirectory);
    }

    public string UploadFile(string sftpPath, string fileName, string userName, string pwd, string
    UploadDirectory = "")
    {
        string PureFileName = new FileInfo(fileName).Name;
        string uploadPath = string.Format("{0}{1}/{2}", sftpPath, UploadDirectory, PureFileName);
        
        FtpWebRequest req = (FtpWebRequest)WebRequest.Create(uploadPath);
        req.Proxy = null;
        req.Method = WebRequestMethods.Ftp.UploadFile;
        req.Credentials = new NetworkCredential(userName, pwd);
        req.UseBinary = true;
        req.UsePassive = true;

        byte[] data = File.ReadAllBytes(fileName);
        req.ContentLength = data.Length;
        Stream stream = req.GetRequestStream();
        stream.Write(data, 0, data.Length);

        stream.Close();

        FtpWebResponse res = (FtpWebResponse)req.GetResponse();
        return res.StatusDescription;
    }

}
