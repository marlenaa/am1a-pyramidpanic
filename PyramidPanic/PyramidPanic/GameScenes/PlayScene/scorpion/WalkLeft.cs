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

        public new void Update(GameTime gameTime)
        {
            if (this.scorpion.Position.X < 0)
            {
                this.scorpion.State = new WalkRight(this.scorpion);
            }
            this.scorpion.Position -= new Vector2(this.scorpion.Speed, 0f);
            this.destinationRect.X = (int)this.scorpion.Position.X;
            this.destinationRect.Y = (int)this.scorpion.Position.Y;
            base.Update(gameTime);
        }

        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}