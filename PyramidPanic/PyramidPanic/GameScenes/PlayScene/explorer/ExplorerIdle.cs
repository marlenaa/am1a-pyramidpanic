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
    public class ExplorerIdle : AnimatedSprite, IEntityState
    {
        //Fields
        private Explorer explorer;

        //properties
        public SpriteEffects Effect
        {
            set { base.effect = value; }
        }

        public float Rotation
        {
            set { base.rotation = value; }
        }

        //contructor
        public ExplorerIdle(Explorer explorer) : base(explorer)
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
            if (this.explorer.Position.X > 640 - 32)
            {
               // this.explorer.State = new WalkLeft(this.explorer);
            }
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.explorer.State = this.explorer.WalkRight;
            }
            else if(Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.explorer.State = this.explorer.WalkLeft;

            }
            else if(Input.EdgeDetectKeyDown(Keys.Up))
            {
                this.explorer.State = this.explorer.WalkUp;
            }
            else if(Input.EdgeDetectKeyDown(Keys.Down))
            {
                this.explorer.State = this.explorer.WalkDown;
            }

            this.explorer.Position += new Vector2(0f, 0f);
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
            //base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}