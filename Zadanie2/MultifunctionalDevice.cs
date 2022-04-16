using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class MultifunctionalDevice : Copier, IFax
    {
        
        public int FaxCounter = 0;
        

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
        
        
    }
}
