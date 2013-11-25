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

            base.Update(gameTime);
        }


        //draw
        protected override void Draw(GameTime gameTime)
        {
                    //geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);
        }
    }
}
