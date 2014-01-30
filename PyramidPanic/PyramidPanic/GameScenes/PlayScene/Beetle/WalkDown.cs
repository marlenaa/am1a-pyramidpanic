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
    public class WalkDown : AnimatedSprite, IEntityState
    {
        //Fields
        private Beetle beetle;

        //contructor
        public WalkDown(Beetle beetle) : base(beetle)
        {
            this.effect = SpriteEffects.FlipVertically;
            this.beetle = beetle;
            this.destinationRect = new Rectangle((int)this.beetle.Position.X,
                                                (int)this.beetle.Position.Y,
                                                32,
                                                32);
        }
        //met initialize word de x en de y meegegeven.
        public void initialize()
        {
            this.destinationRect.X = (int)this.beetle.Position.X;
            this.destinationRect.Y = (int)this.beetle.Position.Y;
        }
        //update
        public new void Update(GameTime gameTime)
        {
            //als de beetle een rand raakt
            if (this.beetle.Position.Y > 480 - 48)
            {
                //gaat hij weer omhoog
                this.beetle.State = new WalkUp(this.beetle);
                //word de initialize meegegeven
                this.beetle.WalkUp.initialize();
            }
            //dit is de snelheid van de beetle
            this.beetle.Position += new Vector2(0f, this.beetle.Speed);
            this.destinationRect.X = (int)this.beetle.Position.X;
            this.destinationRect.Y = (int)this.beetle.Position.Y;
            //zorgt ervoor dat het beweegt
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}