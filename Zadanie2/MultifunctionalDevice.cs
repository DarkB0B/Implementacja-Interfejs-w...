using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class MultifunctionalDevice : BaseDevice, IMultifunctionalDevice
    {
        public int PrintCounter = 1;
        public int FaxCounter = 1;
        public int ScanCounter = 1;

        public void Fax(in IDocument document,string recipient)
        {
            if (IDevice.State.on == state)
            {
                DateTime dateTime = DateTime.Now;
                Console.WriteLine("{0} Fax has been sent to {1}", dateTime, recipient);
                FaxCounter++;
            }
            else
            {
                return;
            }
        }
        public void Print(in IDocument document)
        {
            if (IDevice.State.on == state)
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
                ScanCounter++;
                Console.WriteLine("{0} Scan: {1}", dateTime, document.GetFileName());
            }
            else
            {
                return;
            }
        }
    }
}
