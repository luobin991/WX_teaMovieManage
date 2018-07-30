using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace  Common
{
    public class WebCommon
    {

        /// <summary>
        /// 调用API GET数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string APIGet(string url)
        {
            //url = TimeString(url);
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            //这里url要组装安全标记等参数
            try
            {
                string result = client.DownloadString(url);
                client.Dispose();
                return result;
            }
            catch (Exception ex)
            {
#if DEBUG
                return ex.Message + "<br>源URL:" + url;
#else
                return "访问页面出错";
#endif
            }
        }

        /// <summary>
        /// 以GET方式创建Request请求,返回字符串(只适合返回文本类型,图片文件流除外)
        /// 潘锦发 20160316
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string APIGetByRequest(string url)
        {
            string result = "";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); //创建请求
            request.Method = "GET";
            using (HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse())//组建请求体
            {
                string fullResponse = "";
                using (Stream data = myResponse.GetResponseStream()) //获取返回的数据流
                {
                    using (StreamReader responseReader = new StreamReader(data))
                    {
                        fullResponse = responseReader.ReadToEnd();
                    }
                }
                if (myResponse.StatusCode == HttpStatusCode.OK) //判断状态
                {
                    result = fullResponse;
                }
                else
                {
                    result = "";
                }
            }
            return result;
        }

        /// <summary>
        /// 调用API POST数据，并不返回数据，不阻塞当前线程
        /// </summary>
        /// <param name="url"></param>
        /// <param name="posts"></param>
        public static void APIPost(string url, string posts, bool check)
        {
            APIPost(url, posts, check, null);
        }
        /// <summary>
        /// 调用API POST数据，并不返回数据，不阻塞当前线程
        /// </summary>
        /// <param name="url"></param>
        /// <param name="posts"></param>
        public static void APIPostByJson(string url, string posts, bool check)
        {
            APIPost(url, posts, check, "application/json");
        }
        /// <summary>
        /// 调用API POST数据，并不返回数据，不阻塞当前线程
        /// </summary>
        /// <param name="url"></param>
        /// <param name="posts"></param>
        public static void APIPost(string url, string posts, bool check, string contentType)
        {
            contentType = !string.IsNullOrEmpty(contentType) ? contentType : "application/x-www-form-urlencoded";
            if (check)
                posts = TimeString(posts);
            byte[] postData = Encoding.UTF8.GetBytes(posts);
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", contentType);
            client.Headers.Add("ContentLength", postData.Length.ToString());
            //这里url要组装安全标记等参数
            client.UploadDataAsync(new Uri(url), "POST", postData);
        }
        /// <summary>
        /// 调用API POST数据，并不返回数据，不阻塞当前线程
        /// </summary>
        /// <param name="url"></param>
        /// <param name="posts"></param>
        public static void APIPost(string url, string posts)
        {
            APIPost(url, posts, true);
        }

        /// <summary>
        /// 调用API POST数据，并返回数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="posts"></param>
        /// <returns></returns>
        public static string APIPostBack(string url, string posts, bool check)
        {
            return APIPostBack(url, posts, check, "application/x-www-form-urlencoded");
        }

        public static string APIPostBack(string url, byte[] postData, string contentType)
        {
            //找退出原因
            //LogHelper.Info(url + posts);
            WebClient client = new WebClient();

            client.Headers.Add("Content-Type", contentType);
            client.Headers.Add("ContentLength", postData.Length.ToString());
            //这里url要组装安全标记等参数
            byte[] responseData = null;
            string result = "";
            try
            {
                responseData = client.UploadData(url, "POST", postData);
                result = Encoding.UTF8.GetString(responseData);
                //找退出原因
                //LogHelper.Info(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                //result = JSONHelper.GetJson(null, 0, ex.Message, ex);
            }
            client.Dispose();
            return result;
        }
        public static string APIPostBack(string url, string posts, bool check, string contentType)
        {
            //检查参数，登录接口不需要
            if (check)
                posts = TimeString(posts);
            byte[] postData = Encoding.UTF8.GetBytes(posts);
            //找退出原因
            //LogHelper.Info(url + posts);
            WebClient client = new WebClient();

            client.Headers.Add("Content-Type", contentType);
            client.Headers.Add("ContentLength", postData.Length.ToString());
            //这里url要组装安全标记等参数
            byte[] responseData = null;
            string result = "";
            try
            {
                responseData = client.UploadData(url, "POST", postData);
                result = Encoding.UTF8.GetString(responseData);
                //找退出原因
                //LogHelper.Info(result);
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
                //result = JSONHelper.GetJson(null, 0, ex.Message, ex);
            }
            client.Dispose();
            return result;
        }
        /// <summary>
        /// 检查时间合法的字符串参数
        /// </summary>
        /// <returns></returns>        
        public static string TimeString(string posts)
        {
            DateTime dt = DateTime.Now;
            //这里改为数组，原来用indexof会引起相似名称的参数冲突 kevin
            string[] tmp = null;
            string tmpstr = posts;
            if (!posts.StartsWith("http://") && !posts.StartsWith("?") && !posts.StartsWith("&"))
            {
                tmpstr = "&" + posts;
            }
            tmp = tmpstr.Split(new char[] { '?', '&' });
            List<string> tmpkey = new List<string>();
            for (int i = 0; i < tmp.Length; i++)
            {
                if (tmp[i].IndexOf("=") > 0)
                {
                    tmpkey.Add(tmp[i].Split('=')[0]);
                }
            }
            if (!tmpkey.Contains<string>("strdate"))
            {
                posts += "&strdate=" + HttpUtility.UrlEncode(dt.ToString());
            }
            if (!tmpkey.Contains<string>("strcode"))
            {
                posts += "&strcode=" + StringHelper.GetMd5("123" + dt.ToString() + "321");
            }
            //加上当前IP
            posts += "&sourceip=" + WebCommon.GetIPAddress();
            if (posts.StartsWith("http://") && posts.IndexOf("&") > 0 && posts.IndexOf("?") < 0)
            {
                posts = posts.Substring(0, posts.IndexOf("&")) + "?" + posts.Substring(posts.IndexOf("&") + 1); ;
            }
            return posts;
        }

        public static string GetIPAddress()
        {
            try
            {
                string forwarded = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                string remote = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                string IP = GetIPAddress(forwarded, remote);
                return IP;
            }
            catch { return ""; }
        }
        /// <summary>
        /// 取得客户端真实IP。如果有代理则取第一个非内网地址  
        /// </summary>
        /// <param name="forwarded">获得IP的参数</param>
        /// <param name="remote"></param>
        /// <returns></returns>
        public static string GetIPAddress(string forwarded, string remote)
        {
            //forwarded＝ HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
            //remote ＝ HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]
            string result = String.Empty;
            result = forwarded;
            if (result != null && result != String.Empty)
            {
                //可能有代理  
                if (result.IndexOf(".") == -1)        //没有“.”肯定是非IPv4格式  
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。  
                        result = result.Replace("  ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IsIPAddress(temparyip[i])
                                    && temparyip[i].Substring(0, 3) != "10."
                                    && temparyip[i].Substring(0, 7) != "192.168"
                                    && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i];        //找到不是内网的地址  
                            }
                        }
                    }
                    else if (IsIPAddress(result))  //代理即是IP格式  
                        return result;
                    else
                        result = null;        //代理中的内容  非IP，取IP  
                }
            }

            string IpAddress = (result != null && result != String.Empty) ? result : remote;

            if (null == result || result == String.Empty)
                result = remote;
            if (result == null || result == String.Empty)
                result = HttpContext.Current.Request.UserHostAddress;
            return result;
        }
        /// <summary>
        /// 判断是否是IP地址格式 0.0.0.0
        /// </summary>
        /// <param name="str1">待判断的IP地址</param>
        /// <returns>true or false</returns>
        public static bool IsIPAddress(string str1)
        {
            if (str1 == null || str1 == string.Empty || str1.Length < 7 || str1.Length > 15) return false;

            string regformat = @"^\d{1,3}[\.]\d{1,3}[\.]\d{1,3}[\.]\d{1,3}$";

            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);

            return regex.IsMatch(str1);
        }
        /// <summary>
        /// 产生随机字符串，用于客户端随机命名
        /// </summary>
        /// <param name="len">字符长度</param>
        /// <returns></returns>
        public static string GetRndString(int len)
        {
            string s = Guid.NewGuid().ToString().Replace("-", "");
            return s.Substring(0, len > s.Length ? s.Length : len);
        }
        #region 获取客户端浏览器类型及版本号
        /// <summary>
        /// 获取客户端浏览器类型及版本号
        /// </summary>
        /// <returns></returns>
        public static string GetClientBrowserVersions()
        {
            string browserVersions = string.Empty;
            HttpBrowserCapabilities hbc = HttpContext.Current.Request.Browser;
            string browserType = hbc.Browser.ToString();     //获取浏览器类型
            string browserVersion = hbc.Version.ToString();    //获取版本号
            browserVersions = browserType + "_" + browserVersion;
            return browserVersions;
        }
        #endregion
        #region 32位唯一标识符
        /// <summary>
        /// 登录
        ///32位唯一标识符
        /// </summary>
        /// <returns></returns>
        public static string GetOnlyCode()
        {
            System.Guid guid = new Guid();
            guid = Guid.NewGuid();
            return guid.ToString().Trim();
        }
        #endregion
        #region 验证码生成

        public byte[] CreateYzm()
        {
            string checkCode = CreateCode(4);
            //用于验证
            SessionHelper.Add("CheckCode", checkCode);
            return CreateImages(checkCode);
        }


        /*产生验证码*/
        public string CreateCode(int codeLength)
        {
            string so = "1,2,3,4,5,6,7,8,9,0,A,B,C,D,G,H";//,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z
            string[] strArr = so.Split(',');
            string code = "";
            Random rand = new Random();
            for (int i = 0; i < codeLength; i++)
            {
                code += strArr[rand.Next(0, strArr.Length)];
            }
            return code;
        }

        /*产生验证图片*/
        public byte[] CreateImages(string code)
        {
            Bitmap image = new Bitmap(60, 20);
            Graphics g = Graphics.FromImage(image);
            WebColorConverter ww = new WebColorConverter();
            g.Clear((Color)ww.ConvertFromString("#FAE264"));

            Random random = new Random();
            //画图片的背景噪音线
            for (int i = 0; i < 12; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);

                g.DrawLine(new Pen(Color.LightGray), x1, y1, x2, y2);
            }
            Font font = new Font("Arial", 15, FontStyle.Bold | FontStyle.Italic);
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
             new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Gray, 1.2f, true);
            g.DrawString(code, font, brush, 0, 0);

            //画图片的前景噪音点
            for (int i = 0; i < 10; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.White);
            }

            //画图片的边框线
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            byte[] bytes = ms.GetBuffer();
            ms.Close();
            g.Dispose();
            image.Dispose();
            return bytes;
        }


        /// <summary>  
        /// 该方法用于生成指定位数的随机数  
        /// </summary>  
        /// <param name="VcodeNum">参数是随机数的位数</param>  
        /// <returns>返回一个随机数字符串</returns>  
        private string RndNum(int VcodeNum)
        {
            //验证码可以显示的字符集合  
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p" +
                ",q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,P,Q" +
                ",R,S,T,U,V,W,X,Y,Z";
            string[] VcArray = Vchar.Split(new Char[] { ',' });//拆分成数组   
            string code = "";//产生的随机数  
            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数  

            Random rand = new Random();
            //采用一个简单的算法以保证生成随机数的不同  
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类  
                }
                int t = rand.Next(61);//获取随机数  
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);//如果获取的随机数重复，则递归调用  
                }
                temp = t;//把本次产生的随机数记录起来  
                code += VcArray[t];//随机数的位数加一  
            }
            return code;
        }

        /// <summary>  
        /// 该方法是将生成的随机数写入图像文件  
        /// </summary>  
        /// <param name="code">code是一个随机数</param>
        /// <param name="numbers">生成位数（默认4位）</param>  
        public byte[] CreateYzm(int numbers = 4)
        {
            string code = RndNum(numbers);
            SessionHelper.Add("CheckCode", code);
            Bitmap Img = null;
            Graphics g = null;
            MemoryStream ms = null;
            Random random = new Random();
            //验证码颜色集合  
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            //验证码字体集合
            string[] fonts = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };


            //定义图像的大小，生成图像的实例  
            Img = new Bitmap((int)code.Length * 18, 32);

            g = Graphics.FromImage(Img);//从Img对象生成新的Graphics对象    

            g.Clear(Color.White);//背景设为白色  

            //在随机位置画背景点  
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(Img.Width);
                int y = random.Next(Img.Height);
                g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }
            //验证码绘制在g中  
            for (int i = 0; i < code.Length; i++)
            {
                int cindex = random.Next(7);//随机颜色索引值  
                int findex = random.Next(5);//随机字体索引值  
                Font f = new Font(fonts[findex], 15, FontStyle.Bold);//字体  
                Brush b = new SolidBrush(c[cindex]);//颜色  
                int ii = 4;
                if ((i + 1) % 2 == 0)//控制验证码不在同一高度  
                {
                    ii = 2;
                }
                g.DrawString(code.Substring(i, 1), f, b, 3 + (i * 12), ii);//绘制一个验证字符  
            }
            ms = new MemoryStream();//生成内存流对象  
            Img.Save(ms, ImageFormat.Jpeg);//将此图像以Png图像文件的格式保存到流中  


            byte[] bytes = ms.GetBuffer();
            //ms.Close();
            ms.Dispose();
            //回收资源  
            g.Dispose();
            Img.Dispose();
            return bytes;
        }
        #endregion
        /// <summary>
        /// 转换json字符串
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string ToJsonString(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
