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
     public class StartScene : IState
    {

            //fields van de class StartScene
         private PyramidPanic game;

         // maak een variabele ( reference) aan van de image class gemaamd background
         private Image background;
         private Image title;
         private Image startButton;
         private Image scoresButton;
         private Image loadButton;
         private Image helpButton;
         private Image levelButton;

            //constructor van de StartScene class krijgt een object game mee van het type PyramidPanic
         public StartScene(PyramidPanic game)
         {
             this.game = game;
             //roep de initialize methode aan.
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
             this.background = new Image(this.game, @"StartScene/Background", Vector2.Zero);
             this.title = new Image(this.game, @"StartScene/Title", new Vector2 (99f, 30f));
             this.startButton = new Image(this.game, @"StartScene/Button_start", new Vector2(20f, 430f));
             this.scoresButton = new Image(this.game, @"StartScene/Button_scores", new Vector2(130f, 430f));
             this.loadButton = new Image(this.game, @"Startscene/Button_load", new Vector2(240f, 430f));
             this.helpButton = new Image(this.game, @"Startscene/Button_help", new Vector2(350f, 430f));
             this.levelButton = new Image(this.game, @"StartScene/Button_leveleditor", new Vector2(470f, 430f));
         }

            //update methode
         public void Update(GameTime gameTime)
         {
             if (Input.EdgeDetectKeyDown(Keys.Right))
             {
                 this.game.IState = this.game.PlayScene;
             }
             if (Input.EdgeDetectKeyDown(Keys.Left))
             {
                 this.game.IState = this.game.HelpScene;
             }

         }

            //draw methode
         public void Draw(GameTime gameTime)
         {
             this.game.GraphicsDevice.Clear(Color.MediumAquamarine);
             this.background.Draw(gameTime);
             this.title.Draw(gameTime);
             this.startButton.Draw(gameTime);
             this.scoresButton.Draw(gameTime);
             this.loadButton.Draw(gameTime);
             this.helpButton.Draw(gameTime);
             this.levelButton.Draw(gameTime);
         }



    }
}