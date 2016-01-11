using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Triple
{
    class SpriteSheet
    {
        private Texture2D sheet;
        public int SpriteWidth { get; private set; }
        public int SpriteHeight { get; private set; }

        public int ScaledWidth
        {
            get
            {
                return (int)(SpriteWidth * ScaleX);
            }
        }

        public int ScaledHeight
        {
            get
            {
                return (int)(SpriteHeight * ScaleY);
            }
        }

        public float ScaleX { get; set; }
        public float ScaleY { get; set; }

        // How wide the sheet is, in number of sprites.
        private int spritesWide;

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
                return new Point((int)Math.Floor(SpriteWidth * ScaleX), (int)Math.Floor(SpriteHeight * ScaleY));
            }
        }

        public SpriteSheet(Texture2D sheet, int spriteWidth, int spriteHeight)
        {
            this.sheet = sheet;
            this.SpriteHeight = spriteHeight;
            this.SpriteWidth = spriteWidth;

            ScaleX = ScaleY = 1.0f;

            spritesWide = sheet.Width / spriteWidth;
            Console.WriteLine(spritesWide);
        }

        public void Draw(SpriteBatch batch, int spriteID, Point location)
        {
            Draw(batch, spriteID, location.X, location.Y);
        }

        public void Draw(SpriteBatch batch, int spriteID, int x, int y)
        {
            // Sheet is 28 cards wide
            int sheetX = (spriteID % spritesWide) * SpriteWidth;
            int sheetY = (spriteID / spritesWide) * SpriteHeight;

            Rectangle rect = new Rectangle(sheetX, sheetY, SpriteWidth, SpriteHeight);

            batch.Draw(sheet, new Rectangle(x, y, (int)Math.Floor(SpriteWidth * ScaleX), (int)Math.Floor(SpriteHeight * ScaleY)), rect, Color.White);
        }
    }
}
