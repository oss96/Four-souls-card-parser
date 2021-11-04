using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Four_souls_card_parser
{
    class Controller
    {
        List<string> directories = new List<string>();
        List<string> files = new List<string>();
        List<Card> Cards = new List<Card>();


        protected internal void loadCards()
        {
            Console.WriteLine("Starting...");
            string path = Directory.GetCurrentDirectory() + "\\TBoI Cards";
            directories.AddRange(Directory.GetDirectories(path).ToList());
            getDirectories(path);
            generateCards();
            generateCSVFile();
        }
        private List<string> getDirectories(string path)
        {
            Console.WriteLine("Getting Directories...");
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
        private void generateCards()
        {
            Console.WriteLine("Generating Cards...");
            uint iNoType = 0;
            uint iCharacter = 100001;
            uint iStartingItem = 200001;
            uint iMonster = 300001;
            uint iTreasure = 400001;
            uint iLoot = 500001;
            uint iBonusSoul = 600001;
            uint iRoom = 700001;

            if (!Directory.Exists("Cards"))
            {
                Directory.CreateDirectory("Cards");
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo("Cards");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }

            foreach (string file in files)
            {
                if (file.EndsWith(".png"))
                {
                    string cardName = file.Substring(file.LastIndexOf("\\") + 1);
                    string BoxSet = "No Box Set";
                    Console.WriteLine("copying: " + cardName);
                    if (cardName.Contains('-'))
                    {
                        BoxSet = cardName.Substring(0, cardName.IndexOf('-'));
                    }

                    if (file.Substring(0, file.LastIndexOf("\\")).Contains("Character"))
                    {
                        Cards.Add(new Card(iCharacter, CardType.Type.Character, cardName, BoxSet));
                        string fileName = "_" + iCharacter + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iCharacter++;
                    }
                    else if (file.Substring(0, file.LastIndexOf("\\")).Contains("Starting Item"))
                    {
                        Cards.Add(new Card(iStartingItem, CardType.Type.StartingItem, cardName, BoxSet));
                        string fileName = "_" + iStartingItem + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iStartingItem++;
                    }
                    else if (file.Substring(0, file.LastIndexOf("\\")).Contains("Monster"))
                    {
                        Cards.Add(new Card(iMonster, CardType.Type.Monster, cardName, BoxSet));
                        string fileName = "_" + iMonster + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iMonster++;
                    }
                    else if (file.Substring(0, file.LastIndexOf("\\")).Contains("Treasure"))
                    {
                        Cards.Add(new Card(iTreasure, CardType.Type.Treasure, cardName, BoxSet));
                        string fileName = "_" + iTreasure + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iTreasure++;
                    }
                    else if (file.Substring(0, file.LastIndexOf("\\")).Contains("Loot"))
                    {
                        Cards.Add(new Card(iLoot, CardType.Type.Loot, cardName, BoxSet));
                        string fileName = "_" + iLoot + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iLoot++;
                    }
                    else if (file.Substring(0, file.LastIndexOf("\\")).Contains("Bonus Soul"))
                    {
                        Cards.Add(new Card(iBonusSoul, CardType.Type.BonusSoul, cardName, BoxSet));
                        string fileName = "_" + iBonusSoul + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iBonusSoul++;
                    }
                    else if (file.Substring(0, file.LastIndexOf("\\")).Contains("Room"))
                    {
                        Cards.Add(new Card(iRoom, CardType.Type.Room, cardName, BoxSet));
                        string fileName = "_" + iRoom + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iRoom++;
                    }
                    else
                    {
                        Cards.Add(new Card(iNoType, CardType.Type.NoType, cardName, BoxSet));
                        string fileName = "_" + iNoType + ".png";
                        string destination = "Cards\\" + fileName;
                        File.Copy(file, destination);
                        iNoType++;
                    }
                }
            }
        }
        private void generateCSVFile()
        {
            var csv = new StringBuilder();
            var newLine = string.Format($"{"ID"};{"Name"};{"Card Type"};{"Box Set"}");
            csv.AppendLine(newLine);
            foreach (Card card in Cards)
            {
                var first = card.id.ToString();
                var second = card.name;
                var third = card.cardType;
                var fourth = card.boxSet;

                newLine = string.Format($"{first};{second};{third};{fourth}");
                csv.AppendLine(newLine);

            }
            File.WriteAllText("TBoI Cards.csv", csv.ToString());
        }
    }
}
