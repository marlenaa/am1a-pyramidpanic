﻿//dit is de walk down class hiermee kan de explorer omlaag lopen
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
    public class ExplorerWalkDown : AnimatedSprite, IEntityState
    {
        //Fields
        private Explorer explorer;

        //contructor
        public ExplorerWalkDown(Explorer explorer) : base(explorer)
        {
            this.effect = SpriteEffects.FlipVertically;
            this.explorer = explorer;
            this.rotation = (float)Math.PI / 2;
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
            this.explorer.Position += new Vector2(0f, this.explorer.Speed);
            //als de positie y > 480 - 48 is:
            if (this.explorer.Position.Y > 480 - 48)
            {
                //word de snelheid meegegeven
                this.explorer.Position -= new Vector2(0f, this.explorer.Speed);
                //word de idlewalk class meegegeven
                this.explorer.State = this.explorer.IdleWalk;
                //word het effect meegegeven
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                //word het plaatje gedraaid
                this.explorer.IdleWalk.Rotation = (float)Math.PI / 2;
            }
            //als de omlaag knop word ingedrukt
            if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                //word de idle state meegegeven
                this.explorer.State = this.explorer.Idle;
                //word het effect meegegeven
                this.explorer.Idle.Effect = SpriteEffects.None;
                //word het plaatje gedraaid
                this.explorer.Idle.Rotation = (float)Math.PI / 2;
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