namespace Four_souls_card_parser
{
    class Card
    {
        public uint id { get; set; }
        public CardType.Type cardType { get; set; }
        public string name { get; set; }
        public string boxSet { get; set; }

        public Card(uint inputId, CardType.Type inputType, string inputName, string inputBoxSet)
        {
            this.id = inputId;
            this.cardType = inputType;
            this.name = inputName;
            this.boxSet = inputBoxSet;
        }
    }
}