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
using PyramidPanic.GameScenes.Objects;
using System.IO;

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
        private Texture2D beetle;
        private Texture2D scorpion;
        private Image scarab;
        private List<IStaticObject> staticObjects;
        private List<IAnimatedSprite> enemies;
        private Texture2D block, block2, block3;
        private KeyboardState ks, oks;
        private Explorer explorer;


        public List<IStaticObject> StaticObjects
        {
            get { return this.staticObjects; }
        }

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
            this.staticObjects = new List<IStaticObject>();
            this.enemies = new List<IAnimatedSprite>();
            this.initialize();
        }
        //Initialize methode. deze methode initialiseert( geeft standaartwaarden aan variabelen)
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
            this.block = game.Content.Load<Texture2D>(@"PlayScene/Block");
            this.block2 = game.Content.Load<Texture2D>(@"PlayScene/Block_hor");
            this.block3 = game.Content.Load<Texture2D>(@"PlayScene/Block_vert");
            this.beetle = game.Content.Load<Texture2D>(@"PlayScene/Beetle");
            this.scorpion = game.Content.Load<Texture2D>(@"PlayScene/Scorpion");
            this.LoadLevel("level1.txt");
            this.explorer = new Explorer(this.game, new Vector2(32f, 240f));
        }

        #region levellader
        private void LoadLevel(String File)
        {
            StreamReader stream = new StreamReader(File);

            int y = 0;
            string s;
            while ((s = stream.ReadLine()) != null)
            {
                for (int x = 0; x < s.Length; x++)
                {
                    addObject((char)s[x], x, y);
                }
                y++;
            }
        }
        private void addObject(char c, int x, int y)
        {
            switch (c)
            {
                case '1': this.staticObjects.Add(new Wall(x, y, this.block));
                    break;
                case '2': this.staticObjects.Add(new Wall(x, y, this.block2));
                    break;
                case '3': this.staticObjects.Add(new Wall(x, y, this.block3));
                    break;
                case 'B': this.enemies.Add(new Beetle(this.game, new Vector2(x * 32, y * 32), this.beetle));
                    break;
                case 'S': this.enemies.Add(new Scorpion(this.game, new Vector2(x * 32, y * 32), this.scorpion));
                    break;
            }
        } 
        #endregion

        //update methode
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.W))
            {
                this.game.IState = this.game.ScoreScene;
            }
            if (Input.EdgeDetectKeyDown(Keys.Q))
            {
                this.game.IState = this.game.StartScene;
            }

            if (this.score < 0)
            {
                this.game.IState = this.game.GameOverScene;
            }
            foreach (IAnimatedSprite en in this.enemies) en.Update(gameTime);
            this.explorer.Update(gameTime);

            this.ks = Keyboard.GetState();
            //edgedetector
            /*
            if (ks.IsKeyDown(Keys.Right))
            {
                this.explorer.Position += new Vector2(2, 0);
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                this.explorer.Position -= new Vector2(2, 0);
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                this.explorer.Position += new Vector2(2, 0);
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                this.explorer.Position -= new Vector2(2, 0);
            }
            */
            this.explorer.Update(gameTime);
            oks = ks;

        }

        //draw methode
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.White);

            this.background.Draw(gameTime);

            foreach (IStaticObject obj in staticObjects) obj.Draw(this.game.SpriteBatch);

            this.bar.Draw(gameTime);

            this.game.SpriteBatch.DrawString(this.spriteFont, "" + this.score, new Vector2(560f, 450f), Color.Gold);
            this.game.SpriteBatch.DrawString(this.spriteFont, "" + this.scarscore, new Vector2(310f, 450f), Color.Gold);

            this.lives.Draw(gameTime);
            this.lives2.Draw(gameTime);
            this.lives3.Draw(gameTime);
            this.scarab.Draw(gameTime);
            foreach (IAnimatedSprite en in this.enemies) en.Draw(gameTime);
            this.explorer.Draw(gameTime);
        }
    }
}