//dit is de explorer walk up class hiermee kan de explorer omhoog lopen
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
    public class ExplorerWalkUp : AnimatedSprite, IEntityState
    {
        //Fields
        private Explorer explorer;

        //contructor
        public ExplorerWalkUp(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRect = new Rectangle((int)this.explorer.Position.X,
                                                (int)this.explorer.Position.Y,
                                                32,
                                                32);
            this.effect = SpriteEffects.None;
            this.rotation = -(float)Math.PI / 2;

        }
        //met de initialize methode geven we de positie mee 
        public void initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }
        //update
        public new void Update(GameTime gameTime)
        {
            this.explorer.Position -= new Vector2(0f, this.explorer.Speed);

            //als de positie kleiner is dat Y -16
            if (this.explorer.Position.Y < 16)
            {
                //word de snelheid meegegeven
                this.explorer.Position += new Vector2(0f, this.explorer.Speed); 
                //word de idle state meegegeven
                this.explorer.State = this.explorer.IdleWalk;
               //word de sprite effect meegegeven
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                //word de rotatie meegegeven
                this.explorer.IdleWalk.Rotation = -(float)Math.PI / 2;
            }
            //als de omhoog toets word ingedrukt
            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                //word de explorer idle aangeroepen
                this.explorer.State = this.explorer.Idle;
                //word de effect aangepast
                this.explorer.Idle.Effect = SpriteEffects.None;
                //het plaats word zo gedraaid dat het naar boven word gericht
                this.explorer.Idle.Rotation = -(float)Math.PI / 2 ;
            }
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}