﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramUI ui = new ProgramUI(); // this line instantiates our ProgramUI; in doing so we have instantiated our _field that is of Type ClaimsRepository
            ui.Run();
        }
    }
}
