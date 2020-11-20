using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPrintService, ConsolePrinter>()
                .AddSingleton<IDocumentService, PdfService>()
                .BuildServiceProvider();

            //do the actual work here
            var printer = serviceProvider.GetService<IPrintService>();
            printer.Print("C:/Files/test.pdf");

        }
    }
}
