using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace StockAnalysis
{
    public class SQLMassImport
    {
        private FileStream fs;
        private StreamWriter m_streamWriter;
        private string filename;
       
        public SQLMassImport(string file)
        {
            Init(UtilLog.LOG_FOLDER, file);
        }
        public SQLMassImport(string folder, string file)
        {
            Init(folder, file);
        }
        private void Init(string folder, string file)
        {
            filename = file + ".txt";
            string filepath = folder + file + ".txt";
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
            m_streamWriter = new StreamWriter(fs);
            m_streamWriter.Flush();
        }
        public void AddRow(string[] strs)
        {
            int length = strs.Length;
            for (int i = 0; i < length; i++)
            {
                m_streamWriter.Write(strs[i] + "\t");
            }
            m_streamWriter.Write("\r\n");
            m_streamWriter.Flush();
        }
        public void ImportClose(DataManager db, string table)
        {
            string sql = "BULK INSERT " + table + " FROM '" + UtilLog.LOG_FOLDER + filename + "';";
            m_streamWriter.Flush();
            m_streamWriter.Close();
            fs.Close();
            db.RunSql(sql);
            DirectoryInfo folder = new DirectoryInfo(UtilLog.LOG_FOLDER);
            File.Delete(folder + filename);
        }
        
    }
    
}
