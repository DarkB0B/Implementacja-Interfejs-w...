using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Program
    {
        static void Main()
        {
            var xerox = new Copier();
            var multi = new MultifunctionalDevice();
            xerox.PowerOn();
            multi.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);
            multi.Fax(in doc1, "Mariusz");
            xerox.ScanAndPrint();
            System.Console.WriteLine(xerox.Counter);
            System.Console.WriteLine(xerox.PrintCounter);
            System.Console.WriteLine(xerox.ScanCounter);

            
        }
    }
}
