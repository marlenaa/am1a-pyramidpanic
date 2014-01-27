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
        protected float rotation = 0f;
        private Vector2 pivot;
        //Constructor
        public AnimatedSprite(IAnimatedSprite iAnimatedSprite)
        {
            this.iAnimatedSprite = iAnimatedSprite;
            this.sourceRect = new Rectangle(32, 0, 32, 32);
            this.effect = SpriteEffects.None;
            this.pivot = new Vector2(16f, 16f);

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
            this.iAnimatedSprite.Game.SpriteBatch.Draw(this.iAnimatedSprite.Texture, this.destinationRect, this.sourceRect, Color.White, this.rotation, this.pivot, this.effect, 0);
        }


    }
}
