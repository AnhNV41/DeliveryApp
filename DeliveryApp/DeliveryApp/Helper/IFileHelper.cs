using DeliveryApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Helper
{
    public interface IFileHelper
    {
        string GetAppDataPath();
        void SaveText(string text, string path);

        void SaveTextInLine(string[] text, string path);
        bool IsFileExisting(string path);
        string ReadAllText(string path);
        void DeleteFile(string path);
        List<OrderInFileModel> ReadTextInLine(string path);
    }
}
