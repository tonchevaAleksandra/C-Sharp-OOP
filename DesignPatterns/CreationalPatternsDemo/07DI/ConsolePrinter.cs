using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class ConsolePrinter : IPrintService
    {
        private IDocumentService document;
        public ConsolePrinter(IDocumentService document)
        {
            this.document = document;   
        }
        public void Print(string path)
        {
            Console.WriteLine(document.ReadDocument(path));
        }
    }
}
