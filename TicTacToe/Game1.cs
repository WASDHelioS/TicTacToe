using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TicTacToe
{
    public class Game1 : Game
    {
        public enum Turn
        {
            Player1, Player2
        };
        Turn turn;
        Texture2D tile;
        Texture2D cross;
        Texture2D circle;

        Tile[,] tiles;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            turn = Turn.Player1;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tile = Content.Load<Texture2D>("Square");
            tiles = GenerateTiles();

            cross = Content.Load<Texture2D>("Cross");
            circle = Content.Load<Texture2D>("Circle");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var mouseState = Mouse.GetState();
            var mousePos = new Point(mouseState.X,mouseState.Y).ToVector2();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (Tile t in tiles)
                {
                    Rectangle rect = new Rectangle((int)t.pos.X, (int)t.pos.Y, (int)t.GetScaledDownWidth(), (int)t.GetScaledDownHeight());
                    if (rect.Contains(mousePos))
                    {
                        if(t.fill != null)
                        {
                            break;
                        }
                        switch (turn)
                        {
                            case Turn.Player1:
                                t.fill = new Circle(circle, t);
                                turn = Turn.Player2;
                                break;
                            case Turn.Player2:
                                t.fill = new Cross(cross, t);
                                turn = Turn.Player1;
                                break;
                        }
                    }
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            for(int i = 0; i < tiles.GetLength(0);i++)
            {
                for(int j = 0; j < tiles.GetLength(1);j++)
                {
                    _spriteBatch.Draw(tiles[i,j].tile, 
                                      tiles[i,j].pos, 
                                      null, 
                                      tiles[i,j].color, 
                                      0.0f, 
                                      new Vector2(tiles[i,j].GetScaledDownWidth()/2,tiles[i,j].GetScaledDownHeight()/2), 
                                      tiles[i,j].scale, 
                                      new SpriteEffects(), 
                                      tiles[i,j].depth);
                    if(tiles[i,j].fill != null)
                    {
                        _spriteBatch.Draw(tiles[i, j].fill.texture, 
                                          tiles[i, j].fill.pos, 
                                          null, 
                                          Color.White, 
                                          0.0f, 
                                          new Vector2(tiles[i, j].GetScaledDownWidth() / 2, tiles[i, j].GetScaledDownHeight() / 2), 
                                          tiles[i, j].fill.scale, 
                                          new SpriteEffects(), 
                                          tiles[i, j].fill.depth);
                    }
                }
            }
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public Tile[,] GenerateTiles()
        {
            Tile[,] t = new Tile[3,3];
            for(int i = 0;i<3;i++)
            {
                for(int j=0;j<3;j++)
                {
                    Tile temp = new Tile(tile, 0.5f, new Vector2(0, 0));
                    temp.pos = new Vector2((float)i * temp.GetScaledDownWidth() + temp.GetScaledDownWidth() / 3, j * temp.GetScaledDownHeight() + temp.GetScaledDownHeight() / 3);
                    t[i, j] = temp;
                }
            }
            
            return t;
        }
    }
}
