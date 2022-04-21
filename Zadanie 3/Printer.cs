using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_3
{
    public class Printer : BaseDevice, IPrinter
    {
        public int PrintCounter { get; set; } = 0;
        
       
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
    }
}
