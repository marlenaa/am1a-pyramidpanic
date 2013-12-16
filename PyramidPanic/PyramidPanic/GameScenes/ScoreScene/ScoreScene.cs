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
    public class ScoreScene : IState
    {

        //fields van de class StartScene
        private PyramidPanic game;
        private SpriteFont spriteFont;
        


        //constructor van de StartScene class krijgt een object game mee van het type PyramidPanic
        public ScoreScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
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
            this.spriteFont = game.Content.Load<SpriteFont>(@"ScoreScene/ComicSans");
        }

        //update methode
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.W))
            {
                this.game.IState = this.game.LoadScene;
            }
            if (Input.EdgeDetectKeyDown(Keys.Q))
            {
                this.game.IState = this.game.StartScene;
            }
        }

        //draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);
            this.game.SpriteBatch.DrawString(this.spriteFont, "ScoreScene" , new Vector2(0f, 0f), Color.Black);
        }



    }
}
