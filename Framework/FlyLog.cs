using System;
using System.IO;
using System.Text;

namespace Powerson.Framework
{
    public class FlyLog
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strError"></param>
        public static void WriteLog(string strError)
        {
            string str_path = System.Configuration.ConfigurationManager.AppSettings["LOGFILEPATH"];
            if (null == str_path || str_path.Length.Equals(0))
            {
                str_path = "c:";
            }
            else
            {
                str_path = StringUtil.StrLeftBack(str_path, "\\", true);
            }
            string full_path = string.Format("{0}\\{1}{2}log.txt", str_path, DateTime.Now.Year, DateTime.Now.Month.ToString("D2"));
            FileStream _Fs = null;
            StreamWriter _Sw = null;
            try
            {
	            _Fs = new FileStream(str_path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
	            _Sw = new StreamWriter(_Fs, System.Text.Encoding.Unicode);
	            _Sw.BaseStream.Seek(0, SeekOrigin.End);
	            _Sw.WriteLine("------------------------------------\r\n");
	
	            _Sw.WriteLine(DateTime.Now.ToString() + "\r\n");
	
	            _Sw.WriteLine(strError + "\r\n");
	            _Sw.WriteLine("------------------------------------\r\n");
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                _Sw.Close();
                _Fs.Close();
            }
        }
    }
}
