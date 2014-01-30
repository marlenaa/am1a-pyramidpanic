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
    public class ExplorerWalkLeft : AnimatedSprite, IEntityState
    {
        //Fields
        private Explorer explorer;

        //contructor
        public ExplorerWalkLeft(Explorer explorer) : base(explorer)
        {
            this.effect = SpriteEffects.FlipHorizontally;
            this.explorer = explorer;
            this.destinationRect = new Rectangle((int)this.explorer.Position.X,
                                                (int)this.explorer.Position.Y,
                                                32,
                                                32);
        }
        //met de initialize methode geven we de positie mee 
        public void initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }
        public new void Update(GameTime gameTime)
        {
            //dit is de snelheid waarmee de explorer moet lopen
            this.explorer.Position -= new Vector2(this.explorer.Speed, 0f);

            //als de positie x < 16 is
            if (this.explorer.Position.X < 16)
            {
                //word de snelheid meegegeven
                this.explorer.Position += new Vector2(this.explorer.Speed, 0f);
                //word de idle walk meegegeven
                this.explorer.State = this.explorer.IdleWalk;
                //word het effect meegegeven
                this.explorer.IdleWalk.Effect = SpriteEffects.FlipHorizontally;   
                //word het plaatje niet gedraaid
                this.explorer.IdleWalk.Rotation = 0f;

            }
            //als de linker knop word ingedrukt
            if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                //word de idle toestand aangeroepen
                this.explorer.State = this.explorer.Idle;
                //word het effect meegegeven
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                //word de inirialize methode meegegeven
                this.explorer.Idle.initialize();
                //word de rotatie meegegeven
                this.explorer.Idle.Rotation = 0f;
            }
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}