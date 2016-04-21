using System;
using System.IO;
using System.Net;

namespace HCover.Utils
{
    internal class SaveACWebFile
    {
        /// <summary>
        /// get image by webpath like:http://127.0.0.1/pic/Default.aspx
        /// </summary>
        /// <param name="imagePath"></param>
        public string SaveWebImage(String imagePath, String savePath)
        {
            if (imagePath == "")
            {
                return "";
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(imagePath);
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
            int length = (int)response.ContentLength;
            BinaryReader br = new BinaryReader(resStream);
            string fileName = savePath + Guid.NewGuid();
            FileStream fs = File.Create(fileName);
            fs.Write(br.ReadBytes(length), 0, length);
            br.Close();
            fs.Close();
            FileInfo info = new FileInfo(fileName);
            byte[] temp = File.ReadAllBytes(fileName);
            string fileTypeCode = temp[0].ToString() + temp[1].ToString();
            info.MoveTo(fileName + ConvertFileType(fileTypeCode));
            Console.WriteLine("DownLoad Success!!");
            return fileName;
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