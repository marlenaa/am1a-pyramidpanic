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
    public class PlayScene : IState
    {

        //fields van de class StartScene
        private PyramidPanic game;
        private Image background;
        private Image bar;
        private Image lives;
        private Image lives2;
        private Image lives3;
        private Image scarab;

        //dit is het spriteFont voor de scores.
        private SpriteFont spriteFont;


        //hiermee maak je een variabele aan voor de scores daarna zorg je dat je ze kunt opvragen en kunt veranderen.
        private int score;
        private int scarscore;

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }
        public int scarScore
        {
            get { return this.scarscore; }
            set { this.scarscore = value; }
        }


        //constructor van de StartScene class krijgt een object game mee van het type PyramidPanic
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.initialize();
        }
        //initialize methode. deze methode initialiseert( geeft standaartwaarden aan variabelen)
        //void wil zeggen dat er niets teruggeven word.
        public void initialize()
        {
            //roep de load content methode aan.
            this.LoadContent();

        }

        //loadcontent method.e deze methode maakt nieuwe objecten aan van de verschillende classes.
        public void LoadContent()
        {
            this.background = new Image(this.game, @"PlayScene/Background2", Vector2.Zero);
            this.bar = new Image(this.game, @"PlayScene/panel", new Vector2(0f, 448f));
            this.spriteFont = game.Content.Load<SpriteFont>(@"PlayScene/ComicSans");
            this.score = 0;
            this.scarscore = 0;
            this.lives = new Image(this.game, @"PlayScene/Lives", new Vector2(73f, 448f));
            this.lives2 = new Image(this.game, @"PlayScene/Lives", new Vector2(113f, 448f));
            this.lives3 = new Image(this.game, @"PlayScene/Lives", new Vector2(150f, 448f));
            this.scarab = new Image(this.game, @"PlayScene/Scarab", new Vector2(260f, 449f));
        }

        //update methode
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.W))
            {
                this.game.IState = this.game.GameOverScene;
            }
            if (Input.EdgeDetectKeyDown(Keys.Q))
            {
                this.game.IState = this.game.StartScene;
            }

            if (this.score < 0)
            {
                this.game.IState = this.game.GameOverScene;
            }

        }

        //draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);

            this.background.Draw(gameTime);

            this.bar.Draw(gameTime);

            this.game.SpriteBatch.DrawString(this.spriteFont, "" + this.score, new Vector2(560f, 450f), Color.Gold);
            this.game.SpriteBatch.DrawString(this.spriteFont, "" + this.scarscore, new Vector2(310f, 450f), Color.Gold);

            this.lives.Draw(gameTime);
            this.lives2.Draw(gameTime);
            this.lives3.Draw(gameTime);
            this.scarab.Draw(gameTime);
        }



    }
}