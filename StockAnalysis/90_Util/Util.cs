using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StockAnalysis
{
    class Util
    {
        private static readonly string ENCODING = "UTF-8";
        private static readonly string SEPERATOR = ",";
        //选择目录
        public static string GetFolder()
        {
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
            if (System.Windows.Forms.DialogResult.OK == dlg.ShowDialog())
            {
                return dlg.SelectedPath;
            }
            return "";
        }
        //选择保存文件
        public static string GetFile()
        {
            System.Windows.Forms.SaveFileDialog dlg = new System.Windows.Forms.SaveFileDialog();
            dlg.Filter = "CSV File|*.csv";
            string file = "";

            if (System.Windows.Forms.DialogResult.OK == dlg.ShowDialog())
            {
                file = dlg.FileName;
            }
            return file;
        }

        //得到随机数
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        #region 日期相关
        //输出日期字符串
        public static int nextDay(int date) 
        {
            int year = Convert.ToInt32(date.ToString().Substring(0, 4));
            int month = Convert.ToInt32(date.ToString().Substring(4, 2));
            int day = Convert.ToInt32(date.ToString().Substring(6, 2));

            return Convert.ToInt32(new DateTime(year, month, day).AddDays(1).ToString("yyyyMMdd"));
        }
        //输出上个月
        public static int lastMonth(int date)
        {
            int year = Convert.ToInt32(date.ToString().Substring(0, 4));
            int month = Convert.ToInt32(date.ToString().Substring(4, 2));
            int day = Convert.ToInt32(date.ToString().Substring(6, 2));

            return Convert.ToInt32(new DateTime(year, month, day).AddMonths(-1).ToString("yyyyMM"));
        }

        
        //输出上个季度
        public static int lastQuarter(int date)
        {
            int year = Convert.ToInt32(date.ToString().Substring(0, 4));
            int month = Convert.ToInt32(date.ToString().Substring(4, 2));
            int day = Convert.ToInt32(date.ToString().Substring(6, 2));
            DateTime dt = new DateTime(year, month, day).AddMonths(-3);
            year = dt.Year;
            month = 1 + ((dt.Month - 1) / 3);
            return year * 100 + month;
        }

        public static DateTime getDate(int date)
        {
            int year = Convert.ToInt32(date.ToString().Substring(0, 4));
            int month = Convert.ToInt32(date.ToString().Substring(4, 2));
            int day = Convert.ToInt32(date.ToString().Substring(6, 2));
            return new DateTime(year, month, day);
        }
        public static int getIntDate(DateTime date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }
        #endregion
        public static string FormatGradeIndex(int gradeindex)
        {
            int length = gradeindex.ToString().Length;
            string ret = "";
            for (int i = 0; i < 10 - length; i++)
            {
                ret = "0" + ret;
            }
            ret = ret + gradeindex.ToString();
            return ret;
        }
        public static void ExportCSV(System.Windows.Forms.DataGridView dg)
        {
            string filename = Util.GetFile();
            ExportCSV(dg, filename);
            System.Windows.Forms.MessageBox.Show("Export Done!");
        }
        public static void ExportCSV(System.Windows.Forms.DataGridView dg, string filename)
        {
            ExportCSV(dg, filename, true); //每次都创建新文件
        }
        public static void ExportCSV(System.Data.DataTable dt, string filename)
        {   
            ExportCSV(dt, filename, true);
        }
        public static void ExportCSV(System.Data.DataTable dt)
        {
            string filename = Util.GetFile();
            ExportCSV(dt, filename, true);
            
        }
        private static StreamWriter getExportStreamWriter(string filename, bool isCreate, string[] colnames)
        {
            FileStream fs;
            StreamWriter sw;
            try
            {
                if (isCreate) //如果是新建文件, 会添加表头
                {
                    fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(filename, FileMode.Append, FileAccess.Write);

                }
                sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding(ENCODING));
                sw.Flush();

                if (isCreate)
                {
                    int colcount = colnames.Length;
                    string headtext = "";
                    for (int i = 0; i < colcount; i++)
                    {
                        headtext += colnames[i] + SEPERATOR;
                    }
                    headtext = headtext.Substring(0, headtext.Length - 1);
                    sw.Write(headtext);
                    sw.Write("\n");
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("File is in use!");
                Console.Write(e.ToString());
                return null;
            }
            return sw;
        }
        public static void ExportCSV(System.Windows.Forms.DataGridView dg, string filename, bool isCreate)
        {
            if (filename.Length < 1)
            {
                return;
            }
            
            int rowcount = dg.Rows.Count;
            int colcount = dg.Columns.Count;
            //得到所有列名
            string[] colnames = new string[colcount];
            for (int i = 0; i < colcount; i++)
            {
                colnames[i] = dg.Columns[i].HeaderText;
            }

            StreamWriter sw = getExportStreamWriter(filename, isCreate, colnames);
            
            for (int i = 0; i < rowcount; i++)
            {
                string value = "";
                for (int j = 0; j < colcount; j++)
                {   
                    try
                    {
                        value += dg.Rows[i].Cells[j].Value.ToString() + SEPERATOR;                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                if (i < rowcount - 1)
                {
                    value = value.Substring(0, value.Length - 1);
                    sw.Write(value);
                    sw.Write("\n");
                }
            }
            //关闭此文件
            sw.Flush();
            sw.Close();
            System.Windows.Forms.MessageBox.Show("Export Done");
        }

       

        public static void ExportCSV(System.Data.DataTable dt, string filename, bool isCreate)
        {
            if (filename.Length < 1)
            {
                return;
            }

            int rowcount = dt.Rows.Count;
            int colcount = dt.Columns.Count;
            //得到所有列名
            string[] colnames = new string[colcount];
            for (int i = 0; i < colcount; i++)
            {
                colnames[i] = dt.Columns[i].ColumnName;
            }

            StreamWriter sw = getExportStreamWriter(filename, isCreate, colnames);

            for (int i = 0; i < rowcount; i++)
            {
                string value = "";
                for (int j = 0; j < colcount; j++)
                {
                    try
                    {
                        value += dt.Rows[i][j].ToString() + SEPERATOR;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                if (i < rowcount)
                {
                    value = value.Substring(0, value.Length - 1);
                    sw.Write(value);
                    sw.Write("\n");
                }
            }
            //关闭此文件
            sw.Flush();
            sw.Close();
            System.Windows.Forms.MessageBox.Show("Export Done");
        }
    }
}

