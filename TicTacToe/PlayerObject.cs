using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TicTacToe
{
    public abstract class PlayerObject
    {
        public Vector2 pos;
        public Texture2D texture;
        public float depth = 0.2f;
        public float scale;
    }
}
