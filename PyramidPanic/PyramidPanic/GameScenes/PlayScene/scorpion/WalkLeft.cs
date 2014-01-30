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
    //hiermee beloofd de walkleft class zich te houden aan de wetten en regels van de animated sprite class
    //de eerste is de ervende class
    public class WalkLeft : AnimatedSprite, IEntityState
    {
        //Fields
        private Scorpion scorpion;
        
        //contructor
        public WalkLeft(Scorpion scorpion) : base(scorpion)
        {
            this.effect = SpriteEffects.FlipHorizontally;
            this.scorpion = scorpion;
            this.destinationRect = new Rectangle((int)this.scorpion.Position.X,
                                                (int)this.scorpion.Position.Y,
                                                32,
                                                32);
        }
        public void initialize()
        {

        }

        public new void Update(GameTime gameTime)
        {
            //als de scorpion de rand raakt
            if (this.scorpion.Position.X < 16)
            {
                //gaat hij weer naar rechts
                this.scorpion.State = new WalkRight(this.scorpion);
            }
            //de snelheid word meegegeven
            this.scorpion.Position -= new Vector2(this.scorpion.Speed, 0f);
            this.destinationRect.X = (int)this.scorpion.Position.X;
            this.destinationRect.Y = (int)this.scorpion.Position.Y;
            //hiermee zorg je dat hij beweegd
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}