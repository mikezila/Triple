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
                    throw new Exception("Bad cell number " + cell);
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
                switch (board.controllingPlayer[i])
                {
                    case Board.Player.Blue:
                        Assets.Blue.Draw(Batch, 1, PointForCell(i));
                        break;
                    case Board.Player.Red:
                        Assets.Red.Draw(Batch, 1, PointForCell(i));
                        break;
                    case Board.Player.None:
                        continue;
                    default:
                        throw new Exception("Invalid Player Color." + board.controllingPlayer[i]);
                }
                Assets.Cards.Draw(Batch, board.Cards.Cards[board.playedCards[i]].spriteID, PointForCell(i));
            }
            Batch.End();
        }
    }
}
