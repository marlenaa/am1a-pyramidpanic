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
    //hiermee beloofd de StartScene class zich te houden aan de wetten en regels van de IState class
    //de eerste is de ervende class
     public class StartScene : IState
    {

            //fields van de class StartScene
         private PyramidPanic game;
            //maak een nieuwe enum aan voor het lezen van de Buttons welke aangekozen is.
         private enum Buttons {Start, Scores, Load, Help, Quit } ;

            //maak een variabelen van het type  Buttons en geef hem de waarde Buttons.Start
         private Buttons buttonActive = Buttons.Start;

         // maak een variabele ( reference) aan van de image class gemaamd background
         private Image background;
         private Image title;
         private Image startButton;
         private Image scoresButton;
         private Image loadButton;
         private Image helpButton;
         private Image quitButton;
         


         // maak een variabele buttonlist van het type List<Image>.
         private List<Image> butttonList;

            //constructor van de StartScene class krijgt een object game mee van het type PyramidPanic
         public StartScene(PyramidPanic game)
         {
             this.game = game;
             //roep de Initialize methode aan.
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
             this.butttonList = new List<Image>();
             this.butttonList.Add(this.startButton = new Image(this.game, @"StartScene/Button_start", new Vector2(20f, 430f)));
             this.butttonList.Add(this.scoresButton = new Image(this.game, @"StartScene/Button_scores", new Vector2(130f, 430f)));
             this.butttonList.Add(this.loadButton = new Image(this.game, @"Startscene/Button_load", new Vector2(240f, 430f)));
             this.butttonList.Add(this.helpButton = new Image(this.game, @"Startscene/Button_help", new Vector2(350f, 430f)));
             this.butttonList.Add(this.quitButton = new Image(this.game, @"StartScene/Button_quit", new Vector2(470f, 430f)));
             this.background = new Image(this.game, @"StartScene/Background", Vector2.Zero);
             this.title = new Image(this.game, @"StartScene/Title", new Vector2 (99f, 30f));   
         }

            //update methode
         public void Update(GameTime gameTime)
         {
             //met deze methode kan je door de scenes heen bladeren.
             //kijkt of de w knop word ingedrukt
             if (Input.EdgeDetectKeyDown(Keys.W))
             {
                 this.game.IState = this.game.PlayScene;
             }
             //kijkt of de q knop word ingedrukt
             if (Input.EdgeDetectKeyDown(Keys.Q))
             {
                 this.game.IState = this.game.HelpScene;
             }
             {




                 // deze if- instructie checked of er op de rechter pijl toets word gedrukt.
                 //de actie die daarop volgt is het ophogen van de variabele ButtonActive
                 if (Input.EdgeDetectKeyDown(Keys.Right))
                 {
                     this.buttonActive++;
                 }
                 if (Input.EdgeDetectKeyDown(Keys.Left))
                 {
                     this.buttonActive--;
                 }


                 //we doorlopen de lijst met buttons met een foreacht instructie en we roepen voor ieder image object de propertie Color aan en geven deze de waarde Color.White

                 foreach (Image image in this.butttonList)
                 {
                     image.Color = Color.White;
                 }



                 // maak een switch case instructie voor de variabele burronActive.
                 /*switch (this.buttonActive)
                 {
                     
                     case Buttons.Start:
                         if (Input.EdgeDetectKeyDown(Keys.Enter))
                         {
                             this.game.IState = this.game.PlayScene;
                         }
                         this.startButton.Color = Color.Silver;
                         break;

                     case Buttons.Scores:
                         if (Input.EdgeDetectKeyDown(Keys.Enter))
                         {
                             this.game.IState = this.game.ScoreScene;
                         }
                         this.scoresButton.Color = Color.Silver;
                         break;

                     case Buttons.Load:
                         if (Input.EdgeDetectKeyDown(Keys.Enter))
                         {
                             this.game.IState = this.game.LoadScene;
                         }
                         this.loadButton.Color = Color.Silver;
                         break;

                     case Buttons.Help:
                         if (Input.EdgeDetectKeyDown(Keys.Enter))
                         {
                             this.game.IState = this.game.HelpScene;
                         }
                         this.helpButton.Color = Color.Silver;
                         break;

                     case Buttons.Quit:
                         if (Input.EdgeDetectKeyDown(Keys.Enter))
                         {
                             this.game.Exit();
                         }
                         this.quitButton.Color = Color.Silver;
                         break;
                 
                 }
                  */
             }
             if (this.startButton.Rectangle.Intersects(Input.MouseRect()))
             {
                 if (Input.EdgeDetectMousePressLeft())
                 {
                     this.game.IState = this.game.PlayScene;
                 }
                 this.startButton.Color = Color.Silver;
             }
             else if (this.scoresButton.Rectangle.Intersects(Input.MouseRect()))
             {
                 if (Input.EdgeDetectMousePressLeft())
                 {
                     this.game.IState = this.game.ScoreScene;
                 }
                 this.scoresButton.Color = Color.Silver;
             }
             else if (this.loadButton.Rectangle.Intersects(Input.MouseRect()))
             {
                 if (Input.EdgeDetectMousePressLeft())
                 {
                     this.game.IState = this.game.LoadScene;
                 }
                 this.loadButton.Color = Color.Silver;
             }
             else if (this.helpButton.Rectangle.Intersects(Input.MouseRect()))
             {
                 if (Input.EdgeDetectMousePressLeft())
                 {
                     this.game.IState = this.game.HelpScene;
                 }
                 this.helpButton.Color = Color.Silver;
             }
             else if (this.quitButton.Rectangle.Intersects(Input.MouseRect()))
             {
                 if (Input.EdgeDetectMousePressLeft())
                 {
                     this.game.Exit();
                 }
                 this.quitButton.Color = Color.Silver;
             }

         }

            //draw methode
         public void Draw(GameTime gameTime)
         {
             this.game.GraphicsDevice.Clear(Color.White);
             this.background.Draw(gameTime);
             this.title.Draw(gameTime);
             this.startButton.Draw(gameTime);
             this.scoresButton.Draw(gameTime);
             this.loadButton.Draw(gameTime);
             this.helpButton.Draw(gameTime);
             this.quitButton.Draw(gameTime);
         }



    }
}