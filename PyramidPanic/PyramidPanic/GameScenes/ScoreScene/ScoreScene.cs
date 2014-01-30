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
    //hiermee beloofd de ScoreScene class zich te houden aan de wetten en regels van de IState class
    //de eerste is de ervende class
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
            //hiermee kan je door de Scenes doorbladeren.
            //kijkt of de w knop word ingedrukt
            if (Input.EdgeDetectKeyDown(Keys.W))
            {
                this.game.IState = this.game.LoadScene;
            }
            //kijkt of de q knop word ingedrukt
            if (Input.EdgeDetectKeyDown(Keys.Q))
            {
                this.game.IState = this.game.StartScene;
            }
        }

        //draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);
            //hier heb ik geschreven welke Scene dit is.
            this.game.SpriteBatch.DrawString(this.spriteFont, "ScoreScene" , new Vector2(0f, 0f), Color.Black);
        }



    }
}
