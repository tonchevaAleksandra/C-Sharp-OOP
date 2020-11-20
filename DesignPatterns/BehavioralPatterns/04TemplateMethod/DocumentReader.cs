using System;

namespace TemplateMethod
{
    public abstract class DocumentReader
    {
        public void LoadFile()
        {
            Console.WriteLine("Document File loaded");
        }

        public abstract void InterpretDocumentFormat();

        public void Open()
        {
            Console.WriteLine("Document File opens");
        }

        public void OpenDocument()
        {
            this.LoadFile();
            this.InterpretDocumentFormat();
            this.Open();
        }

    }
}