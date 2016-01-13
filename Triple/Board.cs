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
        public Card[] playedCards { get; private set; }
        public Player[] controllingPlayer { get; private set; }

        // The card set to use
        public CardSet cardset { get; private set; }

        public Board()
        {
            playedCards = new Card[9];
            controllingPlayer = new Player[9];
            cardset = new CardSet();
        }

        public Card GetPlayedCard(int cell)
        {
            return playedCards[cell];
        }

        Random rand = new Random();
        public void Shuffle()
        {
            for (int i = 0; i < 9; i++)
            {
                playedCards[i] = cardset[rand.Next(0, 110)];
                controllingPlayer[i] = (Player)rand.Next(1, 3);
            }
        }

        // Fills the board with Doomtarin
        // Just for testing to make sure that spritesheets are working
        public void DatTrain()
        {
            for (int i = 0; i < 9; i++)
            {
                playedCards[i] = cardset[97];
                controllingPlayer[i] = Player.Red;
            }
        }

        public Card CheckCellCard(int cell)
        {
            return playedCards[cell];
        }

        public Player CheckCellOwner(int cell)
        {
            return controllingPlayer[cell];
        }

        private enum Direction
        {
            North,
            South,
            East,
            West
        }

        private bool CellOccupied(int cell)
        {
            return playedCards[cell] != null;
        }

        // Vector is the direction of attack, relative to the attacker
        // So East would mean the attackers eastern power vs defenders west
        private void BattleCards(Card attacker, Direction vector, int defendingCell, Player attackingPlayer)
        {
            if (!CellOccupied(defendingCell))
                return;

            Card defender = GetPlayedCard(defendingCell);

            switch (vector)
            {
                case Direction.East:
                    if (attacker.East > defender.West)
                        TakeControl(defendingCell, attackingPlayer);
                    return;

                case Direction.West:
                    if (attacker.West > defender.East)
                        TakeControl(defendingCell, attackingPlayer);
                    return;

                case Direction.North:
                    if (attacker.North > defender.South)
                        TakeControl(defendingCell, attackingPlayer);
                    return;

                case Direction.South:
                    if (attacker.South > defender.North)
                        TakeControl(defendingCell, attackingPlayer);
                    return;
                default:
                    throw new ArgumentException("Something has gone wrong when battling two cards, invalid attack vector.");
            }
        }

        private void TakeControl(int cell, Player player)
        {
            controllingPlayer[cell] = player;
        }

        public void PlayCard(int cell, int cardID, Player player)
        {
            Card playedCard = cardset[cardID];

            playedCards[cell] = playedCard;
            controllingPlayer[cell] = player;

            // Cells 012
            //       345
            //       678

            switch (cell)
            {
                case 0:
                    BattleCards(playedCard, Direction.East, 1, player);
                    BattleCards(playedCard, Direction.South, 3, player);
                    break;
                case 1:
                    BattleCards(playedCard, Direction.West, 0, player);
                    BattleCards(playedCard, Direction.East, 2, player);
                    BattleCards(playedCard, Direction.South, 4, player);
                    break;
                case 2:
                    BattleCards(playedCard, Direction.West, 1, player);
                    BattleCards(playedCard, Direction.South, 5, player);
                    break;
                case 3:
                    BattleCards(playedCard, Direction.North, 0, player);
                    BattleCards(playedCard, Direction.East, 4, player);
                    BattleCards(playedCard, Direction.South, 6, player);
                    break;
                case 4:
                    BattleCards(playedCard, Direction.North, 1, player);
                    BattleCards(playedCard, Direction.West, 3, player);
                    BattleCards(playedCard, Direction.East, 5, player);
                    BattleCards(playedCard, Direction.South, 7, player);
                    break;
                case 5:
                    BattleCards(playedCard, Direction.North, 2, player);
                    BattleCards(playedCard, Direction.West, 4, player);
                    BattleCards(playedCard, Direction.South, 8, player);
                    break;
                case 6:
                    BattleCards(playedCard, Direction.North, 3, player);
                    BattleCards(playedCard, Direction.West, 7, player);
                    break;
                case 7:
                    BattleCards(playedCard, Direction.North, 4, player);
                    BattleCards(playedCard, Direction.West, 6, player);
                    BattleCards(playedCard, Direction.East, 8, player);
                    break;
                case 8:
                    BattleCards(playedCard, Direction.North, 5, player);
                    BattleCards(playedCard, Direction.West, 7, player);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Somehow attacking from an invalid cell.  Good going champ.");
            }
        }
    }
}
