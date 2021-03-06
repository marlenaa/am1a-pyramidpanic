﻿//usings zijn XNA code bibliotheek gebruiken
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
        //met de initialize methode geven we de positie mee 
        public void initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            //dit is de snelheid waarmee die gaat lopen
            this.explorer.Position += new Vector2(this.explorer.Speed, 0f);
            //als de positie x > 640 - 16 is
            if (this.explorer.Position.X > 640 - 16)
            {
                //word de snelheid meegegeven
                this.explorer.Position -= new Vector2(this.explorer.Speed, 0f);
                //word de idlewalk class meegegeven
                this.explorer.State = this.explorer.IdleWalk;
                //word het effect meegegeven
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                //word de rotatie meegegeven
                this.explorer.IdleWalk.Rotation = 0f;
            }
            //als de rechter knop word ingedrukt
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                //word de idle state meegegeven
                this.explorer.State = this.explorer.Idle;
                //word het effect meegegeven
                this.explorer.Idle.Effect = SpriteEffects.None;
                //word de rotatie meegegeven
                this.explorer.Idle.Rotation = 0f;
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