﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace Triple
{
    class ContentPackage
    {
        // Audio
        public Song Music { get; private set; }
        public SoundEffect Sfx { get; private set; }

        // Graphics
        public SpriteSheet Cards { get; private set; }
        public SpriteSheet Blue { get; private set; }
        public SpriteSheet Red { get; private set; }
        public Texture2D Background { get; private set; }
        public Texture2D Cursor { get; private set; }

        // Utility
        private ContentManager Content { get; set; }

        public ContentPackage(ContentManager content)
        {
            Content = content;
        }

        const int cardSize = 64;
        public void LoadContent()
        {
            // Audio
            Music = Content.Load<Song>("music2");
            Sfx = Content.Load<SoundEffect>("sfx_cursor");

            // Graphics
            Background = Content.Load<Texture2D>("bg");
            Cursor = Content.Load<Texture2D>("cursor");
            Cards = new SpriteSheet(Content.Load<Texture2D>("cards"), cardSize, cardSize);
            Blue = new SpriteSheet(Content.Load<Texture2D>("blue"), cardSize, cardSize);
            Red = new SpriteSheet(Content.Load<Texture2D>("red"), cardSize, cardSize);

            // Settings
            // Magic numbers I don't give a fuuuuuuuuuuck
            Cards.ScaleX = 1.75f;
            Cards.ScaleY = 2.20f;
            Red.Scale = Cards.Scale;
            Blue.Scale = Cards.Scale;
        }
    }
}
