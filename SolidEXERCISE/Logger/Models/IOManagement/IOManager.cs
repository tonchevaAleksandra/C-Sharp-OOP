using System;
using System.IO;

using Logger.Models.Contracts;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string currentPath;

        private string folderName;
        private string fileName;
        private IOManager()
        {
            this.currentPath = GetCurrentDirectory();
        }
        public IOManager(string folderName, string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }
        public string CurrentDirectoryPath => 
            this.currentPath + this.folderName;

        public string CurrentFilePath => 
            this.CurrentDirectoryPath + this.fileName;

        public void EnsureDirectoryAndFileExistance()
        {
            if(!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, String.Empty);
        }

        public string GetCurrentDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            return currentDir;
        }
    }
}
