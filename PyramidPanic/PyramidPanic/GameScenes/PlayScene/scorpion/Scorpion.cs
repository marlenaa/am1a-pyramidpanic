﻿using System;
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

    //hiermee beloofd de Scorpion class zich te houden aan de wetten en regels van de IAnimatedSprite class
    //de eerste is de ervende class
    public class Scorpion : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private IEntityState state;
        private Texture2D texture;
        private int speed = 2;
        private Vector2 position;
        //maak van iedere toestand(state) een field
        private WalkRight walkRight;
        private WalkLeft walkLeft;

        //properties
        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }

        public IEntityState State
        {
            set { this.state = value;   }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        //constructor
        public Scorpion(PyramidPanic game, Vector2 position, Texture2D texture)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(@"PlayScene/Scorpion");
            this.walkRight = new WalkRight(this);
            this.walkLeft = new WalkLeft(this);
            this.state = this.walkLeft;
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }
        //draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
