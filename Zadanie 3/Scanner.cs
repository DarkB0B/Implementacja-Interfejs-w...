using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3
{
    public class Scanner : BaseDevice, IScanner
    {
        public int ScanCounter { get; set; } = 0;
        
        
        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            document = null;
            if (IDevice.State.on == state)
            {
                DateTime dateTime = DateTime.Now;
                if (formatType == IDocument.FormatType.PDF)
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
                
                Console.WriteLine("{0} Scan: {1}", dateTime, document.GetFileName());
                ScanCounter++;
                Console.WriteLine("{0} dokumentow zostalo przeskanowane", ScanCounter);
            }
            else
            {
                return;
            }
        }
    }
}
