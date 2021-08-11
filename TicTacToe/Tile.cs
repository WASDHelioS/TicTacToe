using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TicTacToe
{
    public class Tile
    {
        public float scale;
        public Vector2 pos;
        public float depth;
        public Texture2D tile;
        public Color color = Color.White;
        public Vector2 origin;
        public PlayerObject fill = null;

        public Tile(Texture2D tile,float scale, Vector2 pos)
        {
            this.scale = scale;
            this.pos = pos;
            this.tile = tile;
            origin = new Vector2(GetScaledDownWidth() / 2, GetScaledDownHeight() / 2);
        }

        public void SetPos(Vector2 pos)
        {
            this.pos = pos;
        }



        public float GetScaledDownWidth()
        {
            return (float)tile.Width * scale;
        }
        public float GetScaledDownHeight()
        {
            return (float)tile.Height * scale;
        }
    }
}
