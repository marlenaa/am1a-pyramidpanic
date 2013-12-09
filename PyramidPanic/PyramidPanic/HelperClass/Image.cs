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
    public class Image
    {
                //fields
        private Texture2D texture;
        private Texture2D title;
        private Texture2D startButton;
        private Texture2D scoresButton;
        private Texture2D loadButton;
        private Texture2D helpButton;
        private Texture2D quitButton;
                //maak een rectangle voor het detecteren van collision
        private Rectangle rec;
                //maak een variabele
        private PyramidPanic game;
                //maak een variabele aan van het type Color met de naam color
        private Color color = Color.White;

        //properties
        #region Properties
        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        } 
        #endregion

                //constructor
        public Image(PyramidPanic game, String pathNameAsset, Vector2 position)
        {
            this.game = game;
            this.title = game.Content.Load<Texture2D>(pathNameAsset);
            this.texture = game.Content.Load<Texture2D>(pathNameAsset);
            this.startButton = game.Content.Load<Texture2D>(pathNameAsset);
            this.scoresButton = game.Content.Load<Texture2D>(pathNameAsset);
            this.loadButton = game.Content.Load<Texture2D>(pathNameAsset);
            this.helpButton = game.Content.Load<Texture2D>(pathNameAsset);
            this.quitButton = game.Content.Load<Texture2D>(pathNameAsset);
            
            this.rec = new Rectangle((int)position.X, (int) position.Y, this.texture.Width, this.texture.Height);
        }

                //loadcontent

                //update

                //draw
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture, this.rec, this.color);
            this.game.SpriteBatch.Draw(this.title, this.rec, this.color);
            this.game.SpriteBatch.Draw(this.startButton, this.rec, this.color);
            this.game.SpriteBatch.Draw(this.scoresButton, this.rec, this.color);
            this.game.SpriteBatch.Draw(this.loadButton, this.rec, this.color);
            this.game.SpriteBatch.Draw(this.helpButton, this.rec, this.color);
            this.game.SpriteBatch.Draw(this.quitButton, this.rec, this.color);
        }

                //helpermethode
    }
}
