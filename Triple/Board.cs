using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Triple
{
    class Board
    {
        public enum Player
        {
            None,
            Blue,
            Red
        }

        // Slots are numbered 012,345,678 from the top left in left to right top to bottom order.

        // Stores card IDs
        public int[] playedCards { get; private set; }
        public Player[] controllingPlayer { get; private set; }

        // The card set to use
        public CardSet Cards { get; private set; }

        public Board()
        {
            playedCards = new int[9];
            controllingPlayer = new Player[9];
            Cards = new CardSet();
        }

        Random rand = new Random();
        public void Shuffle()
        {
            for(int i = 0; i<9;i++)
            {
                playedCards[i] = rand.Next(0,110);
                controllingPlayer[i] = (Player)rand.Next(1,3);
            }
        }

        public int CheckCellCard(int cell)
        {
            return playedCards[cell];
        }

        public Player CheckCellOwner(int cell)
        {
            return controllingPlayer[cell];
        }
    }
}
