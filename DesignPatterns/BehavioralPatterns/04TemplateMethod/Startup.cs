using System;

namespace TemplateMethod
{
    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("---- Document Reader - PDF doc ----");
            DocumentReader documenteReader = new PDFDocument();
            documenteReader.OpenDocument();

            Console.WriteLine("---- Document Reader - RTF doc ----");
            documenteReader = new RTFDocument();
            documenteReader.OpenDocument();
        }
    }
}