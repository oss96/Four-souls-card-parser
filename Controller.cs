using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four_souls_card_parser
{
    class Controller
    {
        List<string> directories = new List<string>();
        List<string> files = new List<string>();
        protected internal List<Card> loadCards()
        {
            string path = Directory.GetCurrentDirectory() + "\\TBoI Cards";
            directories.AddRange(Directory.GetDirectories(path).ToList());
            getDirectories(path);
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory());
            foreach (var directory in directories)
            {
            }
            return null;
        }
        private List<string> getDirectories(string path)
        {
            List<string> tmpDirectories = Directory.GetDirectories(path).ToList();
            foreach (string tmpPath in tmpDirectories)
            {
                files.AddRange(Directory.GetFiles(tmpPath).ToList());
                if (Directory.GetDirectories(tmpPath).Count() != 0)
                {
                    directories.AddRange(getDirectories(tmpPath).ToList());
                }
            }

            return tmpDirectories;
        }
    }
}
