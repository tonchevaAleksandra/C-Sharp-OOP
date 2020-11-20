using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public interface IDocumentService
    {
        string ReadDocument(string path);
    }
}
