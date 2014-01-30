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
    public class HelpScene : IState
    {

        //fields van de class StartScene
        private PyramidPanic game;
        private SpriteFont spriteFont;


        //constructor van de StartScene class krijgt een object game mee van het type PyramidPanic
        public HelpScene(PyramidPanic game)
        {
            this.game = game;
            this.initialize();
        }
        //Initialize methode. deze methode initialiseert( geeft standaartwaarden aan variabelen)
        //void wil zeggen dat er niets teruggeven word.
        public void initialize()
        {
            this.spriteFont = game.Content.Load<SpriteFont>(@"HelpScene/ComicSans");
            this.LoadContent();
        }

        //loadcontent method.e deze methode maakt nieuwe objecten aan van de verschillende classes.
        public void LoadContent()
        {

        }

        //update methode
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.W))
            {
                this.game.IState = this.game.StartScene;
            }
            if (Input.EdgeDetectKeyDown(Keys.Q))
            {
                this.game.IState = this.game.LoadScene;
            }

        }

        //draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);
            //hier heb ik geschreven welke scene dit is
            this.game.SpriteBatch.DrawString(this.spriteFont, "HELPSCENE", new Vector2(0f, 0f), Color.Black);
        }



    }
}