using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triple
{
    class RenderManager
    {
        private ContentPackage Assets { get; set; }
        private SpriteBatch Batch { get; set; }

        // Top left point for cell 0
        readonly Point boardOrigin = new Point(85, 45);

        public RenderManager(ContentPackage contentPackage, SpriteBatch spriteBatch)
        {
            Assets = contentPackage;
            Batch = spriteBatch;
        }

        private Point PointForCell(int cell)
        {
            switch (cell)
            {
                case 0:
                    return boardOrigin;
                case 1:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.X += Assets.Cards.ScaledSpriteSize.X;
                        return cellPoint;
                    }
                case 2:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.X += Assets.Cards.ScaledSpriteSize.X * 2;
                        return cellPoint;
                    }
                case 3:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.Y += Assets.Cards.ScaledSpriteSize.Y;
                        return cellPoint;
                    }
                case 4:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.Y += Assets.Cards.ScaledSpriteSize.Y;
                        cellPoint.X += Assets.Cards.ScaledSpriteSize.X;
                        return cellPoint;
                    }
                case 5:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.Y += Assets.Cards.ScaledSpriteSize.Y;
                        cellPoint.X += Assets.Cards.ScaledSpriteSize.X * 2;
                        return cellPoint;
                    }
                case 6:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.Y += Assets.Cards.ScaledSpriteSize.Y * 2;
                        return cellPoint;
                    }
                case 7:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.Y += Assets.Cards.ScaledSpriteSize.Y * 2;
                        cellPoint.X += Assets.Cards.ScaledSpriteSize.X;
                        return cellPoint;
                    }
                case 8:
                    {
                        Point cellPoint = boardOrigin;
                        cellPoint.Y += Assets.Cards.ScaledSpriteSize.Y * 2;
                        cellPoint.X += Assets.Cards.ScaledSpriteSize.X * 2;
                        return cellPoint;
                    }
                default:
                    throw new Exception("Bad cell number: " + cell);
            }
        }

        private void DrawBackground()
        {
            Batch.Draw(Assets.Background, Vector2.Zero);
        }

        public void DrawBoard(Board board)
        {
            Batch.Begin();
            DrawBackground();
            for (int i = 0; i < 9; i++)
            {
                // Draw red/blue background
                switch (board.controllingPlayer[i])
                {
                    case Board.Player.Blue:
                        Assets.Blue.Draw(Batch, 0, PointForCell(i));
                        break;
                    case Board.Player.Red:
                        Assets.Red.Draw(Batch, 0, PointForCell(i));
                        break;
                    case Board.Player.None:
                        continue;
                    default:
                        throw new Exception("Invalid Player Color." + board.controllingPlayer[i]);
                }

                // Draw this cell's card art
                Assets.Cards.Draw(Batch, board.Cardset.Cards[board.playedCards[i]].spriteID, PointForCell(i));

                // Draw the cards power digits using shittacular fonts I found on Google
                // Drawn in NSEW order
                Assets.Digits.Draw(Batch, board.GetPlayedCard(i).North, PointForCell(i).X + (Assets.Cards.ScaledWidth / 2) - (Assets.Digits.ScaledWidth / 2), PointForCell(i).Y);
                Assets.Digits.Draw(Batch, board.GetPlayedCard(i).South, PointForCell(i).X + (Assets.Cards.ScaledWidth / 2) - (Assets.Digits.ScaledWidth / 2), PointForCell(i).Y + (Assets.Cards.ScaledHeight - Assets.Digits.ScaledHeight));
                Assets.Digits.Draw(Batch, board.GetPlayedCard(i).East, PointForCell(i).X + Assets.Cards.ScaledWidth - Assets.Digits.ScaledWidth, PointForCell(i).Y + (Assets.Cards.ScaledHeight / 2 - (Assets.Digits.ScaledHeight / 2)));
                Assets.Digits.Draw(Batch, board.GetPlayedCard(i).West, PointForCell(i).X, PointForCell(i).Y + (Assets.Cards.ScaledHeight / 2 - (Assets.Digits.ScaledHeight / 2)));
            }
            Batch.End();
        }
    }
}
