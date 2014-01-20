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
    public class ExplorerWalkRight : AnimatedSprite, IEntityState
    {
        //Fields
        private Explorer explorer;

        //contructor
        public ExplorerWalkRight(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRect = new Rectangle((int)this.explorer.Position.X,
                                                (int)this.explorer.Position.Y,
                                                32,
                                                32);
        }

        public new void Update(GameTime gameTime)
        {
            if (this.explorer.Position.X > 640 - 32)
            {
                this.explorer.State = new WalkLeft(this.explorer);
            }
            this.explorer.Position += new Vector2(this.explorer.Speed, 0f);
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}