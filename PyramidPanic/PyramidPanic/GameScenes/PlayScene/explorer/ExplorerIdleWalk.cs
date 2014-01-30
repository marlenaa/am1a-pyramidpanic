//dit is de idlewalk class, als je tegen een muur loopt blijft hij hierdoor doorlopen
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
    public class ExplorerIdleWalk : AnimatedSprite, IEntityState
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
        public ExplorerIdleWalk(Explorer explorer) : base(explorer)
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
           //dit is als de rechterknop losgelaten word
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = 0f;

            }
            //dit is als de linkerknop losgelaten word
            else if(Input.EdgeDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.Idle.Rotation = 0f;

            }
            //dit is als de omhoog knop losgelaten word
            else if(Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = -(float)Math.PI/2;
            }
            //dit is als de naar beneden knop losgelaten word
            else if(Input.EdgeDetectKeyUp(Keys.Down))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = (float)Math.PI/2;
            }
            //zorgt voor de animatie.
            base.Update(gameTime);
        }
        //draw
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}