using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesUI

{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI(); // this line instantiates our ProgramUI; in doing so we have instantiated our _field that is of Type BadgeRepository
            ui.Run();
        }
    }
}
