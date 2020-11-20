using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class PdfService : IDocumentService
    {
        public string ReadDocument(string path)
        {
            return "PDF document content from path " + path;
        }
    }
}
