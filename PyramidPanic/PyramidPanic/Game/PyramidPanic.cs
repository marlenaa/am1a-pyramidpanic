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
    
    public class PyramidPanic : Microsoft.Xna.Framework.Game

        //fields
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //maak een variabele aan van het type StartScene
        private StartScene startScene;
        private PlayScene playScene;
        private HelpScene helpScene;
        private GameOverScene gameOverScene;

        private IState iState;
        //properties
        //maak de interface variabele iState buiten de claas d.m.v een prpertie IState
        #region Properties
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }
        }
        public StartScene StartScene
        {
            get { return this.startScene; }
        }
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }
        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        } 
        #endregion

        //propertie voor spritebatch
        public SpriteBatch SpriteBatch
        {
            get { return this.spriteBatch; }
        }


        //properties

        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //constructor

        protected override void Initialize()
        {
            // dit zorgt ervoor dat je met de muis over het scherm kan hoveren
            IsMouseVisible = true;
            //dit is voor de hoogte en breedte van het gamescherm
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            //dit is de titel van het scherm
            Window.Title = "Pyramid Panic";
            this.graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
                    //spritebatch is nodig voor het tekenen van textures op de canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);
                    //maak nu een instantie aan van het type startScene. 
                    //Dit doe je door de constructor aan te roepen van de startscene class.
            this.startScene = new StartScene(this);
            this.playScene = new PlayScene(this);
            this.helpScene = new HelpScene(this);
            this.gameOverScene = new GameOverScene(this);
                    //this.istate word aangeroepen
            this.iState = this.StartScene;
        }   

        protected override void UnloadContent()
        {
        }

        //update

        protected override void Update(GameTime gameTime)
        {
                    //zorgt ervoor dat het spel stopt als je op de gamepad op back drukt
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) || (Keyboard.GetState().IsKeyDown(Keys.Escape))) 
                this.Exit();
            Input.Update();
            this.iState.Update(gameTime);
            
            // Roep de Update methode aan van de StartScene class
            base.Update(gameTime);
        }


        //draw
        protected override void Draw(GameTime gameTime)
        {
                    //geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.Black);

                    //dit geeft aan dat je begint
            spriteBatch.Begin();
                    //roep de draw methode aan
            this.iState.Draw(gameTime);
                    //dit geeft aan dat je eindigt
            spriteBatch.End();
           
            base.Draw(gameTime);
        }
    }
}
