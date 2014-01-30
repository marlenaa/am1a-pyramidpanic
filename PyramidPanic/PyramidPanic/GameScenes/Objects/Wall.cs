//usings zijn XNA code bibliotheek gebruiken
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic.GameScenes.Objects
{
    //hiermee beloofd wall om zich te houden aan de wetten en regels van IStaticObject
    public class Wall : IStaticObject
    {
        //fields
        private Rectangle collisionrect;
        private Texture2D image;

        //constructor
        public Wall(int X, int Y, Texture2D image)
        {
            this.collisionrect = new Rectangle(X * 32, Y * 32, 32, 32);
            this.image = image;
        }
        //properties
        public Rectangle CollisionRect()
        {
            return this.collisionrect;
        }
        //draw
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(this.image, this.collisionrect, Color.White);
        }
    }
}
