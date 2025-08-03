using DeliveryApp.Helper;
using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Path = System.IO.Path;

namespace DeliveryApp.DataProvider
{
    public class FileProvider : IFileHelper
    {

        public const string FileName = "Todo.txt";

        public string GetAppDataPath()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, FileName);
        }

        public bool IsFileExisting(string path)
        {

            return File.Exists(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public void SaveText(string text, string path)
        {
            File.WriteAllText(path, text);
        }

        public void SaveTextInLine(string[] lines, string path)
        {
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
        }

        public List<OrderInFileModel> ReadTextInLine(string path)
        {
            List<OrderInFileModel> result = new List<OrderInFileModel>();

                using (StreamReader inputFile = new StreamReader(path))
                {
                    string str = inputFile.ReadLine();
                    while (str != null)
                    {
                        if (str != "")
                        {
                            var s = str.Split(',');
                            result.Add(new OrderInFileModel() { DetailCategoryItemID = s.ElementAt(0), Title = s.ElementAt(1), ImagePath = s.ElementAt(2), UnitPrice = s.ElementAt(3), Quantity = s.ElementAt(4) });
                        }
                        str = inputFile.ReadLine();
                    }
                }

            
            return result;
        }
    }
}
