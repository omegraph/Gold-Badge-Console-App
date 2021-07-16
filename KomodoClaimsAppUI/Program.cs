using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsAppUI
{
    class Program
    {
        //main entry point
        static void Main(string[] args)
        {
            //application (UI (user interface)start in here)
            Program_UI program = new Program_UI();
            program.Run();
        }
    }
}
