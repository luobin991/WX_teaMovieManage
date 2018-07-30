using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace Common
{
   public class ImgBase64
    {
        public static string ImgToBase64String(string imageFilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(imageFilename);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static string Base64StringToImage(string strbase64,string path)
        {
            try
            {

                string dummyData = strbase64.Trim().Replace("data:image/png;base64,", "");
                dummyData = dummyData.Replace("data:image/jpeg;base64", "");
                dummyData = dummyData.Replace("data:image/bmp;base64", "");
                dummyData = dummyData.Replace("data:image/jpg;base64", "");
                dummyData = dummyData.Replace("data:image/gif;base64", "");
                dummyData = dummyData.Replace("data:image/webp;base64", "");
                dummyData=dummyData.Replace(" % ", "").Replace(",", "").Replace(" ", "+");


                if (dummyData.Length % 4 > 0)
                {
                    dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
                }
                byte[] arr = Convert.FromBase64String(dummyData);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                string guid= Guid.NewGuid().ToString("N").Replace("-", "")+ ".Jpeg";
                path = path +"/"+ guid;
                bmp.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Close();
                return guid;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        }


    }
