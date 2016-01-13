using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triple
{
    class Card
    {
        public string Name { get; private set; }
        public int ID { get; private set; }
        public int spriteID { get; private set; }

        public int North { get; private set; }
        public int South { get; private set; }
        public int East { get; private set; }
        public int West { get; private set; }

        public CardElement Element { get; set; }
        public int Level { get; private set; }

        public int Value
        {
            get
            {
                return North + South + East + West;
            }
        }

        public enum CardElement
        {
            None,
            Lightning,
            Poison,
            Wind,
            Earth,
            Fire,
            Water,
            Ice,
            Holy
        }

        public Card(int ID, string name, int north, int east, int south, int west, int level, CardElement element, int spriteNumber)
        {
            this.ID = ID;
            Name = name;
            North = north;
            South = south;
            East = east;
            West = west;
            Level = level;
            Element = element;
            spriteID = spriteNumber;

            if(ID == 0)
            {
                North = South = East = West = 10;
                Element = CardElement.None;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
