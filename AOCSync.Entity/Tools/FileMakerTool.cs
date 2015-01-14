using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AOCSync.Entity.Tools
{
    class FileMakerTool
    {
        public static bool GenerateFile(string filePath, string fileName, string content)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fname = string.Format("{0}\\{1}", filePath, fileName);
                if (!File.Exists(fname))
                {
                    FileStream fs = File.Create(fname);
                    fs.Close();
                }
                StreamWriter sw = new StreamWriter(fname, false, System.Text.Encoding.Default);
                sw.WriteLine(content);
                sw.Close();
                sw.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GenerateFile(string filePath, string fileName, List<string> contentList)
        {
            bool ret = false;
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string fname = string.Format("{0}\\{1}", filePath, fileName);
                if (!File.Exists(fname))
                {
                    FileStream fs = File.Create(fname);
                    fs.Close();
                }
                StreamWriter sw = new StreamWriter(fname, false, System.Text.Encoding.Default);

                foreach (string content in contentList)
                {
                    sw.WriteLine(content);
                }
                sw.Close();
                sw.Dispose();

               ret=true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ret;
        }  
    }
}
