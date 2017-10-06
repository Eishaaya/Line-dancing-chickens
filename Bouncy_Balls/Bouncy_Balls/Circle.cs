using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Bouncy_Balls
{
    public class Circle
    {
        Texture2D _texture;
        Vector2 _position;
        Color _color;
        int _xspeed;
        int _yspeed;


        public Circle(Texture2D image, Vector2 position, Color color, int xspeed, int yspeed)
        {
            _texture = image;
            _position = position;
            _color = color;
            _xspeed = xspeed;
            _yspeed = yspeed;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_texture, _position, _color);
        }

        public void Update(GameTime gameTime, Viewport viewport)
        {
            _position.X += _xspeed;
            _position.Y += _yspeed;

            if (_position.X <= 0)
            {
                _xspeed *= -1;
            }
            if (_position.Y <= 0)
            {
                _yspeed *= -1;
            }
            if (_position.X + _texture.Width >= viewport.Width)
            {
                _xspeed *= -1;
            }
            if (_position.Y + _texture.Height >= viewport.Height)
            {
                _yspeed *= -1;
            }

        }

    }
}
