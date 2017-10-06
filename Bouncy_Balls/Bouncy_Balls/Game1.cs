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

namespace Bouncy_Balls
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D swedishImage;
        Vector2 swedishPosition;
        Color swedishTint;
        Circle circle1;
        Random random;
        Circle[] circles;
        Song chickenSong;
        //make this have 2 balls, with the same image, that bounce around the screen
        int xspeed = 5;
        int yspeed = 5;
        int xspeed2 = 6;
        int yspeed2 = 6;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1900;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            chickenSong = Content.Load<Song>("chickenSong");
            MediaPlayer.Play(chickenSong);

            random = new Random();
            circles = new Circle[600];
            spriteBatch = new SpriteBatch(GraphicsDevice);
            for (int i = 0; i < 600; i++)
            {
                circles[i] = new Circle(Content.Load<Texture2D>("Chiken"), new Vector2(0, 0), Color.White, random.Next(1, 10), random.Next(1, 60));
            }

            swedishImage = Content.Load<Texture2D>("swedish_chef");
            swedishPosition = new Vector2(0, 0);
            swedishTint = Color.White;
            circle1 = new Circle(Content.Load<Texture2D>("Chiken"), new Vector2(0, 0), Color.White, random.Next(1, 30), random.Next(1, 60));

        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            circle1.Update(gameTime, GraphicsDevice.Viewport);
            for (int e = 0; e < 600; e++)
            {
                circles[e].Update(gameTime, GraphicsDevice.Viewport);
            }
            if (!(MediaPlayer.State == MediaState.Playing))
            {
                MediaPlayer.Play(chickenSong);
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
            spriteBatch.Begin();
            spriteBatch.Draw(swedishImage, swedishPosition, swedishTint);
            circle1.Draw(spriteBatch);
            for (int t = 0; t < 600; t++)
            {
                circles[t].Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
