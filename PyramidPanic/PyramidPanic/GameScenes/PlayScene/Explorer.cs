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
    public class Explorer
    {
        //fields
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private int maxSpeed = 6;
        private SpriteEffects effect = SpriteEffects.None;
        private Rectangle destinationRect, sourceRect;
        //properties
        public Rectangle DestinationRect
        {
            get { return this.destinationRect; }
            set { this.destinationRect = value; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }

        }
        //constructor
        public Explorer(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();

                this.texture = this.game.Content.Load<Texture2D>(@"PlayScene/Explorer");
                this.position = position;
                this.destinationRect = new Rectangle((int)this.position.X,
                                                     (int)this.position.Y,
                                                     32, 32);
                this.sourceRect = new Rectangle(0, 0, 32, 32);
        }
        //Initialize methode. deze methode initialiseert( geeft standaartwaarden aan variabelen)
        //void wil zeggen dat er niets teruggeven word.
        public void Initialize()
        {
            this.LoadContent();
        }
        //loadcontent method.e deze methode maakt nieuwe objecten aan van de verschillende classes.
        public void LoadContent()
        {
            this.texture = this.game.Content.Load<Texture2D>(@"PlayScene/Explorer");
        }
        //update methode
        public void Update(GameTime gameTime)
        {
            this.destinationRect.X += this.maxSpeed;
        }
        //draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture,
                             this.destinationRect,
                             this.sourceRect,
                             Color.White,
                             0f,
                             Vector2.Zero,
                             this.effect,
                             0.4f);
        }
    }
}
