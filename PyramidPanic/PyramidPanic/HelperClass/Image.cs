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

namespace PyramidPanic
{
    public class Image
    {
                //fields
        private Texture2D texture;
                //maak een rectangle voor het detecteren van collision
        private Rectangle rec;
        
                //properties

                //constructor
        public Image(PyramidPanic game, String pathNameAsset, Vector2 position)
        {
            this.texture = game.Content.Load<Texture2D>(pathNameAsset);
            this.rec = new Rectangle((int)position.X, (int) position.Y, this.texture.Width, this.texture.Height);
        }

                //loadcontent

                //update

                //draw
        public void Draw(GameTime gameTime)
        {
            
        }

                //helpermethode
    }
}
