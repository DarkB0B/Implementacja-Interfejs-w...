using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3
{
    internal class Fax: BaseDevice
    {
        public int FaxCounter = 0;
        public void SendFax(in IDocument document, string recipient)
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
    }
}
