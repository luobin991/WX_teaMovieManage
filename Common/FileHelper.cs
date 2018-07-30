using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Common
{
    using System.IO;
    using System.Text;

    public class FileHelper
    {
        public static FileHelper Context()
        {
            return new FileHelper();
        }

        #region EXIST
        /// <summary>
        /// 检测指定目录是否存在
        /// </summary>
        /// <param name="directoryPath">绝对路径</param>
        /// <returns></returns>
        public bool IsExistDirectory(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }
        /// <summary>
        /// 检测指定文件是否存在，存在->true
        /// </summary>
        /// <param name="filePath">文件绝对路径</param>
        /// <returns></returns>
        public bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// 检测指定目录是否为空
        /// </summary>
        /// <param name="directoryPath">指定目录的绝对路径</param>
        /// <returns></returns>
        public bool IsEmptyDirectory(string directoryPath)
        {
            try
            {
                string[] fileNames = GetFileNames(directoryPath);
                if (fileNames.Length > 0)
                {
                    return false;
                }
                //判断是否存在文件夹
                string[] directoryNames = GetDirectories(directoryPath);
                return directoryNames.Length <= 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>  
        /// 检测指定目录中是否存在指定的文件,若要搜索子目录请使用重载方法.  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>          
        public bool Contains(string directoryPath, string searchPattern)
        {
            try
            {
                string[] fileNames = GetFileNames(directoryPath, searchPattern, false);
                return fileNames.Length != 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>  
        /// 检测指定目录中是否存在指定的文件  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>   
        /// <param name="isSearchChild">是否搜索子目录</param>  
        public bool Contains(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                string[] fileNames = GetFileNames(directoryPath, searchPattern, true);
                return fileNames.Length != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region GET
        /// <summary>  
        /// 获取指定目录中所有文件列表  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param> 
        public string[] GetFileNames(string directoryPath)
        {
            if (!IsExistDirectory(directoryPath))
            { throw new FileNotFoundException(); }
            return Directory.GetFiles(directoryPath);
        }
        /// <summary>  
        /// 获取指定目录及子目录中所有文件列表  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>  
        /// <param name="isSearchChild">是否搜索子目录</param>  
        public string[] GetFileNames(string directoryPath, string searchPattern, bool isSearchChild)
        {
            if (!IsExistDirectory(directoryPath))
            { throw new FileNotFoundException(); }
            try
            {
                return Directory.GetFiles(directoryPath, searchPattern, isSearchChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>  
        /// 获取指定目录中所有子目录列表,若要搜索嵌套的子目录列表,请使用重载方法.  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        public string[] GetDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>  
        /// 获取指定目录及子目录中所有子目录列表  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        /// <param name="searchPattern">模式字符串，"*"代表0或N个字符，"?"代表1个字符。  
        /// 范例："Log*.xml"表示搜索所有以Log开头的Xml文件。</param>  
        /// <param name="isSearchChild">是否搜索子目录</param>  
        public string[] GetDirectories(string directoryPath, string searchPattern, bool isSearchChild)
        {
            try
            {
                return Directory.GetDirectories(directoryPath, searchPattern, isSearchChild ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>  
        /// 从文件的绝对路径中获取文件名( 包含扩展名 )  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public  string GetFileName(string filePath)
        {
            //获取文件的名称  
            FileInfo fi = new FileInfo(filePath);
            return fi.Name;
        }

        /// <summary>  
        /// 从文件的绝对路径中获取文件名( 不包含扩展名 )  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public string GetFileNameNoExtension(string filePath)
        {
            //获取文件的名称  
            FileInfo fi = new FileInfo(filePath);
            return fi.Name.Split('.')[0];
        }

        /// <summary>  
        /// 从文件的绝对路径中获取扩展名  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>          
        public string GetExtension(string filePath)
        {
            //获取文件的名称  
            FileInfo fi = new FileInfo(filePath);
            return fi.Extension;
        }

        /// <summary>
        /// 获取一个文件的长度
        /// </summary>
        /// <param name="filePath">文件的绝对路径</param>
        /// <param name="sizeType">默认byte,可选KB MB</param>
        /// <returns></returns>
        public double GetFileSize(string filePath, string sizeType)
        {
            FileInfo fi = new FileInfo(filePath);

            switch (sizeType.ToUpper())
            {
                case "KB":
                    return double.Parse((fi.Length / 1024).ToString());
                case "MB":
                    return double.Parse((fi.Length / 1024 / 1024).ToString());
                default:
                    return double.Parse(fi.Length.ToString());
            }
        }

        #endregion

        #region ADD
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dirctoryPath"></param>
        public void CreateDirectory(string dirctoryPath)
        {
            if (!IsExistDirectory(dirctoryPath))
            { Directory.CreateDirectory(dirctoryPath); }
        }

        /// <summary>  
        /// 创建一个文件。  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>
        public bool CreateFile(string filePath)
        {
            try
            {
                if (!IsExistFile(filePath))
                {
                    FileInfo file = new FileInfo(filePath);
                    FileStream fs = file.Create();
                    fs.Close();

                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        /// <summary>  
        /// 创建一个文件,并将字节流写入文件。  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="buffer">二进制流数据</param> 
        public bool CreateFile(string filePath, byte[] buffer)
        {
            try
            {
                if (!IsExistFile(filePath))
                {
                    FileInfo file = new FileInfo(filePath);  //创建一个FileInfo对象  

                    FileStream fs = file.Create();   //创建文件  

                    fs.Write(buffer, 0, buffer.Length);  //写入二进制流 

                    fs.Close();//关闭文件流  
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


        #endregion

        #region WRITE
        /// <summary>  
        /// 向文本文件中写入内容  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="content">写入的内容</param> 
        public void WriteText(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        /// <summary>  
        /// 将流读取到缓冲区中  
        /// </summary>  
        /// <param name="stream">原始流</param>  
        public byte[] StreamToBytes(Stream stream)
        {
            try
            {
                //创建缓冲区  
                byte[] buffer = new byte[stream.Length];

                //读取流  
                stream.Read(buffer, 0, int.Parse(stream.Length.ToString()));

                //返回流  
                return buffer;
            }
            catch
            {
                return null;
            }
            finally
            {
                //关闭流  
                stream.Close();
            }
        }

        /// <summary>  
        /// 将文件读取到缓冲区中  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public byte[] FileToBytes(string filePath)
        {
            //获取文件的大小   
            int fileSize = Convert.ToInt32(GetFileSize(filePath, ""));

            //创建一个临时缓冲区  
            byte[] buffer = new byte[fileSize];

            //创建一个文件流  
            FileInfo fi = new FileInfo(filePath);
            FileStream fs = fi.Open(FileMode.Open);

            try
            {
                //将文件流读入缓冲区  
                fs.Read(buffer, 0, fileSize);

                return buffer;
            }
            catch
            {
                return null;
            }
            finally
            {
                //关闭文件流  
                fs.Close();
            }
        }


        /// <summary>  
        /// 将文件读取到字符串中  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public string FileToString(string filePath)
        {
            return FileToString(filePath, Encoding.Default);
        }

        /// <summary>  
        /// 将文件读取到字符串中  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="encoding">字符编码</param>  
        public string FileToString(string filePath, Encoding encoding)
        {
            //创建流读取器  
            StreamReader reader = new StreamReader(filePath, encoding);
            try
            {
                //读取流  
                return reader.ReadToEnd();
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                //关闭流读取器  
                reader.Close();
            }
        }

        /// <summary>  
        /// 向文本文件的尾部追加内容  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        /// <param name="content">写入的内容</param>  
        public void AppendText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }





        #endregion

        #region COPY
        /// <summary>  
        /// 将源文件的内容复制到目标文件中  
        /// </summary>  
        /// <param name="sourceFilePath">源文件的绝对路径</param>  
        /// <param name="destFilePath">目标文件的绝对路径</param>  
        public void Copy(string sourceFilePath, string destFilePath)
        {
            File.Copy(sourceFilePath, destFilePath, true);
        }

        /// <summary>  
        /// 将文件移动到指定目录  
        /// </summary>  
        /// <param name="sourceFilePath">需要移动的源文件的绝对路径</param>  
        /// <param name="descDirectoryPath">移动到的目录的绝对路径</param>  
        public void Move(string sourceFilePath, string descDirectoryPath)
        {
            //获取源文件的名称  
            string sourceFileName = GetFileName(sourceFilePath);

            if (IsExistDirectory(descDirectoryPath))
            {
                //如果目标中存在同名文件,则删除  
                if (IsExistFile(descDirectoryPath + "\\" + sourceFileName))
                {
                    DeleteFile(descDirectoryPath + "\\" + sourceFileName);
                }
                //将文件移动到指定目录  
                File.Move(sourceFilePath, descDirectoryPath + "\\" + sourceFileName);
            }
        }



        #endregion

        #region DELET

        /// <summary>  
        /// 清空指定目录下所有文件及子目录,但该目录依然保存.  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        public void ClearDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                //删除目录中所有的文件  
                string[] fileNames = GetFileNames(directoryPath);
                foreach (string t in fileNames)
                {
                    DeleteFile(t);
                }

                //删除目录中所有的子目录  
                string[] directoryNames = GetDirectories(directoryPath);
                foreach (string t in directoryNames)
                {
                    DeleteDirectory(t);
                }
            }
        }

        /// <summary>  
        /// 清空文件内容  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public void ClearFile(string filePath)
        {
            //删除文件  
            File.Delete(filePath);

            //重新创建该文件  
            CreateFile(filePath);
        }


        /// <summary>  
        /// 删除指定文件  
        /// </summary>  
        /// <param name="filePath">文件的绝对路径</param>  
        public void DeleteFile(string filePath)
        {
            if (IsExistFile(filePath))
            {
                File.Delete(filePath);
            }
        }

        /// <summary>  
        /// 删除指定目录及其所有子目录  
        /// </summary>  
        /// <param name="directoryPath">指定目录的绝对路径</param>  
        public void DeleteDirectory(string directoryPath)
        {
            if (IsExistDirectory(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        #endregion

    }
}
