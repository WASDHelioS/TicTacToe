using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TicTacToe
{
    class Circle : PlayerObject
    {

        public Circle(Texture2D texture, Tile t)
        {
            this.texture = texture;
            this.pos = t.pos;
            this.scale = t.scale - 0.1f;
        }
    }
}
