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
    //hiermee beloofd de gameoverscene om zich te houden aan de wetten en regels die staan in de istate
    public class GameOverScene : IState
    {

        //fields van de class StartScene
        private PyramidPanic game;
        private SpriteFont spriteFont;
        private Texture2D overlay;


        //constructor van de StartScene class krijgt een object game mee van het type PyramidPanic
        public GameOverScene(PyramidPanic game)
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
            this.spriteFont = game.Content.Load<SpriteFont>(@"GameOverScene/ComicSans");
            this.overlay = game.Content.Load<Texture2D>(@"GameOverScene/Overlay");
        }

        //update methode
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.W))
            {
                this.game.IState = this.game.HelpScene;
            }
            if (Input.EdgeDetectKeyDown(Keys.Q))
            {
                this.game.IState = this.game.PlayScene;
            }

        }

        //draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);
            this.game.SpriteBatch.Draw(this.overlay, new Vector2(0f, 0f), Color.White);
        }



    }
}