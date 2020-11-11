using System;
using System.IO;
using System.Linq;
using System.Globalization;

using Logger.Common;
using Logger.Models.Contracts;
using Logger.Models.Enumerations;
using Logger.Models.IOManagement;

namespace Logger.Models.Files
{
    public class LogFile : IFile
    {
        private IOManager IOManager;
        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExistance();
        }
        public string Path => this.IOManager.CurrentFilePath;

        public long Size => this.GetFileSize();
        /// <summary>
        /// Returns formated message in provided layout with provided error's data.
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formatedMessage = string.Format(format, dateTime
               .ToString(GlobalConstants.DATE_FORMAT, CultureInfo.InvariantCulture),
               message,
               level.ToString())+Environment.NewLine;

            return formatedMessage;
        }
        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long size = text
                .Where(ch => char.IsLetter(ch))
                .Sum(ch => ch);

            return size;
        }
    }
}
