using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace StockAnalysis
{
    class UtilPreference
    {
        private static readonly string db_file = "db.txt";

        public static void Clean()
        {
            if (File.Exists(db_file))
            {
                File.Delete(db_file);
            }
           
        }

        public static void WriteDB()
        {
            if (File.Exists(db_file))
            {
                File.Delete(db_file);
            }
            FileStream fs = new FileStream(db_file, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter m_streamWriter = new StreamWriter(fs);
            m_streamWriter.Flush();
            //  使用StreamWriter来往文件中写入内容
            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.Write(DataManager.server + "\n");
            m_streamWriter.Write(DataManager.database + "\n");
            m_streamWriter.Write(DataManager.user + "\n");
            m_streamWriter.Write(DataManager.password + "\n");
            m_streamWriter.Write(StockApp.txtSrc + "\n");
            m_streamWriter.Write(StockApp.STOCK_START_DATE + "\n");
            m_streamWriter.Write(StockApp.isProductive + "\n");
            //关闭此文件
            m_streamWriter.Flush();
            m_streamWriter.Close();
            fs.Close();
        }
       
        
        private static void InitDB()
        {  
            ArrayList list = new ArrayList();
            if (!File.Exists(db_file))
            {
                WriteDB();
            }
            StreamReader sr = new StreamReader(db_file, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                list.Add(line);
            }
            DataManager.changeDB(list[0].ToString(), list[1].ToString(),
                list[2].ToString(), list[3].ToString());
            StockApp.txtSrc = list[4].ToString();
            StockApp.STOCK_START_DATE = Convert.ToInt32(list[5].ToString());
            StockApp.isProductive = Convert.ToBoolean(list[6].ToString());
            
       
        }
        public static void Init()
        {
            InitDB();

        }
    }
}
