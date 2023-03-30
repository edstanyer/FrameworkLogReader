using System;
using  System.IO;
namespace FrameworkLogReader
{
    public static class FileHelper
    {
        public static Tuple<bool, string> ReadFile(string fileName)
        {
            if (File.Exists((fileName)))
            {
                try
                {
                    StreamReader sr = new StreamReader(fileName);
                    string txt = sr.ReadToEnd();
                    return Tuple.Create(true, txt);
                }
                catch (Exception e)
                {
                    return Tuple.Create(false, e.Message);
                }
            }
            return Tuple.Create(true, "File doesn't exist");
        }
    }
}