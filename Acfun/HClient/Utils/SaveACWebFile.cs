using System;
using System.IO;
using System.Net;
namespace HClient.Utils
{
    internal class SaveACWebFile
    {

        public string GetImgPath(String imagePath,bool isCover) 
        {
            if (imagePath == "")
            {
                return "";
            }
            if (isCover)
            {
                HttpWebRequest temprequest = (HttpWebRequest)WebRequest.Create(imagePath);
                HttpWebResponse tempresponse = null;
                try
                {
                    tempresponse = (HttpWebResponse)temprequest.GetResponse();
                    imagePath = tempresponse.ResponseUri.ToString();
                }
                catch (Exception e)
                {
                    // e.Message;
                    return "404";
                }
                if (tempresponse.StatusCode != HttpStatusCode.OK)
                    return "";
            }
            return imagePath;
        }
        /// <summary>
        /// get image by webpath like:http://127.0.0.1/pic/Default.aspx
        /// </summary>
        /// <param name="imagePath"></param>
        public string SaveWebImage(String imagePath, String savePath,bool isCover)
        {
            if (imagePath == "")
            {
                return "";
            }
            if (isCover)
            {
                HttpWebRequest temprequest = (HttpWebRequest)WebRequest.Create(imagePath);
                HttpWebResponse tempresponse = null;
                try
                {
                    tempresponse = (HttpWebResponse)temprequest.GetResponse();
                    imagePath = tempresponse.ResponseUri.ToString();
                }
                catch (Exception e)
                {
                    // e.Message;
                    return "404";
                }
                if (tempresponse.StatusCode != HttpStatusCode.OK)
                    return "";
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imagePath);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.57 Safari/537.36";
            request.Timeout = 60000;
            request.ServicePoint.ConnectionLimit = 500;
            request.ReadWriteTimeout = 60000;
            request.Method = "GET";
            HttpWebResponse response = null;
            
            try {
               response = (HttpWebResponse)request.GetResponse();
               
            }catch(Exception e)
            {
               // e.Message;
                return "404";
            }
            if (response.StatusCode != HttpStatusCode.OK)
                return "";


            Stream resStream = response.GetResponseStream();
            int count = (int)response.ContentLength;
            if (count == -1)
            {
                count = 1000000;
            }
            int offset = 0;
            byte[] buf = new byte[count];
            try
            {
                while (count > 0)
                {
                    int n = resStream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
            }
            catch 
            {
            
            }
            string fileName = savePath + Guid.NewGuid();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            fs.Write(buf, 0, buf.Length);
            fs.Flush();
            fs.Close();
            FileInfo info = new FileInfo(fileName);
            byte[] temp = File.ReadAllBytes(fileName);
            string fileTypeCode = temp[0].ToString() + temp[1].ToString();
            info.MoveTo(fileName + ConvertFileType(fileTypeCode));
            Console.WriteLine("DownLoad Success!!");
            return fileName;
        }

        public void downloadCover() 
        
        {
        
        }

        /// <summary>
        /// type from http://www.garykessler.net/library/file_sigs.html
        /// </summary>
        /// <param name="fileTypeCode"></param>
        /// <returns></returns>
        public string ConvertFileType(string fileTypeCode)
        {
            string fileType = "";
            switch (fileTypeCode)
            {
                case "7790":
                    fileType = ".exe";
                    break;

                case "8297":
                    fileType = ".rar";
                    break;

                case "255216":
                    fileType = ".jpg";
                    break;

                case "4946":
                    fileType = ".jpg";
                    break;

                case "6677":
                    fileType = ".bmp";
                    break;

                case "424D":
                    fileType = ".bmp";
                    break;

                case "7173":
                    fileType = ".gif";
                    break;

                case "4749":
                    fileType = ".gif";
                    break;

                case "8950":
                    fileType = ".png";
                    break;

                case "13780":
                    fileType = ".png";
                    break;

                default:
                    fileType = ".jpeg";
                    break;
            }
            return fileType;
        }

        /// <summary>
        /// save web file to / with fileName
        /// </summary>
        /// <param name="webFilePath"></param>
        /// <param name="fileName"></param>
        public void SaveWebFileClient(String webFilePath, String fileName)
        {
            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(webFilePath, fileName);
        }
    }
}