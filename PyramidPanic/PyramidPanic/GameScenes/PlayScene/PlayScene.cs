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
        private Image scarab;
        private List<IStaticObject> staticObjects;
        private Texture2D block;
        private Texture2D texture;
        private Rectangle textureDestinationRect;
        private Rectangle textureSourceRect;
        private SpriteEffects effect = SpriteEffects.FlipHorizontally;
        private KeyboardState ks, oks;
        private float timer = 0;
        

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
            this.LoadLevel("level1.txt");
            this.texture = this.game.Content.Load<Texture2D>(@"PlayScene/Explorer");
            this.textureDestinationRect = new Rectangle(0, 0, 0, 0);
            this.textureSourceRect = new Rectangle(0, 0, 0, 0);
            
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

            this.ks = Keyboard.GetState();
            //edgedetector
            if (ks.IsKeyDown(Keys.Right))
            {
                this.effect = SpriteEffects.FlipHorizontally;
                if (this.timer > 5f / 60f)
                {
                    if (this.textureSourceRect.X < 10)
                    {
                        this.textureSourceRect.X += 101;
                        if (this.textureDestinationRect.X < 840 - this.textureDestinationRect.Width)
                        {
                            this.textureDestinationRect.X += 25;
                        }
                    }
                    else
                    {
                        this.textureSourceRect.X = 0;
                    }
                    this.timer = 0f;
                }
                else
                {
                    this.timer += 1f / 60f;
                }
            }

            if (ks.IsKeyDown(Keys.Left))
            {
                this.effect = SpriteEffects.None;
                if (this.timer > 5f / 60f)
                {
                    if (this.textureSourceRect.X < 10)
                    {
                        this.textureSourceRect.X += 101;
                        if (this.textureDestinationRect.X > 0)
                        {
                            this.textureDestinationRect.X -= 25;
                        }
                    }
                    else
                    {
                        this.textureSourceRect.X = 0;
                    }
                    this.timer = 0f;
                }
                else
                {
                    this.timer += 1f / 60f;
                }
            }
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
            this.game.SpriteBatch.Draw(this.texture, this.textureDestinationRect, Color.White);
        }
    }
}