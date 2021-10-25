using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four_souls_card_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.loadCards();
        }


    }
}
