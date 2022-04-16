using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int PrintCounter { get; set; } = 1;
        public int ScanCounter { get; set; } = 1;

         
        public void Print(in IDocument document)
        {
            if(IDevice.State.on == state)
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine("{0} Print: {1}", dateTime, document.GetFileName());
                PrintCounter++;
            }
            else
            {
                return;
            }
        }

        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = null;
            if (IDevice.State.on == state)
            {
                DateTime dateTime = DateTime.Now;
                if(formatType == IDocument.FormatType.PDF)
                {
                    document = new PDFDocument($"PDFScan{ScanCounter}.pdf");
                }
                else if (formatType == IDocument.FormatType.TXT)
                {
                    document = new TextDocument($"TextScan{ScanCounter}.txt");
                }
                else if (formatType == IDocument.FormatType.JPG)
                {
                    document = new ImageDocument($"ImageScan{ScanCounter}.jpg");
                }
                ScanCounter++;
                Console.WriteLine("{0} Scan: {1}", dateTime, document.GetFileName());
            }
            else
            {
                return;
            }
        }
        public void ScanAndPrint()
        {
            if (IDevice.State.on == state)
            {               
                Scan(out IDocument document);
                Print(in document);
            }
        }
    }
}
