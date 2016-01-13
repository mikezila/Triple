using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Triple
{
    class CardSet
    {
        private Dictionary<int, Card> Cards { get; set; }

        public Card this[int cardID]
        {
            get
            {
                return Cards[cardID];
            }
        }

        public CardSet()
        {
            LoadCardDB();
        }

        private void LoadCardDB()
        {
            Cards = new Dictionary<int, Card>();

            var cardList = File.ReadLines("cards.db");
            cardList = from card in cardList where card.Contains("#") != true select card.Replace("\"", string.Empty);

            foreach (var card in cardList)
            {
                string[] attributes = card.Split(',');
                int ID = int.Parse(attributes[0]);
                string name = attributes[1];
                int N = int.Parse(attributes[2]);
                int E = int.Parse(attributes[3]);
                int S = int.Parse(attributes[4]);
                int W = int.Parse(attributes[5]);
                int level = int.Parse(attributes[6]) + 1; // Level in DB is one less than actual level, so add one.
                Card.CardElement element = (Card.CardElement)Enum.Parse(typeof(Card.CardElement), attributes[7], true);
                int spriteID = int.Parse(attributes[8]);

                Cards.Add(ID, new Card(ID, name, N, E, S, W, level, element, spriteID));
            }
        }
    }
}
