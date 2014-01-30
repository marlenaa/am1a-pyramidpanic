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
    public interface IEntityState
    {
        //hier word de initialize aangeroepen
        void initialize();
        //update
        void Update(GameTime gameTime);
        //draw
        void Draw(GameTime gameTime);
    }
}
