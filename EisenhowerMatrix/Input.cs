using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    internal class Input
    {
        public Input() { }

        public int GameOption()
        {
            string option = Console.ReadLine();
            return Convert.ToInt32(option);
        }
    }
}
