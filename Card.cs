using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four_souls_card_parser
{
    class Card
    {
        private uint id;
        private CardType.Type cardType;
        private string name;
        private string boxSet;

        public Card(uint inputId, CardType.Type inputType, string inputName, string inputBoxSet)
        {
            this.id = inputId;
            this.cardType = inputType;
            this.name = inputName;
            this.boxSet = inputBoxSet;
        }
    }
}