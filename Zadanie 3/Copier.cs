using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3
{
    public class Copier : BaseDevice
    {
        Printer printer = new Printer();
        Scanner scanner = new Scanner();
       
        public int ScanCounter => scanner.ScanCounter;
        public int PrintCounter => printer.PrintCounter;
        
       
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (IDevice.State.on == state)
            {
                scanner.PowerOn();
                scanner.Scan(out document, formatType);
                
                scanner.PowerOff();
            }
            else
            {
                document = null;
                return;
            }
        }

        public void Print(in IDocument document)
        {
            if (IDevice.State.on == state)
            {
                printer.PowerOn();
                printer.Print(document);
               
                printer.PowerOff();
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

                this.Scan(out IDocument document, IDocument.FormatType.JPG);
                this.Print(document);
            }
            else
            {
                return;
            }

        }
    }
}
