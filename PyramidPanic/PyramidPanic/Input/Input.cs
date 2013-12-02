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
    public static class Input
    {
        //fields
        //keyboardstate voor edge detection
        public static KeyboardState ks, oks;

        //keyboard state voor edge detection
        private static MouseState ms, oms;

        //
        private static Rectangle mouseRect;

        //contructor
        static Input()
        {
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oks = ks;
            oms = ms;
            mouseRect = new Rectangle(ms.X, ms.Y, 1, 1);
        }


        //update
        public static void Update()
        {
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
        }
        //dit is een edge detector voor het indrukken van een knop
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }
        //dit is een edge detector voor het loslaten van een knop 
        public static bool EdgeDetectKeyUp(Keys key)
        {
            return (ks.IsKeyUp(key) && oks.IsKeyDown(key));
        }
        //dit is een edge detector voor het indrukken van de linkeruisknop
        public static bool EdgeDetectMousePressLeft()
        {
            return (ms.LeftButton == ButtonState.Pressed &&
                    oms.LeftButton == ButtonState.Released);
        }
        //dit is een edge detector voor het indrukken van de rechtermuisknop
        public static bool EdgeDetectMousePressRight()
        {
            return (ms.RightButton == ButtonState.Pressed &&
                    oms.RightButton == ButtonState.Released);
        }
        //dit is een level detector voor het detecteren of een keyboardtoets is ingedrukt
        public static bool LevelDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key));
        }
        public static bool LevelDetectKeyUp(Keys key)
        {
            return (ks.IsKeyUp(key));
        }
        public static Vector2 MousePosition()
        {
            return new Vector2(ms.X, ms.Y);
        }
        public static Rectangle MouseRect()
        {
            mouseRect.X = ms.X;
            mouseRect.Y = ms.Y;
            return mouseRect;
        }
    }
}
