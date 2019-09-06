using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StockAnalysis
{
    public class UtilLog
    {
        //应用主目录
        public static string LOG_FOLDER = "C:\\StockAnalysis\\log\\";
        //public static string LOG_FOLDER = ".\\";

        private static string logfile;
        private static string warnfile;
        private static string errorfile;
        private static string debugfile;
        private static readonly string LOG_ERROR = "ERROR";
        private static readonly string LOG_WARN = "WARN";
        private static readonly string LOG_INFO = "INFO";
        private static readonly string LOG_DEBUG = "DEBUG";

        //重置log目录
        static UtilLog ()
        {
            logfile = LOG_FOLDER + System.DateTime.Now.ToString("yyyyMMdd") + "_log" + ".txt";
            warnfile = LOG_FOLDER + System.DateTime.Now.ToString("yyyyMMdd") + "_warn" + ".txt";
            errorfile = LOG_FOLDER + System.DateTime.Now.ToString("yyyyMMdd") + "_error" + ".txt";
            debugfile = LOG_FOLDER + System.DateTime.Now.ToString("yyyyMMdd") + "_debug" + ".txt";
            if (!Directory.Exists(LOG_FOLDER))
            {
                Directory.CreateDirectory(LOG_FOLDER);
            }
            if (File.Exists(logfile))
            {
                File.Delete(logfile);
            }
            if (File.Exists(warnfile))
            {
                File.Delete(warnfile);
            }
            if (File.Exists(errorfile))
            {
                File.Delete(errorfile);
            }
            if (File.Exists(debugfile))
            {
                File.Delete(debugfile);
            }
            
        }
               
        //添加log信息
        private static void AddLog(string filename, string tag, string loglevel, string s)
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.Flush();
            //  使用StreamWriter来往文件中写入内容
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.Write(tag + ":\t" + DateTime.Now.ToLongTimeString() + "\n");
            m_streamWriter.Write(loglevel + ":\t"+ s + "\n\n");

            //关闭此文件
            m_streamWriter.Flush();
            m_streamWriter.Close();
            fs.Close();
        }
        public static void AddError(string tag, string s)
        {
            AddLog(errorfile, tag, LOG_ERROR, s);
            System.Windows.Forms.MessageBox.Show("Error! Please see log");
        }
        public static void AddWarn(string tag, string s)
        {
            AddLog(warnfile, tag, LOG_WARN, s);
        }
        public static void AddInfo(string tag, string s)
        {
            AddLog(logfile,tag, LOG_INFO, s);
        }
        public static void AddDebug(string tag, string s)
        {
            AddLog(debugfile, tag, LOG_DEBUG, s);
        }
        
     }
}
