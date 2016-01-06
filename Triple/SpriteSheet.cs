using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Triple
{
    class SpriteSheet
    {
        private Texture2D sheet;
        private int spriteWidth;
        private int spriteHeight;

        public float ScaleX { get; set; }
        public float ScaleY { get; set; }

        public Vector2 Scale
        {
            get
            {
                return new Vector2(ScaleX, ScaleY);
            }
            set
            {
                ScaleX = value.X;
                ScaleY = value.Y;
            }
        }

        public Point ScaledSpriteSize
        {
            get
            {
                return new Point((int)Math.Floor(spriteWidth * ScaleX), (int)Math.Floor(spriteHeight * ScaleY));
            }
        }

        public SpriteSheet(Texture2D sheet, int spriteWidth, int spriteHeight)
        {
            this.sheet = sheet;
            this.spriteHeight = spriteHeight;
            this.spriteWidth = spriteWidth;

            ScaleX = ScaleY = 1.0f;
        }

        public void Draw(SpriteBatch batch, int spriteID, Point location)
        {
            Draw(batch, spriteID, location.X, location.Y);
        }

        public void Draw(SpriteBatch batch, int spriteID, int x, int y)
        {
            // Sheet is 28 cards wide
            int sheetX = (spriteID % 28) * spriteWidth;
            int sheetY = (spriteID / 28) * spriteHeight;

            Rectangle rect = new Rectangle(sheetX, sheetY, spriteWidth, spriteHeight);

            batch.Draw(sheet, new Rectangle(x, y, (int)Math.Floor(spriteWidth * ScaleX), (int)Math.Floor(spriteHeight * ScaleY)), rect, Color.White);
        }
    }
}
