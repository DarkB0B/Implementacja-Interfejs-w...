using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3
{
    public class MultidimensionalDevice : BaseDevice
    {
        Copier copier = new Copier();
        Fax fax = new Fax();
        public int ScanCounter => copier.ScanCounter;
        public int PrintCounter => copier.PrintCounter;
        public int FaxCounter => fax.FaxCounter;
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            if (IDevice.State.on == state)
            {
                copier.PowerOn();
                copier.Scan(out document, formatType);
                copier.PowerOff();
            }
            else
            {
                document = null;
                return;
            }
        }
        public void Fax(in IDocument document, string recipient)
        {
            if(IDevice.State.on == state)
            {
                fax.PowerOn();
                fax.SendFax(in  document,  recipient);
                fax.PowerOff();
            }
        }

        public void Print(in IDocument document)
        {
            if (IDevice.State.on == state)
            {
                copier.PowerOn();
                copier.Print(document);
                copier.PowerOff();
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
                copier.ScanAndPrint();
            }
            else
            {
                return;
            }

        }


    }
}
