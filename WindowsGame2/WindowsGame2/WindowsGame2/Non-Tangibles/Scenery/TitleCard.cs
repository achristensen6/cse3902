﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame2
{
    // Bush Background.
    public class TitleCard : IBackground
    {
        public IAnimatedSprite Sprite { get; set; }
        int x;
        int y;

        public TitleCard(int x, int y)
        {
            this.Sprite = new Animation(Textures.titleCard);
            this.x = x;
            this.y = y;
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw(SpriteBatch sb, Rectangle camera)
        {
            Sprite.Draw(sb, x - camera.X, y - camera.Y);
        }
    }
}
