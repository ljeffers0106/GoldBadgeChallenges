using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI(); // this line instantiates our ProgramUI; in doing so we have instantiated our _field that is of Type CafeRepository
            ui.Run();
        }
    }
}
