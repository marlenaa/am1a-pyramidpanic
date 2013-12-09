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
             this.title = new Image(this.game, @"StartScene/Title", new Vector2 (100f, 50f));
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
         }



    }
}