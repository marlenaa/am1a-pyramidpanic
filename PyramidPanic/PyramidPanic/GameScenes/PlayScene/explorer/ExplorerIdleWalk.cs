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
        //initialize
        public void initialize()
        {        
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;

        }

        public new void Update(GameTime gameTime)
        {
           
            if (Input.EdgeDetectKeyUp(Keys.Right))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = 0f;

            }
            else if(Input.EdgeDetectKeyUp(Keys.Left))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.FlipHorizontally;
                this.explorer.Idle.Rotation = 0f;

            }
            else if(Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = -(float)Math.PI/2;
            }
            else if(Input.EdgeDetectKeyUp(Keys.Down))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = (float)Math.PI/2;
            }
            //zorgt voor de animatie.
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}