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
    public abstract class AnimatedSprite
    {
        //Fields
        private IAnimatedSprite iAnimatedSprite;
        private float timer = 0f;
        protected Rectangle destinationRect, sourceRect;
        protected SpriteEffects effect;
        //Constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
            this.iAnimatedSprite = iAnimatedSprite;
            this.sourceRect = new Rectangle(0, 0, 32, 32);
            this.effect = SpriteEffects.None;

        }
        //Update
        public void Update(GameTime gameTime)
        {
            if (this.timer > 10 / 60f)
            {
                if (this.sourceRect.X < 96)
                {
                    this.sourceRect.X += 32;
                }
                else
                {
                    this.sourceRect.X = 0;
                }

                this.timer = 0f;
            }
            this.timer += 1 / 60f;
        }
        

        

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.iAnimatedSprite.Game.SpriteBatch.Draw(this.iAnimatedSprite.Texture, this.destinationRect, this.sourceRect, Color.White, 0f, Vector2.Zero, this.effect, 0);
        }


    }
}
