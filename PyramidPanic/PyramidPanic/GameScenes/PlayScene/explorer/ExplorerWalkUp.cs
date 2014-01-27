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
        public void initialize()
        {
            this.destinationRect.X = (int)this.explorer.Position.X;
            this.destinationRect.Y = (int)this.explorer.Position.Y;
        }

        public new void Update(GameTime gameTime)
        {
            this.explorer.Position -= new Vector2(0f, this.explorer.Speed);

            if (this.explorer.Position.Y < 16)
            {
                this.explorer.Position += new Vector2(0f, this.explorer.Speed); 
                this.explorer.State = this.explorer.IdleWalk;
               
                this.explorer.IdleWalk.Effect = SpriteEffects.None;
                this.explorer.IdleWalk.Rotation = -(float)Math.PI / 2;
            }
            if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                this.explorer.State = this.explorer.Idle;
                this.explorer.Idle.Effect = SpriteEffects.None;
                this.explorer.Idle.Rotation = -(float)Math.PI / 2;
            }
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}