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
    //dit is een toestands class ( dus hij moet de interface implementeren)
    //de eerste naam is de ervende class.
    public class WalkUp : AnimatedSprite, IEntityState
    {
        //Fields
        private Beetle beetle;

        //contructor
        public WalkUp(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
            this.destinationRect = new Rectangle((int)this.beetle.Position.X,
                                                (int)this.beetle.Position.Y,
                                                32,
                                                32);
        }
        public void initialize()
        {
            this.destinationRect.X = (int)this.beetle.Position.X;
            this.destinationRect.Y = (int)this.beetle.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            if (this.beetle.Position.Y < 16)
            {
                this.beetle.State = this.beetle.WalkDown;
                this.beetle.WalkDown.initialize();
                
            }
            this.beetle.Position -= new Vector2(0f, this.beetle.Speed);
            this.destinationRect.X = (int)this.beetle.Position.X;
            this.destinationRect.Y = (int)this.beetle.Position.Y;
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}